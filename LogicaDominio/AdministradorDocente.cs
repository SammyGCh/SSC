using System;
using System.Collections.Generic;
using System.Text;
using AccesoADatos.Implementacion;
using DominioNegocio;
using MySql.Data.MySqlClient;

namespace LogicaDominio
{
    public class AdministradorDocente
    {
        public bool RegistrarNuevaCuentaDocente(Cuenta cuentaDocente, Docente nuevoDocente)
        {
            bool registrado = false;

            if (nuevoDocente != null)
            {
                UsuarioDAO administradorUsuario = new UsuarioDAO();
                bool usuarioGuardado;

                try
                {
                    usuarioGuardado = administradorUsuario.GuardarUsuario(nuevoDocente);
                }
                catch (MySqlException)
                {
                    throw;
                }

                if (usuarioGuardado)
                {
                    CuentaDAO administradorCuenta = new CuentaDAO();

                    try
                    {
                        cuentaDocente.Pertenece = administradorUsuario.ObtenerUltimoUsuarioRegistrado();

                        administradorCuenta.GuardarCuenta(cuentaDocente);

                        nuevoDocente.IdUsuario = cuentaDocente.Pertenece.IdUsuario;

                        DocenteDAO administradorDocente = new DocenteDAO();
                        registrado = administradorDocente.GuardarDocente(nuevoDocente);
                    }
                    catch (MySqlException)
                    {
                        throw;
                    }
                }
            }

            return registrado;
        }
    }
}
