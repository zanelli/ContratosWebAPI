using ContratosWebAPI.Aplicacao.Servico.Interfaces;
using ContratosWebAPI.Dominio.Entidades;
using ContratosWebAPI.Dominio.Entidades.Interfaces;
using ContratosWebAPI.Models;
using PrestacaosWebAPI.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratosWebAPI.Aplicacao.Servico
{
    public class ServicoAplicacaoContrato : IServicoAplicacaoContrato
    {
        private IServicoContrato ServicoContrato;
        private IServicoPrestacao ServicoPrestacao;
        public ServicoAplicacaoContrato(IServicoContrato servicoContrato, IServicoPrestacao servicoPrestacao)
        {
            ServicoContrato = servicoContrato;
            ServicoPrestacao = servicoPrestacao;

        }

        public void Cadastrar(ContratoViewModelPost contrato)
        {
            ServicoContrato.Cadastrar(MapeiaViewModelPostParaEntidade(contrato));
        }

        public ContratoViewModelGet CarregarRegistro(int codigoContrato)
        {
            var contratoEntidade = ServicoContrato.CarregarRegistro(codigoContrato);

            return MapeiaEntidadeParaViewModelGet(contratoEntidade);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContratoViewModelGet> Listagem()
        {
            var listaContratos = ServicoContrato.Listagem();
            List<ContratoViewModelGet> listaContrato = new List<ContratoViewModelGet>();
            foreach (var item in listaContratos)
            {
                listaContrato.Add(MapeiaEntidadeParaViewModelGet(item));
            }
            return listaContrato;
        }


        internal ContratoViewModelGet MapeiaEntidadeParaViewModelGet(Contrato contratoEntidade)
        {
            if (contratoEntidade == null) return new ContratoViewModelGet();

            ContratoViewModelGet contrato = new ContratoViewModelGet()
            {
                Id = (int)contratoEntidade.Id,
                Data = contratoEntidade.Data,
                QuantidadeParcelas = contratoEntidade.QuantidadeParcelas,
                ValorFinanciado = contratoEntidade.ValorFinanciado,
                Prestacoes = MapeiaListaEntidadeParaViewModel(ServicoPrestacao.Listagem((int)contratoEntidade.Id))
            };

            return contrato;
        }

        private IEnumerable<PrestacaoViewModel> MapeiaListaEntidadeParaViewModel(IEnumerable<Prestacao> listaPrestacaoEntidade)
        {
            List<PrestacaoViewModel> lista = new List<PrestacaoViewModel>();
            foreach (var item in listaPrestacaoEntidade)
            {
                lista.Add(MapeiaEntidadeParaViewModel(item));
            }
            return lista;
        }

        internal PrestacaoViewModel MapeiaEntidadeParaViewModel(Prestacao prestacaoEntidade)
        {
            if (prestacaoEntidade == null) return new PrestacaoViewModel();

            PrestacaoViewModel prestacao = new PrestacaoViewModel()
            {
                Id = (int)prestacaoEntidade.Id,
                DataPagamento = prestacaoEntidade.DataPagamento,
                DataVencimento = prestacaoEntidade.DataVencimento,
                Status = prestacaoEntidade.Status,
                Valor = prestacaoEntidade.Valor

            };

            return prestacao;
        }

        internal Contrato MapeiaViewModelPostParaEntidade(ContratoViewModelPost contratoPost)
        {
            if (contratoPost == null) return new Contrato();

            Contrato contrato = new Contrato()
            {
                Data = contratoPost.Data,
                QuantidadeParcelas = contratoPost.QuantidadeParcelas,
                ValorFinanciado = contratoPost.ValorFinanciado
            };

            return contrato;
        }
    }
}
