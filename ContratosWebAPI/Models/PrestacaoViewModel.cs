using ContratosWebAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContratosWebAPI.Models
{
    public class PrestacaoViewModel
    {
        public int Id { get; set; }
        
        public DateTime DataVencimento { get; set; }
        
        public DateTime? DataPagamento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        
        public Status Status { get; set; }

        //public int IdContrato { get; set; }
        
        //public Contrato Contrato { get; set; }
    }
}
