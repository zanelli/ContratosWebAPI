using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ContratosWebAPI.Models
{
    public class ContratoViewModelPost
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de parcelas deve ser maior que 0")]
        public int QuantidadeParcelas { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor financiado deve ser maior que R$1,00")]
        public decimal ValorFinanciado { get; set; }
    }
}
