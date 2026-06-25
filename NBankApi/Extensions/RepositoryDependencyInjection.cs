using Microsoft.Extensions.DependencyInjection;
using NBankApi.Repositories.Add;
using NBankApi.Repositories.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Extensions
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ConsultasMiembros>();
            services.AddScoped<ConsultasAliados>();
            services.AddScoped<ConsultasClientes>();
            services.AddScoped<AddClient>();
            return services;
        }
    }
}
