using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class PrimerosDatosDeFechas
    {
        public DateTime starDate { get; set; }
        public DateTime nextDate { get; set; }
        public Frecuencia.frecuencia periodos { get; set; }
        public PrimerosDatosDeFechas(DateTime inicio, DateTime siguiente, Frecuencia.frecuencia diasEntreFacturas)
        {
            starDate = inicio;
            nextDate = siguiente;
            periodos = diasEntreFacturas;
        }
    }
}