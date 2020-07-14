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
        Usuario ObtenerUsuarioPorCuenta(Cuenta cuenta);
        bool GuardarUsuario(Usuario usuario);
    }
}
