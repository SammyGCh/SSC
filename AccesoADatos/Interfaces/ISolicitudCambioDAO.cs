using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Interfaces
{
    public interface ISolicitudCambioDAO
    {
        bool AprobarSolicitud(SolicitudCambio nuevaSolicitud);

        bool RegistrarSolicitud(SolicitudCambio nuevaSolicitud);

        bool ExisteSolicitudPendiente(int idPlan);
    }
}
