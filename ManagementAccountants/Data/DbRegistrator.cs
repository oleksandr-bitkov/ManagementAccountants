using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManagementAccountants.DataAccess;
using ManagementAccountants.DataAccess.Context;

namespace ManagementAccountants.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<Test4DB>(opt =>
            {
                var type = Configuration["type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Незрозумілий тип БД");

                    default: throw new InvalidOperationException($"Тип підключення {type} не підтримується");

                    case "Postgres":
                        opt.UseNpgsql(Configuration.GetConnectionString(type));
                        break;
                }

            })
            .AddTransient<DbInitializer>()
            .AddRepositoriesInDb()
        ;
    }
}
