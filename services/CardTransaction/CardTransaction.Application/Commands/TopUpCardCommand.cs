// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using CardTransaction.Domain.Specification;
using CardTransaction.Domain.ValueObjects;
using MediatR;
using ThriveShared.Interfaces;

namespace CardTransaction.Application.Commands;

public record TopUpCardCommand : IRequest {
    public Guid   Id             { get; init; }
    public string ThriveId       { get; init; }
    public string Currency       { get; init; }
    public float  WalletTransfer { get; init; }
};
public class TopUpCardCommandHandler : IRequestHandler<TopUpCardCommand> {
    private readonly IRepository<Trader> _repository;

    public TopUpCardCommandHandler(IRepository<Trader> repository) {
        _repository = repository;
    }

    public async Task<Unit> Handle(TopUpCardCommand request, CancellationToken cancellationToken) {
        var spec = new TraderByIdWithCardSpec(request.Id, request.ThriveId);
        var trader = await _repository.GetByIdAsync(spec, cancellationToken);
        
        if (trader == null) throw new ArgumentException(); // middleware handle error to user friend one
        trader.TopUpCardBalance(new Money(request.WalletTransfer, request.Currency));
        
        return Unit.Value;
    }
}