using CardTransaction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThriveShared;
using ThriveShared.Interfaces;

namespace CardTransaction.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("CardTransactionConnectionString");
            services.AddDbContext<AppDbContext>((sp, options) => {
                    var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();
                    if (interceptor != null) options.UseSqlServer(connectionString).AddInterceptors(interceptor);
                }
               );
            services.AddScoped(typeof(IRepository<>), typeof(CardTransactionRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(CardTransactionRepository<>));
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            return services;
        }
    }
}
