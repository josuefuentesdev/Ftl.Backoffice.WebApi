using FluentValidation;
using Ftl.Backoffice.Application.Contact;
using Ftl.Backoffice.Application.ContactEvent;
using Ftl.Backoffice.Application.Order;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ftl.Backoffice.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactEventService, ContactEventService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
