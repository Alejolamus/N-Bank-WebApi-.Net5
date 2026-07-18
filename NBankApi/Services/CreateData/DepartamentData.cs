using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Repositories.Consultas;
using NBankApi.Dtos;
using NBankApi.Models.DataBase;

namespace NBankApi.Services.CreateData
{
    public class DepartamentData
        //inyeccion de repositorio
    {
        private readonly ConsultaMunicipios _consultaMunicipios;
        public DepartamentData (ConsultaMunicipios consultaMunicipios)
        {
            _consultaMunicipios = consultaMunicipios;
        }
        //metodo para generar datos para el controlador
        public List<DepartamentoDto> municipiosColombia()
        {
            List<MunicipalityCol> dataMuniciosDb = _consultaMunicipios.listMunicipios();
            List<DepartamentoDto> municipiosPorDepartamento = new List<DepartamentoDto>();
            //ciclo para crear lista con objetos {string(departamento) y lista de municios de dicho
            foreach (MunicipalityCol municipio in dataMuniciosDb)
            {
                DepartamentoDto departamentoEnLista = municipiosPorDepartamento.FirstOrDefault(h => h.name == municipio.department);
                MunicipioDto mucipioData = new MunicipioDto();
                if (departamentoEnLista!=null)
                {
                    mucipioData.idMunicipio = municipio.id;
                    mucipioData.municipioName = municipio.municipality;
                    departamentoEnLista.municipios.Add(mucipioData);
                }
                else
                {
                    DepartamentoDto newDepartamet = new DepartamentoDto();
                    newDepartamet.name = municipio.department;
                    List<MunicipioDto> municipiosDelDepartamento = new List<MunicipioDto>();
                    mucipioData.idMunicipio = municipio.id;
                    mucipioData.municipioName = municipio.municipality;
                    municipiosDelDepartamento.Add(mucipioData);
                    newDepartamet.municipios = municipiosDelDepartamento;
                    municipiosPorDepartamento.Add(newDepartamet);
                }
            }

            return municipiosPorDepartamento;
        }
    }
}
