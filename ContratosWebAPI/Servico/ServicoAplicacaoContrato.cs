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
            ServicoPrestacao.ExcluirPorContrato(id);
            ServicoContrato.Excluir(id);
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

        public void Atualizar(ContratoViewModelPut Entidade)
        {
            ServicoContrato.Atualizar(MapeiaViewModelPutParaEntidade(Entidade));

            // TODO: Atualiza as prestações
            //decimal SaldoQuitado = ServicoPrestacao.Listagem(Entidade.Id).Where(x => x.DataPagamento != null).Sum(x => x.Valor);
            //DateTime DataUltimoPagamento = (DateTime)ServicoPrestacao.Listagem(Entidade.Id).Where(x => x.DataPagamento != null).Max(x => x.DataPagamento);
            //if(DataUltimoPagamento == null)
            //{
            //    DataUltimoPagamento = Entidade.Data.AddMonths(1);
            //}

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

        private Contrato MapeiaViewModelPutParaEntidade(ContratoViewModelPut contratoGet)
        {
            if (contratoGet == null) return new Contrato();

            Contrato contrato = new Contrato()
            {
                Id = contratoGet.Id,
                Data = contratoGet.Data,
                QuantidadeParcelas = contratoGet.QuantidadeParcelas,
                ValorFinanciado = contratoGet.ValorFinanciado,
            };

            return contrato;
        }
    }
}
