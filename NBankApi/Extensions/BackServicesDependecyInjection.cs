using Microsoft.Extensions.DependencyInjection;
using NBankApi.Services.CreateData;
using NBankApi.Services.JwtServices;
using NBankApi.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Extensions
{
    public static class BackServicesDependecyInjection
    {
        public static IServiceCollection AddBackedServices(this IServiceCollection services)
        {
            services.AddScoped<CreateClient>();
            services.AddScoped<CreatedToken>();
            services.AddScoped<ValidarToken>();
            services.AddScoped<ValidarCredenciales>();
            return services;

        }
    }
}
}
