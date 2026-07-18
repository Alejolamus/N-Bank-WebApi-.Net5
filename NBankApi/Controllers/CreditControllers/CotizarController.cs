using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Dtos.creditoDataApp;
using NBankApi.Services.CreditAppplications;
using Microsoft.AspNetCore.Authorization;

namespace NBankApi.Controllers.CreditControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CotizarController : ControllerBase
    {
        //inyeccion de dependencias
        private readonly CotizarCreditos _cotizarCreditos;
        public CotizarController (CotizarCreditos cotizarCreditos)
        {
            _cotizarCreditos = cotizarCreditos;
        }
        //declaracion de metodo http y autorizacion por token de cliente
        [Authorize(Roles = "Client")]
        [HttpPost]
        //controlador para obtener los valores asociados a una cotizacion
        public IActionResult cotizarCreditoControl(CotizarData data)
        {
            StarDatesCreditApp respuesta = _cotizarCreditos.valoresCotizacion(data);
            return Ok(respuesta);
        }
    }
}
