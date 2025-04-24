using Microsoft.Extensions.DependencyInjection;
using ManagementAccountants.DataAccess.Entityes;
using ManagementAccountants.Interfaces;

namespace ManagementAccountants.DataAccess
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Accountant>, AccountantRepository>()
            .AddTransient<IRepository<Customer>, CustomerRepository>()
            .AddTransient<IRepository<Report>, ReportRepository>()
        ;
    }
}
