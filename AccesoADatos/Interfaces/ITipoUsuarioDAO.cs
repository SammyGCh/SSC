using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;

namespace AccesoADatos.Interfaces
{
    public interface ITipoUsuarioDAO
    {
        TipoUsuario ObtenerTipoUsuarioPorId(int idTipoUsuario);
    }
}
