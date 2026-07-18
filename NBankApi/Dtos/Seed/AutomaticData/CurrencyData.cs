using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Repositories.Add;
using CsvHelper;
using NBankApi.Repositories.Consultas;

namespace NBankApi.Dtos.Seed.AutomaticData
{
    public class CurrencyData
    {
        //inyeccion de dependencias
        private readonly AddCurrencys _addCurrencys;
        private readonly ConsultasDivisas _consultaDivisas;
        public CurrencyData(AddCurrencys addCurrencys, ConsultasDivisas consultaDivisas)
        {
            _addCurrencys = addCurrencys;
            _consultaDivisas = consultaDivisas;
        }
        //metodo que consume repositorio para agregar los datos a bd leyendo un csv
        public void IngresarMonedas()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            using var reader = new StreamReader("Dtos/Seed/Csv/Monedas.csv");
            using var csv = new CsvReader(reader, config);
            List<DatosMonedasCsv> registros = csv.GetRecords<DatosMonedasCsv>().ToList();
            foreach (var registro in registros)
            {
                _addCurrencys.addMonedas(registro.isoAlpha2,
                                         registro.isoAplaha3,
                                         registro.country,
                                         registro.currencyCode,
                                         registro.currencyName,
                                         registro.Symbol);
            }
        }
        //Metodo para garantizar el inicio de monedas en base de datos
        public void CargarMonedas()
        {
            if (_consultaDivisas.ExistMonedas())
            {
                Console.WriteLine("monedas en base de datos");
            }
            else
            {
                IngresarMonedas();
                Console.WriteLine("Monedas agregadas");
            }
        }

    }
}
    
        




