using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBankApi.Dtos;
using NBankApi.Services.CreateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Controllers.LoginAndCreatedClientsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrearClientController : ControllerBase
    {
        private readonly CreateClient _createClient;

        public CrearClientController(CreateClient createClient)
        {
            _createClient = createClient;
        }
        [HttpPost]

        public IActionResult CrearCliente(DtosNewClient dataCliente)
        {
            if (dataCliente == null)
            {
                return BadRequest("Datos no registrados");
            }
            else
            {
                string Respuesta = _createClient.createClient(dataCliente);
                switch (Respuesta)
                {
                    case "correo en uso":
                        return Conflict();

                    case "cliente ya existente":
                        return Conflict();

                    default:
                        return Ok(Respuesta);
                }
            }

        }
    }
}