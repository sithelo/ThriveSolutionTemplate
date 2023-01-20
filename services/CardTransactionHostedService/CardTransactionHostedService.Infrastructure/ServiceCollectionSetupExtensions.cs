using CardTransactionHostedService.Core.Interfaces;
using CardTransactionHostedService.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardTransactionHostedService.Infrastructure;

public static class ServiceCollectionSetupExtensions
{
  public static void AddDbContext(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(
              configuration.GetConnectionString("DefaultConnection")));

  public static void AddRepositories(this IServiceCollection services) =>
      services.AddScoped<IRepository, TransactionRepository>();
  
  public static void AddUrlCheckingServices(this IServiceCollection services)
  {
      services.AddTransient<IHttpService, HttpService>();
  }
}
