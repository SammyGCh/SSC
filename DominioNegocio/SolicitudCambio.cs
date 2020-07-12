using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class SolicitudCambio
    {
        private int idSolicitudCambio;
        private String cambiosSolicitados;
        private String fecha;
        private int status;
        private int planDeCurso;

        public int IdSolicitudCambio
        {
            get => idSolicitudCambio;
            set => idSolicitudCambio = value;
        }

        public String CambiosSolicitados
        {
            get => cambiosSolicitados;
            set => cambiosSolicitados = value;
        }

        public String Fecha
        {
            get => fecha;
            set => fecha = value;
        }

        public int Status
        {
            get => status;
            set => status = value;
        }

        public int PlanDeCurso
        {
            get => planDeCurso;
            set => planDeCurso = value;
        }

    }
}
