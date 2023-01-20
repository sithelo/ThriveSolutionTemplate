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

public record UpdateTopUpCardCommand : IRequest {
    public Guid   Id             { get; init; }
    public string ThriveId       { get; init; }
    public string Currency       { get; init; }
    public float  WalletTransfer { get; init; }
};
public class UpdateTopUpCardCommandHandler : IRequestHandler<UpdateTopUpCardCommand> {
    private readonly IRepository<Trader> _repository;

    public UpdateTopUpCardCommandHandler(IRepository<Trader> repository) {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateTopUpCardCommand request, CancellationToken cancellationToken) {

        var validator = new UpdateTopUpCardCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);
        var spec = new TraderByIdWithCardSpec(request.Id, request.ThriveId);
        var trader = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        
        if (trader == null) throw new NotFoundException(nameof(Trader), request.Id); // middleware handle error to user friend one
        trader.TopUpCardBalance(new Money(request.WalletTransfer, request.Currency));
        
        return Unit.Value;
    }
}