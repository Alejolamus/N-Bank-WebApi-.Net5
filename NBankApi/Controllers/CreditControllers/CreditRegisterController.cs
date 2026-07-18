using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBankApi.Dtos.creditoDataApp;
using NBankApi.Services.CreateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Controllers.CreditControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditRegisterController : ControllerBase
    {
        //inyeccion de dependencias
        private readonly NewCreditRegistro _newCreditRegistro;
        public CreditRegisterController (NewCreditRegistro newCreditRegistro)
        {
            _newCreditRegistro = newCreditRegistro;
        }
        //declaracion de protocolo http y autorizacion por token de cliente
        [Authorize(Roles = "Client")]
        [HttpPost]
        //controlador para registrar un credito
        public IActionResult RegistrarCreditoDb(NewCreditData data)
        {
            _newCreditRegistro.CrearNewCredit(data);
            return Ok();
        }
    }
}
