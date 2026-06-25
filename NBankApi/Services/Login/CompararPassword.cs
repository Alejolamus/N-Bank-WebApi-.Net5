using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Services.PasswordServices;

namespace NBankApi.Services.Login
{
    public class CompararPassword
    {
        public bool CompararContraseñaVsHash(string Hash, string Contraseña)
        {
            EncryptAndDecrypt moduloEncontrictador = new EncryptAndDecrypt();
            string HassDesifrada = moduloEncontrictador.Decrypt(Hash);
            bool esCorrecta = HassDesifrada == Contraseña;
            return esCorrecta;
        }
    }
}
