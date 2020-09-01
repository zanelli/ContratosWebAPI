using ContratosWebAPI.Dominio.Entidades;
using ContratosWebAPI.Dominio.Entidades.Interfaces;
using ContratosWebAPI.Dominio.Repositorio;
using System.Collections.Generic;

namespace PrestacaosWebAPI.Dominio.Servicos
{
    public class ServicoPrestacao : IServicoPrestacao
    {
        IRepositorioPrestacao RepositorioPrestacao;
        public ServicoPrestacao(IRepositorioPrestacao repositorioPrestacao)
        {
            RepositorioPrestacao = repositorioPrestacao;
        }
        public void Cadastrar(Prestacao prestacao)
        {
            RepositorioPrestacao.Create(prestacao);
        }

        public Prestacao CarregarRegistro(int id)
        {
            return RepositorioPrestacao.Read(id);
        }
        
        public void Excluir(int id)
        {
            RepositorioPrestacao.Delete(id);
        }

        public IEnumerable<Prestacao> Listagem(int idContraco)
        {
            IEnumerable<Prestacao> prestacoes = RepositorioPrestacao.ReadContrato(idContraco);

            foreach (var item in prestacoes)
            {
                item.GetStatus();
            }
            return prestacoes;
        }

        public IEnumerable<Prestacao> Listagem()
        {
            throw new System.NotImplementedException();
        }
    }
}
