using System;
using System.Collections.Generic;
using System.Text;

namespace ContratosWebAPI.Dominio.Entidades
{
    /// <summary>
    /// Enun contendo o status da prestação
    /// </summary>
    public enum Status
    {
        Aberta = 1,
        Baixada = 2,
        Atrasada = 3
    }
}