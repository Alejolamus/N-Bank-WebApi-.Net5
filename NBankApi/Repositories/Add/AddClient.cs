using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;
using NBankApi.Models.myEnums;

namespace NBankApi.Repositories.Add
{
    public class AddClient
    {
        private readonly DbContextNBank _db;

        public AddClient(DbContextNBank db)
        {
            _db = db;
        }
        public void AddCliente(
            string Nombre,
            int idCiudad,
            typedocument.typedocu tipo_documento,
            int documento_num,
            string hash,
            string correo,
            string Cel,
            string Tel)
        {

            {
                Clients cliente = new Clients()
                {
                    name = Nombre,
                    id_location = idCiudad,
                    document_type = tipo_documento,
                    document = documento_num,
                    password_hash = hash,
                    email = correo,
                    cellphone = Cel,
                    phone = Tel,
                };

                _db.Clientes.Add(cliente);

                _db.SaveChanges();
            }
        }
    }
}