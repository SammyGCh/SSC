using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class CriterioEvaluacion
    {
        private int idCriterioEvaluacion;
        private String instrumento;
        private String nombre;
        private String porcentaje;
        private String unidad;
        private String fecha;

        public int IdCriterioEvaluacion
        {
            get => idCriterioEvaluacion;
            set => idCriterioEvaluacion = value;
        }

        public String Instrumento
        {
            get => instrumento;
            set => instrumento = value;
        }

        public String Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public String Porcentaje
        {
            get => porcentaje;
            set => porcentaje = value;
        }

        public String Unidad
        {
            get => unidad;
            set => unidad = value;
        }

        public String Fecha
        {
            get => fecha;
            set => fecha = value;
        }

    }
}
