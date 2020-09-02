using ContratosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratosWebAPI.Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoContrato
    {
        IEnumerable<ContratoViewModelGet> Listagem();

        ContratoViewModelGet CarregarRegistro(int codigoContrato);

        void Cadastrar(ContratoViewModelPost contrato);

        void Atualizar(ContratoViewModelPut Entidade);

        void Excluir(int id);
    }
}
