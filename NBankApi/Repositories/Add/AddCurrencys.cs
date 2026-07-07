using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Add
{
    public class AddCurrencys
    {
        private readonly DbContextNBank _db;
        public AddCurrencys (DbContextNBank db)
        {
            _db = db;
        }
        public void addMonedas(string IsoAlpha2, string IsoAlpha3, string pais,
                               string CodigoMoneda, string NombreMoneda, string simbolo)
        {
            Currencys moneda = new Currencys()
            {
                iso_alpha_2 = IsoAlpha2,
                iso_alpha_3 = IsoAlpha3,
                country = pais,
                currency_code = CodigoMoneda,
                currency_name = NombreMoneda,
                symbol = simbolo
            };
            _db.Divisas.Add(moneda);
            _db.SaveChanges();
        }
    }
}
