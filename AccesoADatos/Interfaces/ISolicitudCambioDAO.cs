using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Interfaces
{
    public interface ISolicitudCambioDAO
    {
        bool RegistrarSolicitud(SolicitudCambio nuevaSolicitud);
    }
}
