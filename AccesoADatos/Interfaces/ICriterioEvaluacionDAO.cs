using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Interfaces
{
    public interface ICriterioEvaluacionDAO
    {
        List<CriterioEvaluacion> ObtenerCriteriosPorPlan(int idPlanDeCurso);
    }
}
