using ContratosWebAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContratosWebAPI.Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade>
        where TEntidade : EntityBase, new()
    {
        protected DbContext Db;
        protected DbSet<TEntidade> DbSetContext;
        public Repositorio(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<TEntidade>();
        }
        
        public void Create(TEntidade Entidade)
        {
            DbSetContext.Add(Entidade);
            Db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entidade = new TEntidade() { Id = id };
            DbSetContext.Attach(entidade);
            DbSetContext.Remove(entidade);
            Db.SaveChanges();

        }

        public virtual TEntidade Read(int id)
        {
            return DbSetContext.Where(x => x.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<TEntidade> Read()
        {
            return DbSetContext.AsNoTracking().ToList();
        }

        public void Update(TEntidade Entidade)
        {
            DbSetContext.Attach(Entidade);
            Db.Entry(Entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
