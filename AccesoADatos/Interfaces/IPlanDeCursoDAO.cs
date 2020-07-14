using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Interfaces
{
    public interface IPlanDeCursoDAO
    {
        List<PlanDeCurso> ObtenerPlanesPorCurso(int idCurso);

        bool CursoTienePlanes(int idCurso);
    }
}
