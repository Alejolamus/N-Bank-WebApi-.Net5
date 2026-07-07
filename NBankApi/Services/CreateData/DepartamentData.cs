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
    {
        private readonly ConsultaMunicipios _consultaMunicipios;
        public DepartamentData (ConsultaMunicipios consultaMunicipios)
        {
            _consultaMunicipios = consultaMunicipios;
        }
        public List<DepartamentoDto> municipiosColombia()
        {
            List<MunicipalityCol> dataMuniciosDb = _consultaMunicipios.listMunicipios();
            List<DepartamentoDto> municipiosPorDepartamento = new List<DepartamentoDto>();

            foreach (MunicipalityCol municipio in dataMuniciosDb)
            {
                DepartamentoDto departamentoEnLista = municipiosPorDepartamento.FirstOrDefault(h => h.name == municipio.department);

                if (departamentoEnLista!=null)
                {
                    departamentoEnLista.municipios.Add(municipio.municipality);
                }
                else
                {
                    DepartamentoDto newDepartamet = new DepartamentoDto();
                    newDepartamet.name = municipio.department;
                    List<string> municipiosDelDepartamento = new List<string>();
                    municipiosDelDepartamento.Add(municipio.municipality);
                    newDepartamet.municipios = municipiosDelDepartamento;
                    municipiosPorDepartamento.Add(newDepartamet);
                }
            }

            return municipiosPorDepartamento;
        }
    }
}
