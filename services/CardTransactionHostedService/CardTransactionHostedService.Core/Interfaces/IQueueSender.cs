namespace CardTransactionHostedService.Core.Interfaces;

public interface IQueueSender
{
  Task SendMessageToQueue(string message, string queueName);
}
