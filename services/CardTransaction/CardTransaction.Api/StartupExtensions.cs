// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter;
using CardTransaction.Api.Middleware;
using CardTransaction.Application;
using CardTransaction.Infrastructure;
using CardTransaction.Infrastructure.BackgroundJobs;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Quartz;

namespace CardTransaction.Api;

public static class StartupExtensions {
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder
    ) {
        var serviceName = Assembly.GetExecutingAssembly().GetName().Name;
        var serviceVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        builder.Services.AddOpenTelemetryTracing(providerBuilder =>
        {
            providerBuilder
                .AddConsoleExporter()
                .AddSource(serviceName)
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
                .AddAspNetCoreInstrumentation()
                .AddAzureMonitorTraceExporter(o =>
                {
                    o.ConnectionString = builder.Configuration.GetSection("AzureMonitorTrace").Value;
                });
        });
        AddSwagger(builder.Services);

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddQuartz(configure => {
            var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));
            configure.AddJob<ProcessOutboxMessagesJob>(jobKey).AddTrigger(
                trigger => trigger.ForJob(jobKey)
                    .WithSimpleSchedule(
                        schedule => schedule.WithIntervalInSeconds(10)
                            .RepeatForever()));
            configure.UseMicrosoftDependencyInjectionJobFactory();
        });

        builder.Services.AddQuartzHostedService();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Card Transaction API");
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseCustomExceptionHandler();

        app.UseCors("Open");

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    private static void AddSwagger(IServiceCollection services) {
        services.AddSwaggerGen(c => {
            c.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 123456abcdef'",
                    Name   = "Authorization",
                    In     = ParameterLocation.Header,
                    Type   = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id   = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name   = "Bearer",
                        In     = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });

            c.SwaggerDoc("v1",
                new OpenApiInfo {
                    Version = "v1",
                    Title   = "Card Transaction API",
                });
            
        });
    }
}