using ContratosWebAPI.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContratosWebAPI.Models
{
    public class ContratoViewModelPut
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public int QuantidadeParcelas { get; set; }

        public decimal ValorFinanciado { get; set; }
    }
}
