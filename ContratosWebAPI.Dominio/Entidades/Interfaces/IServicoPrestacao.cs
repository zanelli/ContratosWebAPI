using ContratosWebAPI.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratosWebAPI.Dominio.Entidades.Interfaces
{
    public interface IServicoPrestacao : IServicoCrud<Prestacao>
    {
        IEnumerable<Prestacao> Listagem(int idContrato);

    }
}
