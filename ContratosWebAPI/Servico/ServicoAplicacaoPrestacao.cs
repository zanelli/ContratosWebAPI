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
    public class ServicoAplicacaoPrestacao : IServicoAplicacaoPrestacao
    {
        private IServicoPrestacao ServicoPrestacao;
        public ServicoAplicacaoPrestacao(IServicoPrestacao servicoPrestacao)
        {
            ServicoPrestacao = servicoPrestacao;

        }

        public void Cadastrar(PrestacaoViewModel prestacao)
        {
            throw new NotImplementedException();
        }

        public PrestacaoViewModel CarregarRegistro(int codigoPrestacao)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrestacaoViewModel> Listagem(int idContrato)
        {
            throw new NotImplementedException();
        }

    }
}
