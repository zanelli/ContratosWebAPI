using ContratosWebAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratosWebAPI.Repositorio
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Prestacao> Prestacoes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        
    }
}
