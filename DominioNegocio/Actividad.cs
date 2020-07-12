using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Actividad
    {
        private int idActividad;
        private String nombre;
        private String puntaje;
        private String fechaEntrega;

        public int IdActividad
        {
            get => idActividad;
            set => idActividad = value;
        }

        public String Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public String Puntaje
        {
            get => puntaje;
            set => puntaje = value;
        }

        public String FechaEntrega
        {
            get => fechaEntrega;
            set => fechaEntrega = value;
        }

    }
}
