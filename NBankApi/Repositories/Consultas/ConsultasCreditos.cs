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
        //Lista todos los creditos asociados a la clave foranea id cliente    
        public List<Credits> ConsultaCreditosIdClient(int id_client)
        {
            return _db.Creditos.Where(x => x.user_id == id_client).ToList();
        }
        //retorna un credito por id del mismo
        public Credits ConsultaCreditoIdCredit(int idCredito)
        {
            Credits creditoPorId = _db.Creditos.FirstOrDefault(j => j.id == idCredito);
            return creditoPorId;
        }
        //Lista todos los id de creditos que tiene corte al momento de la consulta
        public List<int> CreditosConcorte(DateTime fecha)
        {
            List<int> idcreditos = _db.Creditos.Where(x => x.next_cutoff_date == fecha).Select(h => h.id).ToList();
            return idcreditos;
        }
    }
}
