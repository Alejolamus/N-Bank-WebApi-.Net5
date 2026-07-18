using Microsoft.Extensions.DependencyInjection;
using NBankApi.Repositories.Add;
using NBankApi.Repositories.Consultas;
using NBankApi.Repositories.Update;
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
            //declaracion de servicios del Repositorio
            services.AddScoped<ConsultasMiembros>();
            services.AddScoped<ConsultasAliados>();
            services.AddScoped<ConsultasClientes>();
            services.AddScoped<AddClient>();
            services.AddScoped<ConsultasCreditos>();
            services.AddScoped<ConsultasDivisas>();
            services.AddScoped<AddInvoice>();
            services.AddScoped<AddFinancialStatus>();
            services.AddScoped<ConsultasEstadosFinancieros>();
            services.AddScoped<UpdateCredit>();
            services.AddScoped<UpdateFinancialStatus>();
            services.AddScoped<ConsultasFacturas>();
            services.AddScoped<AddCollect>();
            services.AddScoped<AddMuniciosCol>();
            services.AddScoped<ConsultaMunicipios>();
            services.AddScoped<AddCurrencys>();
            services.AddScoped < AddCredit > ();
            return services;
        }
    }
}
