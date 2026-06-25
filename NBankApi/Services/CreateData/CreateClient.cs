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
        private readonly ConsultasClientes _clientesDB;

        private readonly AddClient _clientesAdd;
        public CreateClient(ConsultasClientes clientesDb, AddClient clientesADD)
        {
            _clientesAdd = clientesADD;
            _clientesDB = clientesDb;
        }
        public string createClient(DtosNewClient cliente)
        {
            EncryptAndDecrypt encryptor = new EncryptAndDecrypt();
            
            bool exitenciaPorDocument = _clientesDB.ClientePorDocumento(cliente.documentType, cliente.document);
            Clients existenciaCorreo = _clientesDB.ClientePorCorreo(cliente.email);
            if (!exitenciaPorDocument)
            {
                if (existenciaCorreo == null)
                {
                    string hashPass = encryptor.Encrypt(cliente.passwarod);
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