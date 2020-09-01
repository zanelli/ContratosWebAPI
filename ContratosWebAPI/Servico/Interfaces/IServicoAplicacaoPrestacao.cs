using ContratosWebAPI.Models;
using System.Collections.Generic;

namespace ContratosWebAPI.Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoPrestacao
    {
        IEnumerable<PrestacaoViewModel> Listagem(int idContrato);

        PrestacaoViewModel CarregarRegistro(int codigoPrestacao);

        void Cadastrar(PrestacaoViewModel prestacao);

        void Excluir(int id);
    }
}
