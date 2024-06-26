using CurrentAccount.Contracts;
using CurrentAccount.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentAccount
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the domain implementations
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            return services;
        }
    }
}
