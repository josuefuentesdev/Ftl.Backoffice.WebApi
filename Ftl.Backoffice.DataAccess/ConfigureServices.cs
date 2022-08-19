using Ftl.Backoffice.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ftl.Backoffice.DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<FtlDbContext>(options =>
                    options.UseInMemoryDatabase("FtlDb"));
            }
            else
            {
                var prodConnection = Environment.GetEnvironmentVariable("fictiteldb");
                if (prodConnection != null)
                {
                    services.AddDbContext<FtlDbContext>(options =>
                        options.UseSqlServer(prodConnection));
                } else
                {
                    services.AddDbContext<FtlDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                }
            }
            return services;
        }
    }
}
