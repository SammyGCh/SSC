using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Curso
    {
        private int idCurso;
        private string nombre;
        private string descripcion;
        private string nrc;
        private int status = 1;
        private string turno;
        private string seccion;
        private Docente impartidoPor;

        public int IdCurso
        {
            get => idCurso;
            set => idCurso = value;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public String Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }

        public String Nrc
        {
            get => nrc;
            set => nrc = value;
        }

        public int Status
        {
            get => status;
            set => status = value;
        }

        public String Turno
        {
            get => turno;
            set => turno = value;
        }

        public String Seccion
        {
            get => seccion;
            set => seccion = value;
        }

        public Docente ImpartidoPor
        {
            get => impartidoPor;
            set => impartidoPor = value;
        }
    }
}
