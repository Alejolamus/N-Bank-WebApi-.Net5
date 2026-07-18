using NBankApi.Dtos;
using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.CreditAppplications
{
    public class StarDatesCredit
    {
        //metodo para fechas de un credito
        public PrimerosDatosDeFechas CrearFechas(Frecuencia.frecuencia ciclo)
        {
            DateTime primerCorte = DateTime.Now;
            DateTime hoy = DateTime.Today;
            //determinacion de fechas por casos de frecuencia
            switch (ciclo)
            {
                case Frecuencia.frecuencia.weekly:
                    primerCorte = hoy.AddDays(7);
                    break;
                case Frecuencia.frecuencia.biweekly:
                    primerCorte = hoy.AddDays(14);
                    break;
                default:
                    primerCorte = hoy.AddMonths(1);
                    break;
            }
            PrimerosDatosDeFechas DtosInicialesTimes = new PrimerosDatosDeFechas(hoy, primerCorte, ciclo);
            return DtosInicialesTimes;
        }
    }
}