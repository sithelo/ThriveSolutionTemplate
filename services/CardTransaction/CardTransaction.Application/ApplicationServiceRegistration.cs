// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CardTransaction.Application; 

public static class ApplicationServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}