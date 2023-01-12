// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using System.ComponentModel.DataAnnotations.Schema;

namespace ThriveShared; 

public abstract class EntityBase<TId>
{
    public TId Id { get; set; }

    private List<DomainEventBase> _domainEvents = new ();
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}