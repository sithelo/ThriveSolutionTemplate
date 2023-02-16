// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using ThriveShared;

namespace CardTransaction.Infrastructure.BackgroundJobs; 

[DisallowConcurrentExecution]
public class ProcessOutboxMessagesJob : IJob {
    private readonly AppDbContext _dbContext;
    private readonly IPublisher   _publisher;

    public ProcessOutboxMessagesJob(AppDbContext dbContext, IPublisher publisher) {
        _dbContext      = dbContext;
        _publisher = publisher;
    }

    public async Task Execute(IJobExecutionContext context) {
        var messages = await _dbContext.Set<OutboxMessage>()
            .Where(m => m.ProcessedOn == null)
            .Take(20)
            .ToListAsync(context.CancellationToken);

        foreach (var outboxMessage in messages) {
            var domainEvent = JsonConvert.DeserializeObject(outboxMessage.Content);
            if (domainEvent is null) {
                continue;
            }

           // await _publisher.Publish(domainEvent, context.CancellationToken);
            // handle some error
            outboxMessage.ProcessedOn = DateTimeOffset.Now;
        }

        await _dbContext.SaveChangesAsync();
    }
}