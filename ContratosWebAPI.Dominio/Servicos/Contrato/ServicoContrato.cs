using ContratosWebAPI.Dominio.Entidades;
using ContratosWebAPI.Dominio.Entidades.Interfaces;
using ContratosWebAPI.Dominio.Repositorio;
using PrestacaosWebAPI.Dominio.Servicos;
using System.Collections.Generic;

namespace ContratosWebAPI.Dominio.Servicos
{
    public class ServicoContrato : IServicoContrato
    {
        IRepositorioContrato RepositorioContrato;
        public ServicoContrato(IRepositorioContrato repositorioContrato)
        {
            RepositorioContrato = repositorioContrato;
        }
        public void Cadastrar(Contrato contrato)
        {
            contrato.Prestacoes = new List<Prestacao>();
            for (int i = 0; i < contrato.QuantidadeParcelas; i++)
            {
                Prestacao prestacao = new Prestacao
                {
                    DataVencimento = contrato.Data.AddMonths(i + 1),
                    //IdContrato = (int)contrato.Id,
                    Valor = (contrato.ValorFinanciado / contrato.QuantidadeParcelas)
                };
                prestacao.GetStatus();
                contrato.Prestacoes.Add(prestacao);
            }

            RepositorioContrato.Create(contrato);

        }

        public Contrato CarregarRegistro(int id)
        {
            return RepositorioContrato.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioContrato.Delete(id);
        }

        public IEnumerable<Contrato> Listagem()
        {
            return RepositorioContrato.Read();
        }
    }
}
