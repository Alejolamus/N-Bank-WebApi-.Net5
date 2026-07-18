using NBankApi.Dtos;
using NBankApi.Interfaces;
using NBankApi.Services.PasswordServices;
using NBankApi.Models.DataBase;
using NBankApi.Repositories.Add;
using NBankApi.Repositories.Consultas;

namespace NBankApi.Services.CreateData
{
    public class CreateClient : ICreateClient
    {
        //inyeccion de clases del repositorio
        private readonly ConsultasClientes _clientesDB;

        private readonly AddClient _clientesAdd;
        public CreateClient(ConsultasClientes clientesDb, AddClient clientesADD)
        {
            _clientesAdd = clientesADD;
            _clientesDB = clientesDb;
        }
        //metodo para crear un cliente nuevo en db con los atriburos del objeto cliente
        public string createClient(DtosNewClient cliente)
        {
            //lamado la clase para encriptar y desencriptar contraseñas
            EncryptAndDecrypt encryptor = new EncryptAndDecrypt();
            //verificaicon de correo y documento para un cliente en base de datos
            bool exitenciaPorDocument = _clientesDB.ClientePorDocumento(cliente.documentType, cliente.document);
            Clients existenciaCorreo = _clientesDB.ClientePorCorreo(cliente.email);
            if (!exitenciaPorDocument)
            {
                if (existenciaCorreo == null)
                {
                    // implementacion de encriptador y repositorio de agregar cliente
                    string hashPass = encryptor.Encrypt(cliente.password);
                    _clientesAdd.AddCliente(cliente.name,
                                             cliente.idLocation,
                                             cliente.documentType,
                                             cliente.document,
                                             hashPass,
                                             cliente.email,
                                             cliente.cellphone,
                                             cliente.phone);
                    return "cliente creado";
                }
                else
                {
                    return "correo en uso";
                }
            }
            else
            {
                return "cliente ya existente";
            }
        }
    }
}