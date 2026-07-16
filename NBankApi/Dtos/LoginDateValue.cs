using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class LoginDateValue
    {
        public string msn { get; set; }
        public int idUser { get; set; }
        public string nombre { get; set; }
        public LoginDateValue(string Correo, int idUsuario, string Nombre)
        {
            msn = Correo;
            idUser = idUsuario;
            nombre = Nombre;
        }
    }
}
