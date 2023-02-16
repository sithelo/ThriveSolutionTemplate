// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using ThriveShared;

namespace CardTransaction.Infrastructure.Data;

public sealed class ConvertDomainEventsToOutboxMessagesInterceptor : SaveChangesInterceptor {
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData      eventData,
        InterceptionResult<int> result,
        CancellationToken       cancellationToken = default
    ) {
        var dbContext = eventData.Context;
        if (dbContext is null) {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var outboxMessages = dbContext.ChangeTracker.Entries<EntityBase<Guid>>()
            .Select(e => e.Entity)
            .SelectMany(aggregateRoot => {
                var domainEvents = aggregateRoot.GetDomainEvents();
                aggregateRoot.ClearDomainEvents();
                return domainEvents;
            })
            .Select(
                domainEvents => new OutboxMessage {
                    Id         = Guid.NewGuid(),
                    OccurredOn = DateTimeOffset.Now,
                    Type       = domainEvents.GetType().Name,
                    Content = JsonConvert.SerializeObject(
                        domainEvents,
                        new JsonSerializerSettings {
                            TypeNameHandling = TypeNameHandling.All
                        }),
                    ProcessedOn = null
                }).ToList();

        dbContext.Set<OutboxMessage>().AddRange(outboxMessages);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}