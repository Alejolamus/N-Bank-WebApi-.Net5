using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Dtos.creditoDataApp;

namespace NBankApi.Services.CreditAppplications
{
    public class CotizarCreditos
    {   //intacicias para valores y fechas de credito
        public CreditValues valores = new CreditValues();
        public StarDatesCredit fechas = new StarDatesCredit();
        //inyeccion de servicio que determina el riesgo para un credito
        private readonly CreditRisk _riesgo;
        public CotizarCreditos (CreditRisk riesgo)
        {
            _riesgo = riesgo;
        }
        //metodo para la cotizaciond e credito y sus valores
        public StarDatesCreditApp valoresCotizacion(CotizarData data)
        {
            StarDatesCreditApp valuesDeCotizacion = new StarDatesCreditApp()
            {
                fechaInicio = DateTime.Today,
                fechaPrimerPago = (fechas.CrearFechas(data.dataCredit.frecuenciaCobro)).nextDate,
                valorCuota=valores.CalculoValores(data.dataCredit).cuota,
                valueRiesgo=_riesgo.CreditApproval(data.perfil,data.dataCredit)
            };
            return valuesDeCotizacion;
        }
    }
}
