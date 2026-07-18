using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Services.PasswordServices;

namespace NBankApi.Services.Login
{
    public class CompararPassword
    {
        //metodo que indica si la contraseña enviada coincide con el hash decodificado
        public bool CompararContraseñaVsHash(string Hash, string Contraseña)
        {
            //intacia de clase de encriptacion e implementacion
            EncryptAndDecrypt moduloEncontrictador = new EncryptAndDecrypt();
            string HassDesifrada = moduloEncontrictador.Decrypt(Hash);
            bool esCorrecta = HassDesifrada == Contraseña;
            return esCorrecta;
        }
    }
}
