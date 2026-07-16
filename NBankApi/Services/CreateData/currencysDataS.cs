using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Repositories.Consultas;
using NBankApi.Models.DataBase;
using NBankApi.Dtos.Dataform;

namespace NBankApi.Services.CreateData
{
    public class currencysDataS
    {
        private readonly ConsultasDivisas _consultasDivisas;
        public currencysDataS (ConsultasDivisas consultasDivisas)
        {
            _consultasDivisas = consultasDivisas;
        }
        public List<currencyDataForm> dataMonedas()
        {
            List<currencyDataForm> data = new List<currencyDataForm>();
            List<Currencys> monedasBd = _consultasDivisas.DivisasEnBase();
            foreach (Currencys moneda in monedasBd)
            {
                currencyDataForm dataMoneda = new currencyDataForm()
                {
                    idMoneda = moneda.id,
                    pais = moneda.country,
                    nombre = moneda.currency_name,
                    symbolo = moneda.symbol
                };
                data.Add(dataMoneda);               
            }
            data = data.OrderBy(x => x.pais).ToList();
            return data;
        }
    }
}
