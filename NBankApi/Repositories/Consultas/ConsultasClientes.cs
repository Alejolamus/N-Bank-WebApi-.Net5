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
        //busca cliente por medio de correo, retorna el mismo
        public Clients ClientePorCorreo(string correo)
        {
            Clients cliente = _db.Clientes.FirstOrDefault(x => x.email == correo);
            return cliente;
        }
        //metodo de valor booleano que busca la existencia de un cliente por medio de tipo y numero de documento
        public bool ClientePorDocumento(typedocument.typedocu tipo, int numDocumento)
        {
            bool cliente = _db.Clientes.Any(x => x.document_type == tipo && x.document == numDocumento);
            return cliente;
        }
        //busca cliente por id y lo retorna
        public Clients ClientePorId(int idClient)
        {
            Clients cliente = _db.Clientes.FirstOrDefault(x => x.id == idClient);
            return cliente;
        }
    }
}
