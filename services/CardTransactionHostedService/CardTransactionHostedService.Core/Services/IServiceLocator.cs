using System;
using Microsoft.Extensions.DependencyInjection;

namespace CardTransactionHostedService.Core.Services;

public interface IServiceLocator : IDisposable
{
  IServiceScope CreateScope();
  T Get<T>();
}
