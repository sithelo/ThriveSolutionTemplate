// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardManagement.Application.Commands;
using FluentValidation;

namespace CardManagement.Application.Validations; 

public class ActivateCardCommandValidator : AbstractValidator<ActivateCardCommand> {
    public ActivateCardCommandValidator() {
        RuleFor(p => p.ThriveId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(7).WithMessage("{PropertyName} must not exceed 6 characters.");
        
    }
}