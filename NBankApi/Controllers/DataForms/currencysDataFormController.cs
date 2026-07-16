using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Services.CreateData;
using NBankApi.Dtos.Dataform;
using Microsoft.AspNetCore.Authorization;

namespace NBankApi.Controllers.DataForms
{
    [Route("api/[controller]")]
    [ApiController]
    public class currencysDataFormController : ControllerBase
    {
        private readonly currencysDataS _currencysData;
        public currencysDataFormController(currencysDataS currencysData)
        {
            _currencysData = currencysData;
        }
        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult currencyDataForForm()
        {
            List<currencyDataForm> data = _currencysData.dataMonedas();
            return Ok(data);
        }
    }
}
