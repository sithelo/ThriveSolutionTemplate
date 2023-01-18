namespace CardTransactionHostedService.Core.Interfaces;

public interface IQueueReceiver
{
  Task<string> GetMessageFromQueue(string queueName);
}
