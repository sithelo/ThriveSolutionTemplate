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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CardTransactionConnectionString")));
            services.AddScoped(typeof(IRepository<>), typeof(CardTransactionRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(CardTransactionRepository<>));
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            return services;
        }
    }
}
