using Library.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
        string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
        string DB_PASSWORD = Environment.GetEnvironmentVariable("SA_PASSWORD");

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            var con = $"Data source={DB_HOST};" +
                            $"Initial Catalog={DB_NAME};" +
                            $"User ID=SA;Password={DB_PASSWORD};" +
                            $"TrustServerCertificate=True;";
            options.UseSqlServer(con);
        });
        return services;
    }
}
