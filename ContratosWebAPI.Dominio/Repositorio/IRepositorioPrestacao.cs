using ContratosWebAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratosWebAPI.Dominio.Repositorio
{
    public interface IRepositorioPrestacao : IRepositorio<Prestacao>
    {
        new IEnumerable<Prestacao> ReadContrato(int idContrato);
    }
}
