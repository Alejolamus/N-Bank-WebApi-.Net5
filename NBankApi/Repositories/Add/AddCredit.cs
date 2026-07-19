using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;
using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Repositories.Add
{
    public class AddCredit
    {
        private readonly DbContextNBank _db;
        public AddCredit (DbContextNBank db)
        {
            _db = db;
        }
        //ingresa registro a la tabla de creditos, sin retorno
        public void AddCredito(int id_usuario,
                               DateTime fecha_inicio,
                               Frecuencia.frecuencia frecuencia_pagos,
                               int numero_cuotas,
                               DateTime fecha_corte,
                               EstadoDeAprovacion.estado aprovacion,
                               decimal valor,
                               decimal saldo_pendiente,
                               decimal saldo_mora,
                               DateTime fecha_inicio_mora,
                               int id_moneda)
        {
            Credits credito = new Credits()
            {
                user_id = id_usuario,
                star_date = fecha_inicio,
                payment_frequency = frecuencia_pagos,
                installment_count = numero_cuotas,
                next_cutoff_date = fecha_corte,
                state = aprovacion,
                value = valor,
                outstanding_balance = saldo_pendiente,
                overdue_balance = saldo_mora,
                past_due_date = fecha_inicio_mora,
                id_currency = id_moneda
            };
            _db.Creditos.Add(credito);
            _db.SaveChanges();
        }
    }
}
