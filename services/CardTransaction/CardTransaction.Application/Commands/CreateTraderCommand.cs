// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Application.Exceptions;
using CardTransaction.Application.Validations;
using CardTransaction.Domain.Entities;
using CardTransaction.Domain.Specification;
using CardTransaction.Domain.ValueObjects;
using MediatR;
using ThriveShared.Interfaces;

namespace CardTransaction.Application.Commands;

public record CreateTraderCommand : IRequest<Guid> {
    public string ThriveId       { get; init; }
    public string Currency       { get; init; }
    public bool  kyc { get; init; }
};
public class CreateTraderCommandHandler : IRequestHandler<CreateTraderCommand, Guid> {
    private readonly IRepository<Trader> _repository;

    public CreateTraderCommandHandler(IRepository<Trader> repository) {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTraderCommand request, CancellationToken cancellationToken) {

        var validator = new CreateTraderCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);
        var spec = new TraderByIdSpec(request.ThriveId);
        var trader = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

        if (trader != null) throw new NotFoundException(nameof(Trader), request.ThriveId);
        var newTrader = new Trader(Guid.NewGuid(), request.ThriveId, request.kyc, request.Currency);
        newTrader.NewTrader();
        var createdTrader = await _repository.AddAsync(newTrader); 
        return createdTrader.Id;
    }
}