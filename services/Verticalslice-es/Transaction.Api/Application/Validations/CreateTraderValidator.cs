// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using FluentValidation;
using static Transaction.Api.Application.Writes.TraderCommands;
namespace Transaction.Api.Application.Validations; 

public class CreateTraderValidator : AbstractValidator<CreateTrader> {
    public CreateTraderValidator() {
        RuleFor(p => p.ProfileNumber)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(16).WithMessage("{PropertyName} must not exceed 16 characters.");
        RuleFor(p => p.ThriveId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 characters.");
    }
}