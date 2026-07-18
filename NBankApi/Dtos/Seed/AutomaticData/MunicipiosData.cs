using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Repositories.Add;
using NBankApi.Repositories.Consultas;

namespace NBankApi.Dtos.Seed.AutomaticData
{
    public class MunicipiosData
    {
        //inyeccion de dependencias
        private readonly AddMuniciosCol _addMunicipiosCol;
        private readonly ConsultaMunicipios _consultaMunicipios;
        public MunicipiosData(AddMuniciosCol addMuniciosCol, ConsultaMunicipios consultaMunicipios)
        {
            _addMunicipiosCol = addMuniciosCol;
            _consultaMunicipios = consultaMunicipios;
        }
        //metodo que consume repositorio para agregar los datos a bd leyendo un csv
        public void IngresarMuniciosCol()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            using var reader = new StreamReader("Dtos/Seed/Csv/ciudades.csv");
            using var csv = new CsvReader(reader, config);
            List<municipiosCol> registros = csv.GetRecords<municipiosCol>().ToList();
            foreach (var registro in registros)
            {
                _addMunicipiosCol.addMulcipios(registro.Departamento, registro.Municipio);
            }
        }
        //Metodo para garantizar el inicio de municipios en base de datos
        public void CargarMunicipios()
        {
            if (_consultaMunicipios.ExistMunicipios())
            {
                Console.WriteLine("Municipios ya registrados");
            }
            else
            {
                IngresarMuniciosCol();
                Console.WriteLine("Municipios cargados a db");
            }
        }
    }
}
