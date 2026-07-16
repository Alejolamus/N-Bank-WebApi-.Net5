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
        private readonly NewCreditRegistro _newCreditRegistro;
        public CreditRegisterController (NewCreditRegistro newCreditRegistro)
        {
            _newCreditRegistro = newCreditRegistro;
        }
        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult RegistrarCreditoDb(NewCreditData data)
        {
            _newCreditRegistro.CrearNewCredit(data);
            return Ok();
        }
    }
}
