using NBankApi.Models.DataBase;
using NBankApi.Models.PaymentModels;
using NBankApi.Repositories.Add;
using NBankApi.Repositories.Consultas;
using NBankApi.Repositories.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.RecibirPagos
{
    public class RegisterMethods
    {
        private readonly ConsultasFacturas _consultasFacturas;
        private readonly ConsultasEstadosFinancieros _consultasEstadosFinancieros;
        private readonly UpdateFinancialStatus _updateFinancialStatus;
        private readonly AddCollect _addCollect;
        private readonly UpdateCredit _updateCredit;
        public RegisterMethods (ConsultasFacturas consultasFacturas,
                                ConsultasEstadosFinancieros consultasEstadosFinancieros,
                                UpdateFinancialStatus updateFinancialStatus,
                                AddCollect addCollect,
                                UpdateCredit updateCredit)
        {
            _consultasFacturas = consultasFacturas;
            _consultasEstadosFinancieros = consultasEstadosFinancieros;
            _updateFinancialStatus = updateFinancialStatus;
            _addCollect = addCollect;
            _updateCredit = updateCredit;
        }
        public void ResgistrarPagoUnico(ModelUnique model)
        {
            Invoice invoice = _consultasFacturas.FacturaParticularNum(model.numInvoice);
            FinancialStatus estado = _consultasEstadosFinancieros.EstadoFactura(invoice.id);
            _addCollect.AddRecaudo(invoice.id, model.value, model.colletDate, model.type, model.idParther, model.authCode);
            if (model.value >= estado.seguro)
            {
                _updateFinancialStatus.UpdateValues(invoice.id, estado.seguro, model.value - estado.seguro);
            }
            else
            {
                _updateFinancialStatus.UpdateValues(invoice.id, model.value, 0);
            }
            _updateCredit.UpdateOutadingBalance(invoice.id_credit, model.value);
        }
        public void ResgistrarPagoDual(ModelDual model)
        {
            Invoice invoice = _consultasFacturas.FacturaParticularNum(model.numInvoice);
            FinancialStatus estado = _consultasEstadosFinancieros.EstadoFactura(invoice.id);
            _addCollect.AddRecaudo(invoice.id, model.valueCapital + model.valueInvoice, model.colletDate, model.type, model.idParther, model.authCode);
            if (model.valueInvoice >= estado.seguro)
            {
                _updateFinancialStatus.UpdateValues(invoice.id, estado.seguro, model.valueInvoice - estado.seguro);
            }
            else
            {
                _updateFinancialStatus.UpdateValues(invoice.id, model.valueInvoice, 0);
            }
            _updateCredit.UpdateOutadingBalance(invoice.id_credit, (model.valueCapital+model.valueInvoice));
        }
    }
}
