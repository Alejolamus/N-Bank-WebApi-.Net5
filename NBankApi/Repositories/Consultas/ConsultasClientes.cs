using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;
using System.Linq;
using NBankApi.Models.myEnums;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasClientes
    {
        private readonly DbContextNBank _db;

        public ConsultasClientes (DbContextNBank db)
        {
            _db = db;
        }
        public Clients ClientePorCorreo(string correo)
        {
            {
                Clients cliente = _db.Clientes.FirstOrDefault(x => x.email == correo);
                return cliente;
            }
        }
        public bool ClientePorDocumento(typedocument.typedocu tipo, int numDocumento)
        {
            {
                bool cliente = _db.Clientes.Any(x => x.document_type == tipo && x.document == numDocumento);
                return cliente;
            }
        }
        public Clients ClientePorId(int idClient)
        {
            {
                Clients cliente = _db.Clientes.FirstOrDefault(x => x.id == idClient);
                return cliente;
            }
        }
    }
}
