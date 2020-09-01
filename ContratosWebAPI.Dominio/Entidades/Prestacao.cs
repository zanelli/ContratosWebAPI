using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContratosWebAPI.Dominio.Entidades
{
    
    public class Prestacao : EntityBase
    {
        [Column(TypeName = "datetime")]
        public DateTime DataVencimento { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? DataPagamento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [NotMapped]
        public Status Status { get; set; }

        [ForeignKey("Contrato")]
        public int IdContrato { get; set; }
        
        public Contrato Contrato { get; set; }

        public void GetStatus()
        {
            if (this.DataPagamento.Equals(null))
            {
                if (this.DataVencimento >= DateTime.Now)
                {
                    this.Status = Status.Aberta;
                }
                else
                {
                    this.Status = Status.Atrasada;
                }
            }
            else
            {
                this.Status = Status.Baixada;
            }
        }
    }
}
