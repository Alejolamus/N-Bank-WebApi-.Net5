using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using NBankApi.Services.Login;
using NBankApi.Dtos;
using Microsoft.Extensions.Configuration;
using NBankApi.Models.JwtTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NBankApi.Services.JwtServices;

namespace NBankApi.Controllers.LoginAndCreatedClientsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginClientController : ControllerBase
    {
        //inyeccion de dependencias
        private readonly ValidarCredenciales _validarIngreso;
        private readonly CreatedToken _crearToken;
        public LoginClientController(ValidarCredenciales validarPass, CreatedToken crearToken)
        {
            _validarIngreso = validarPass;
            _crearToken = crearToken;
        }
        //Declaracion de metodo http
        [HttpPost("Login")]
        //metodo para crear validar login de cliente y entregarle token JWT
        public IActionResult CrearTokenDeIngreso(DataLogin dataCliente)
        {
            LoginDateValue resultadoLogin = _validarIngreso.ValidarUserPass(dataCliente.email, dataCliente.password);
            switch (resultadoLogin.msn)
            {
                case "usuario no existe":
                    return NotFound();
                case "contraseña no valida":
                    return Unauthorized();
                default:
                    string tokenStr = _crearToken.CrearToken(resultadoLogin.idUser.ToString(), "Client", resultadoLogin.nombre);
                    return Ok(tokenStr);
            }
        }
    }
}