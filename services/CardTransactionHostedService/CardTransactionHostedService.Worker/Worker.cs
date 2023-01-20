using CardTransactionHostedService.Core.Interfaces;

namespace CardTransactionHostedService.Worker;

public class Worker : BackgroundService {
    private readonly ILogger<Worker>    _logger;
    private readonly IEntryPointService _entryPointService;
    private readonly WorkerSettings     _settings;

    public Worker(ILogger<Worker> logger) {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        _logger.LogInformation("CardTransaction.Worker service starting at: {time}", DateTimeOffset.Now);
        while (!stoppingToken.IsCancellationRequested)
        {
            await _entryPointService.ExecuteAsync();
            await Task.Delay(_settings.DelayMilliseconds, stoppingToken);
        }
        _logger.LogInformation("CardTransaction.Worker service stopping at: {time}", DateTimeOffset.Now);

    }
}