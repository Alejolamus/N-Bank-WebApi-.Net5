using Microsoft.Extensions.DependencyInjection;
using NBankApi.Services.CreateData;
using NBankApi.Services.Invoices;
using NBankApi.Services.JwtServices;
using NBankApi.Services.Login;
using NBankApi.Services.MailServices;
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
            services.AddScoped<InvoiceValuesInDB>();
            services.AddScoped<ModelGenerator>();
            services.AddScoped<PdfAndEmailForidCre>();
            services.AddScoped<DailyInvoices>();
            return services;
        }
    }
}

