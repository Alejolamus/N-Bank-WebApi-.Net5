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
        //inyeccion de repositorio
        private readonly ConsultasDivisas _consultasDivisas;
        public currencysDataS (ConsultasDivisas consultasDivisas)
        {
            _consultasDivisas = consultasDivisas;
        }
        //metodo para generar objeto con datos de monedas para el controlador
        public List<currencyDataForm> dataMonedas()
        {
            //definir lista para retorno y lista de objetos currencys en base de datos por medio del repositorio
            List<currencyDataForm> data = new List<currencyDataForm>();
            List<Currencys> monedasBd = _consultasDivisas.DivisasEnBase();
            //ciclo para filtrar los datos  de la lsta de monedas
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
            //ordenar lista de monedas para la presentacion en front
            data = data.OrderBy(x => x.pais).ToList();
            return data;
        }
    }
}
