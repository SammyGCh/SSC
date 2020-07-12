using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Curso
    {
        private int idCurso;
        private String nombre;
        private String descripcion;
        private String nrc;
        private int status;
        private String turno;
        private String seccion;
        private int idDocente;
        private int idUsuario;

        public int IdCurso
        {
            get => idCurso;
            set => idCurso = value;
        }

        public String Nombre
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

        public int IdDocente
        {
            get => idDocente;
            set => idDocente = value;
        }

        public int IdUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }
    }
}
