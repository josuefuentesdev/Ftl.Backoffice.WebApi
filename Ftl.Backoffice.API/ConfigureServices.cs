using Ftl.Backoffice.API.Services;
using Ftl.Backoffice.Shared.Services;

namespace Ftl.Backoffice.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
