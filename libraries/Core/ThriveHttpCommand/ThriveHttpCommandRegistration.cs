// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ThriveHttpCommand; 

public static  class ThriveHttpCommandRegistration {
    public static IServiceCollection AddHttpServices(this IServiceCollection services)
    {
        services.TryAddScoped<IExternalCommand, ExternalCommand>();
        return services;
    }
}