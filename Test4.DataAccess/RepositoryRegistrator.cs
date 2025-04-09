using Microsoft.Extensions.DependencyInjection;
using Test4.DataAccess.Entityes;
using Test4.Interfaces;

namespace Test4.DataAccess
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
