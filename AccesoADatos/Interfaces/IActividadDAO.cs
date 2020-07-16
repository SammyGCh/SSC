using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Interfaces
{
    public interface IActividadDAO
    {
        List<Actividad> ObtenerActividadesPorTema(int idTema);
    }
}
