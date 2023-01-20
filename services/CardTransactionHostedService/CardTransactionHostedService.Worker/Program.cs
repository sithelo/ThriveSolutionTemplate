using CardTransactionHostedService.Core.Interfaces;
using CardTransactionHostedService.Core.Services;
using CardTransactionHostedService.Core.Settings;
using CardTransactionHostedService.Infrastructure;
using CardTransactionHostedService.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => {
        
        services.AddSingleton<IEntryPointService, EntryPointService>();
        services.AddSingleton<IServiceLocator, ServiceScopeFactoryLocator>();
        
        services.AddDbContext(hostContext.Configuration);
        services.AddRepositories();
        
        var workerSettings = new WorkerSettings();
        hostContext.Configuration.Bind(nameof(WorkerSettings), workerSettings);
        services.AddSingleton(workerSettings);

        var entryPointSettings = new EntryPointSettings();
        hostContext.Configuration.Bind(nameof(EntryPointSettings), entryPointSettings);
        services.AddSingleton(entryPointSettings);
        
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();