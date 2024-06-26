using CurrentAccount.Contracts;
using CurrentAccount.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentAccount.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds infrastructure implementations
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
            return services;
        }
    }
}
