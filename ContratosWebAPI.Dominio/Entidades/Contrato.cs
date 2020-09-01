using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContratosWebAPI.Dominio.Entidades
{
    public class Contrato :EntityBase
    {
        public DateTime Data { get; set; }
        
        public int QuantidadeParcelas { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorFinanciado { get; set; }

        
        public List<Prestacao> Prestacoes { get; set; }
    }
}
