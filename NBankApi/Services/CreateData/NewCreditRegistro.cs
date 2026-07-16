using NBankApi.Dtos.creditoDataApp;
using NBankApi.Repositories.Add;
using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.CreateData
{
    public class NewCreditRegistro
    {
        private readonly AddCredit _addCredit;
        public NewCreditRegistro (AddCredit addCredit)
        {
            _addCredit = addCredit;
        }
        public void CrearNewCredit(NewCreditData data)
        {
            Frecuencia.frecuencia frecuenciaCobro = new Frecuencia.frecuencia();
            EstadoDeAprovacion.estado EstadoCredito = new EstadoDeAprovacion.estado();
            switch (data.enumFrecuenciaFront)
            {
                case 0:
                    frecuenciaCobro = Frecuencia.frecuencia.weekly;
                    break;
                case 1:
                    frecuenciaCobro = Frecuencia.frecuencia.biweekly;
                    break;
                default:
                    frecuenciaCobro = Frecuencia.frecuencia.monthly;
                    break;
            }
            if (data.enumAprovacion == 0)
            {
                EstadoCredito = EstadoDeAprovacion.estado.approved;
            }else { EstadoCredito = EstadoDeAprovacion.estado.not_approved; }
            _addCredit.AddCredito(data.idCliente,
                                  DateTime.Today,
                                  frecuenciaCobro,
                                  data.numDeCuotras,
                                  data.primerPago,
                                  EstadoCredito,
                                  data.valorCredito,
                                  0,
                                  0,
                                  DateTime.Today.AddYears(303),
                                  data.moneda);
        }
    }
}
