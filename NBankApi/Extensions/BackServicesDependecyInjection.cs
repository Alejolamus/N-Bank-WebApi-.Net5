using Microsoft.Extensions.DependencyInjection;
using NBankApi.Dtos.Seed.AutomaticData;
using NBankApi.Models.InvoiceModels;
using NBankApi.Services.CreateData;
using NBankApi.Services.CreditAppplications;
using NBankApi.Services.Invoices;
using NBankApi.Services.Invoices.QuestPdfCode;
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
            //declaracion de servicios de servicios-back
            services.AddScoped<CreateClient>();
            services.AddScoped<CreatedToken>();
            services.AddScoped<ValidarToken>();
            services.AddScoped<ValidarCredenciales>();
            services.AddScoped<InvoiceValuesInDB>();
            services.AddScoped<ModelGenerator>();
            services.AddScoped<PdfAndEmailForidCre>();
            services.AddScoped<DailyInvoices>();
            services.AddScoped<CreditRisk>();
            services.AddScoped<ModelGenerator>();
            services.AddScoped<InvoiceValuesInDB>();
            services.AddScoped<MunicipiosData>();
            services.AddScoped<CurrencyData>();
            services.AddScoped<DepartamentData>();
            services.AddScoped<CotizarCreditos>();
            services.AddScoped<currencysDataS>();
            services.AddScoped<NewCreditRegistro>();
            return services;
        }
    }
}

