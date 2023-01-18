using CardManagementHostedService;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddSingleton<IJobFactory, JobFactory>();
        services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
        services.AddSingleton<QuartzJobRunner>();
        services.AddHostedService<Worker>();
        
    
        services.AddScoped<DoSomethingJob>();


        services.AddSingleton(new JobSchedule(
            jobType: typeof(DoSomethingJob),
            cronExpression: "0/5 * * * * ?")); //every 5 seconds
    })
    .Build();

await host.RunAsync();