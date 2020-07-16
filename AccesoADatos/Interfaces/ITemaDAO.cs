using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Interfaces
{
    public interface ITemaDAO
    {
        List<Tema> ObtenerTemasPorPlan(int idPlan);
    }
}
