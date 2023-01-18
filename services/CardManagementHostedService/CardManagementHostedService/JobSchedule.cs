// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace CardManagementHostedService; 

public class JobSchedule {
    public JobSchedule(Type jobType, string cronExpression)
    {
        JobType        = jobType;
        CronExpression = cronExpression;
    }

    public Type   JobType        { get; }
    public string CronExpression { get; }
}