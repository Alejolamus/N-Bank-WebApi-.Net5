using Microsoft.Extensions.DependencyInjection;
using NBankApi.Controllers.DataForms;
using NBankApi.Controllers.LoginAndCreatedClientsControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Extensions
{
    public static class ControllersDependencyInjection
    {
        public static IServiceCollection ControllersInyection(this IServiceCollection services)
        {
            services.AddScoped<CrearClientController>();
            services.AddScoped<LoginClientController>();
            services.AddScoped<DtosMunicipiosController>();
            return services;
        }
    }
}
