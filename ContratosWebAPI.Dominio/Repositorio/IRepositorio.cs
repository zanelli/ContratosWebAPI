using System;
using System.Collections.Generic;
using System.Text;

namespace ContratosWebAPI.Dominio.Repositorio
{
    public interface IRepositorio<TEntidade> where TEntidade: class
    {
        void Create(TEntidade Entity);
        TEntidade Read(int id);
        void Update(TEntidade Entidade);
        void Delete(int id);
        IEnumerable<TEntidade> Read();
    }
}
