// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Quartz;

namespace CardManagementHostedService; 

public class DoSomethingJob : IJob
{
    private readonly ILogger<DoSomethingJob> _logger;
    private readonly Guid                    _guid;

    public DoSomethingJob(ILogger<DoSomethingJob> logger)
    {
        _logger = logger;
        _guid   = Guid.NewGuid();
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("The job is: " + _guid);
        return Task.CompletedTask;
    }
}