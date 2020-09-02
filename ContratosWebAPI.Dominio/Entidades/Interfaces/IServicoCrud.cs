using System.Collections.Generic;

namespace ContratosWebAPI.Dominio.Interfaces
{
    public interface IServicoCrud<TEntidade>
        where TEntidade: class
    {
        IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade categoria);
        void Atualizar(TEntidade categoria);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}