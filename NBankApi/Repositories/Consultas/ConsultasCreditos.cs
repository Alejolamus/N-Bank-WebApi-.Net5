using NBankApi.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasCreditos
    {
        private readonly DbContextNBank _db;
        public ConsultasCreditos (DbContextNBank db)
        {
            _db = db;
        }
            
        public List<Credits> ConsultaCreditosIdClient(int id_client)
        {
            return _db.Creditos.Where(x => x.user_id == id_client).ToList();
        }
        public Credits ConsultaCreditoIdCredit(int idCredito)
        {
            Credits creditoPorId = _db.Creditos.FirstOrDefault(j => j.id == idCredito);
            return creditoPorId;
        }
        public List<int> CreditosConcorte(DateTime fecha)
        {
            List<int> idcreditos = _db.Creditos.Where(x => x.next_cutoff_date == fecha).Select(h => h.id).ToList();
            return idcreditos;
        }
    }
}
