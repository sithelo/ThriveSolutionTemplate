// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardManagement.Application.Exceptions;
using CardManagement.Application.Validations;
using CardManagement.Domain.Entities;
using CardManagement.Domain.Specification;
using MediatR;
using ThriveShared.Interfaces;

namespace CardManagement.Application.Commands;

public record ActivateCardCommand : IRequest {
    public string ThriveId   { get; init; }
    public Guid   Id         { get; init; }
    public string CardNumber { get; init; }
    public string CardExpiry { get; init; }
    public string CVV        { get; init; }
};

public class ActivateCardCommandHandler : IRequestHandler<ActivateCardCommand> {
    private readonly IRepository<Trader> _repository;

    public ActivateCardCommandHandler(IRepository<Trader> repository) {
        _repository = repository;
    }

    public async Task<Unit> Handle(ActivateCardCommand request, CancellationToken cancellationToken) {
        var validator = new ActivateCardCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var spec = new TraderByIdWithCardSpec(request.ThriveId);
        var trader = await _repository.GetByIdAsync(spec, cancellationToken);

        if (trader == null)
            throw new NotFoundException(nameof(Trader), request.Id); // middleware handle error to user friend one

        // trader.TopUpCardBalance(new Money(request.WalletTransfer, request.Currency));
        trader.ActivateCard(request.CardNumber, request.CardExpiry, request.CVV);
        return Unit.Value;
    }
}