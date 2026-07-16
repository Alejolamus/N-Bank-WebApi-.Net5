using NBankApi.Dtos;
using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.CreditAppplications
{
    public class CreditValues
    {
        public decimal potenciaExpoNaturalDecimal(decimal baseExp, int expotente)
        {
            decimal resultado = 1m;
            for (int i = 0; i <= expotente; i++)
            {
                resultado = resultado * baseExp;
            };
            return resultado;
        }
        public decimal CuotaMetodoFrances(decimal creditoTotal, decimal interes, int numDeCuotas)
        {
            decimal potencia = potenciaExpoNaturalDecimal(1 + interes, numDeCuotas);
            decimal cuotaFrances = creditoTotal * ((interes * (potencia)) / (potencia - 1));
            return cuotaFrances;
        }
        public ValoresCoutaSeguroCredt CalculoValores(DtosSolicitudCredito data)
        {
            decimal SeguroMensual = (data.valueOfCredit / 1000000) * 13000;
            switch (data.frecuenciaCobro)
            {
                case Frecuencia.frecuencia.weekly:
                    decimal CuotaWeek = CuotaMetodoFrances(data.valueOfCredit,
                                                           0.006m,
                                                           data.numCuotas);
                    ValoresCoutaSeguroCredt costos1 = new ValoresCoutaSeguroCredt(SeguroMensual, CuotaWeek);
                    return costos1;
                case Frecuencia.frecuencia.biweekly:
                    decimal CuotaBieekly = CuotaMetodoFrances(data.valueOfCredit,
                                                           0.012m,
                                                           data.numCuotas);
                    ValoresCoutaSeguroCredt costos2 = new ValoresCoutaSeguroCredt(SeguroMensual, CuotaBieekly);
                    return costos2;
                default:
                    decimal CuotaMonthly = CuotaMetodoFrances(data.valueOfCredit,
                                                           0.024m,
                                                           data.numCuotas);
                    ValoresCoutaSeguroCredt costos3 = new ValoresCoutaSeguroCredt(SeguroMensual, CuotaMonthly);
                    return costos3;
            }
        }
    }
}