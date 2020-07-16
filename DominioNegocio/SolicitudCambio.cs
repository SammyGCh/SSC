using System;

namespace DominioNegocio
{
    public class SolicitudCambio
    {
        private int idSolicitudCambio;
        private String cambiosSolicitados;
        private String fecha;
        private  int status;
        private PlanDeCurso planDeCurso;
        private String comentarios;
        private PlanDeCurso planOriginal;

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

        public PlanDeCurso PlanDeCurso
        {
            get => planDeCurso;
            set => planDeCurso = value;
        }

        public String Comentarios
        {
            get => comentarios;
            set => comentarios = value;
        }

        public PlanDeCurso PlanOriginal
        {
            get => planOriginal;
            set => planOriginal = value;
        }
    }
}
