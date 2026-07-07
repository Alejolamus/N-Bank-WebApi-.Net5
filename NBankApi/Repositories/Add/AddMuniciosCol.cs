using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DbContext;
using NBankApi.Models.DataBase;
namespace NBankApi.Repositories.Add
{
    public class AddMuniciosCol
    {
        private readonly DbContextNBank _db;
        public AddMuniciosCol(DbContextNBank db)
        {
            _db = db;
        }
        public void addMulcipios(string departamento, string Municipio)
        {
            MunicipalityCol municipio = new MunicipalityCol()
            {
                department = departamento,
                municipality = Municipio
            };
            _db.Municipios.Add(municipio);
            _db.SaveChanges();
        }
    }
}
