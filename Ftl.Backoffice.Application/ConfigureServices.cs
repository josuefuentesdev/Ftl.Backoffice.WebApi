using Ftl.Backoffice.Application.Contact;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ftl.Backoffice.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IContactService, ContactService>();
            return services;
        }
    }
}
