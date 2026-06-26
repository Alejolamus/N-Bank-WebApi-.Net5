using NBankApi.Dtos;
using NBankApi.Models.DataBase;
using NBankApi.Repositories.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.CreditAppplications
{
    public class CreditRisk
    {
        private readonly ConsultasCreditos _consultasCreditos;
        public CreditRisk (ConsultasCreditos consultasCreditos)
        {
            _consultasCreditos = consultasCreditos;
        }
        public bool CreditApproval(DtosProfiles profile, DtosSolicitudCredito application)
        {
            CreditValues valuesCreditMod = new CreditValues();
            ValoresCoutaSeguroCredt valuesCredit = valuesCreditMod.CalculoValores(application);
            decimal collection = valuesCredit.cuota + valuesCredit.seguro;
            decimal cuotaMaxima = profile.minGanadoMensual * 0.35m;
            decimal dineroDispoblieClient = profile.minGanadoMensual - profile.gastos;
            List<Credits> credits = _consultasCreditos.ConsultaCreditosIdClient(profile.idClient);
            if (credits.Count() <= 1 && collection <= cuotaMaxima && dineroDispoblieClient > collection)
            {
                if (credits.Count() == 0)
                {
                    return true;
                }
                else if (credits[0].overdue_balance == 0m)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}