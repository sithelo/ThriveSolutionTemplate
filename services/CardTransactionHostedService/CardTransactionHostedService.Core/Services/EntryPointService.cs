using CardTransactionHostedService.Core.Entities;
using CardTransactionHostedService.Core.Interfaces;
using CardTransactionHostedService.Core.Settings;
using Microsoft.Extensions.DependencyInjection;


namespace CardTransactionHostedService.Core.Services;


public class EntryPointService : IEntryPointService
{
  private readonly ILoggerAdapter<EntryPointService> _logger;
  private readonly EntryPointSettings _settings;
  private readonly IQueueReceiver _queueReceiver;
  private readonly IQueueSender _queueSender;
  private readonly IServiceLocator _serviceScopeFactoryLocator;

  public EntryPointService(ILoggerAdapter<EntryPointService> logger,
      EntryPointSettings settings,
      IQueueReceiver queueReceiver,
      IQueueSender queueSender,
      IServiceLocator serviceScopeFactoryLocator)
  {
    _logger = logger;
    _settings = settings;
    _queueReceiver = queueReceiver;
    _queueSender = queueSender;
    _serviceScopeFactoryLocator = serviceScopeFactoryLocator;
  }

  public async Task ExecuteAsync()
  {
    _logger.LogInformation("{service} running at: {time}", nameof(EntryPointService), DateTimeOffset.Now);
    try
    {
      // EF Requires a scope so we are creating one per execution here
      using var scope = _serviceScopeFactoryLocator.CreateScope();
      var repository =
          scope.ServiceProvider
              .GetService<IRepository>();

      // read from the queue
      var message = await _queueReceiver.GetMessageFromQueue(_settings.ReceivingQueueName);
      if (String.IsNullOrEmpty(message)) return;

    

      // record HTTP status / response time / maybe existence of keyword in database
      repository.Add(new TraderTransaction());
      
    }
#pragma warning disable CA1031 // Do not catch general exception types
    catch (Exception ex)
    {
      _logger.LogError(ex, $"{nameof(EntryPointService)}.{nameof(ExecuteAsync)} threw an exception.");
     
    }
#pragma warning restore CA1031 // Do not catch general exception types
  }
}
