// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Application.Commands;
using FluentValidation;

namespace CardTransaction.Application.Validations; 

public class UpdateTopUpCardCommandValidator : AbstractValidator<UpdateTopUpCardCommand> {
    public UpdateTopUpCardCommandValidator() {
        RuleFor(p => p.ThriveId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(7).WithMessage("{PropertyName} must not exceed 6 characters.");
        
    }
}