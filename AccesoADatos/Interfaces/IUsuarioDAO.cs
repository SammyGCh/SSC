using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;

namespace AccesoADatos.Interfaces
{
    public interface IUsuarioDAO
    {
        Usuario ObtenerUsuarioPorId(int idUsuario);
        int ObtenerIdUsuarioPorNombre(string nombre);
        Usuario ObtenerUltimoUsuarioRegistrado();
        bool GuardarUsuario(Usuario usuario);
    }
}
