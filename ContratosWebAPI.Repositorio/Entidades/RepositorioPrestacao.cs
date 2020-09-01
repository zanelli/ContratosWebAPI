using ContratosWebAPI.Dominio.Entidades;
using ContratosWebAPI.Dominio.Repositorio;
using ContratosWebAPI.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestacaosWebAPI.Repositorio.Entidades
{
    public class RepositorioPrestacao : Repositorio<Prestacao>, IRepositorioPrestacao
    {
        public RepositorioPrestacao(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Prestacao> ReadContrato(int idContrato)
        {
            return DbSetContext.Where(x => x.IdContrato == idContrato).ToList();
        }
    }
}
