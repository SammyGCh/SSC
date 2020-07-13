using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Tema
    {
        private int idTema;
        private String nombre;
        private String fechaInicio;
        private String fechaFinal;
        private String tecnicaDidactica;
        private String unidad;
        private List<Actividad> listaDeActividades;

        public int IdTema
        {
            get => idTema;
            set => idTema = value;
        }

        public String Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public String FechaInicio
        {
            get => fechaInicio;
            set => fechaInicio = value;
        }

        public String FechaFinal
        {
            get => fechaFinal;
            set => fechaFinal = value;
        }

        public String TecnicaDidactica
        {
            get => tecnicaDidactica;
            set => tecnicaDidactica = value;
        }

        public String Unidad
        {
            get => unidad;
            set => unidad = value;
        }

        public List<Actividad> ListaDeActividades
        {
            get => listaDeActividades;
            set => listaDeActividades = value;
        }
    }
}
