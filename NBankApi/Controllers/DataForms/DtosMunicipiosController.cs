using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBankApi.Services.CreateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Dtos;

namespace NBankApi.Controllers.DataForms
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtosMunicipiosController : ControllerBase
    {
        //inyeccion de dependencias
        private readonly DepartamentData _departamentData;
        public DtosMunicipiosController(DepartamentData departamentData)
        {
            _departamentData = departamentData;
        }
        //declaracion de metodo http
        [HttpGet]
        //Metodo para entregar municipios, endpoint publico
        public IActionResult DepartamentosYMunicios()
        {
            List<DepartamentoDto> departametosYmunicipios = _departamentData.municipiosColombia();
            return Ok(departametosYmunicipios);
        }
    }
}
