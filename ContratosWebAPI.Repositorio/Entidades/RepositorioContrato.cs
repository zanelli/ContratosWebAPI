using ContratosWebAPI.Dominio.Entidades;
using ContratosWebAPI.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratosWebAPI.Repositorio.Entidades
{
    public class RepositorioContrato : Repositorio<Contrato>, IRepositorioContrato
    {
        public RepositorioContrato(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
