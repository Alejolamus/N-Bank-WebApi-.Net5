using NBankApi.Repositories.Consultas;
using NBankApi.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Dtos;

namespace NBankApi.Services.Login
{
    public class ValidarCredenciales
        //inyeccion de repositorio
    {
        private readonly ConsultasClientes _clientesDB;
        public ValidarCredenciales(ConsultasClientes clientesDb)
        {
            _clientesDB = clientesDb;
        }
        //intancia de comparacion de contraseña y hash
        public CompararPassword comparador = new CompararPassword();
        public LoginDateValue ValidarUserPass (string correo, string pass)
        {
            //busqueda de usuario por correo en caso de existir compara contraseña emitida y hash
            Clients usuario = _clientesDB.ClientePorCorreo(correo);
            if (usuario == null)
            {
                LoginDateValue respuesta = new LoginDateValue("usuario no existe",0,"");
                return respuesta;
            }
            else
            {
                bool esContraseñaValida = comparador.CompararContraseñaVsHash(usuario.password_hash, pass);
                if (esContraseñaValida)
                {
                    LoginDateValue respuesta = new LoginDateValue("Acceso Permitido", usuario.id, usuario.name);
                    return respuesta;
                }
                else
                {
                    LoginDateValue respuesta = new LoginDateValue("contraseña no valida", 0,"");
                    return respuesta;
                }
            }
        }
    }
}
