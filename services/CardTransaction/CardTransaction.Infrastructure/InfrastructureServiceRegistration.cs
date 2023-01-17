using CardTransaction.Infrastructure.Data;
using CardTransaction.Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThriveAzureServiceBus;
using ThriveAzureServiceBus.Interfaces;
using ThriveShared.Interfaces;

namespace CardTransaction.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("CardTransactionConnectionString");
            services.AddDbContext<AppDbContext>((sp, options) => {
                    var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();
                   // if (interceptor != null) 
                        options.UseSqlServer(connectionString).AddInterceptors(interceptor);
                }
               );
            services.AddScoped(typeof(IRepository<>), typeof(CardTransactionRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(CardTransactionRepository<>));
            services.AddSingleton<IMessageBusFactory, AzureServiceBusFactory>();
            services.AddScoped<IMessagePublisher, IntegrationEventPublisher>();
        }
    }
}
