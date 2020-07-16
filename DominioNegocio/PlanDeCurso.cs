using System;
using System.Collections.Generic;

namespace DominioNegocio
{
    public class PlanDeCurso
    {
        private int idPlanDeCurso;
        private String objetivoGeneral;
        private String periodo;
        private String referencias;
        private List<CriterioEvaluacion> listaDeCriterios;
        private List<Tema> listaDeTemas;
        private Curso curso;
        private String nombre;

        public int IdPlanDeCurso
        {
            get => idPlanDeCurso;
            set => idPlanDeCurso = value;
        }

        public String ObjetivoGeneral
        {
            get => objetivoGeneral;
            set => objetivoGeneral = value;
        }

        public String Periodo
        {
            get => periodo;
            set => periodo = value;
        }

        public String Referencias
        {
            get => referencias;
            set => referencias = value;
        }

        public List<CriterioEvaluacion> ListaDeCriterios
        {
            get => listaDeCriterios;
            set => listaDeCriterios = value;
        }

        public List<Tema> ListaDeTemas
        {
            get => listaDeTemas;
            set => listaDeTemas = value;
        }

        public Curso Curso
        {
            get => curso;
            set => curso = value;
        }   
        
        public String Nombre
        {
            get => nombre;
            set => nombre = value;
        }
    }
}
