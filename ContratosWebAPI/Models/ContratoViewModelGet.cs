using ContratosWebAPI.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContratosWebAPI.Models
{
    public class ContratoViewModelGet
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public int QuantidadeParcelas { get; set; }

        public decimal ValorFinanciado { get; set; }

        public IEnumerable<PrestacaoViewModel> Prestacoes { get; set; }


        //internal async Task<Contrato> SalvarAsync([FromServices] DataContext context)
        //{
        //    Contrato Contrato = new Contrato
        //    {
        //        Data = this.Data,
        //        QuantidadeParcelas = this.QuantidadeParcelas,
        //        ValorFinanciado = this.ValorFinanciado,
        //        Prestacoes = new List<Prestacao>()
        //    };

        //    for (int i = 0; i < this.QuantidadeParcelas; i++)
        //    {
        //        Prestacao prestacao = new Prestacao
        //        {
        //            DataVencimento = this.Data.AddMonths(i + 1),
        //            IdContrato = Contrato.Id,
        //            Valor = (this.ValorFinanciado / this.QuantidadeParcelas)
        //        };
        //        prestacao.GetStatus();
        //        Contrato.Prestacoes.Add(prestacao);
        //    }

        //    context.Contratos.Add(Contrato);
        //    await context.SaveChangesAsync();

        //    return Contrato;
        //}


    }
}
