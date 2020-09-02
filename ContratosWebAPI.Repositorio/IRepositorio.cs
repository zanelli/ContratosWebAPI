using System;
using System.Collections.Generic;
using System.Text;

namespace ContratosWebAPI.Repositorio
{
    public interface IRepositorio<TEntidade> where TEntidade: class
    {
        void Create(TEntidade Entidade);
        IEnumerable<TEntidade> Read();
        TEntidade Read(int id);
        void Update(TEntidade Entidade);
        void Delete(int id);
        
    }
}
