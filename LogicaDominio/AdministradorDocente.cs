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
        private const int NO_EXISTE = 0;

        public ResultadoRegistro RegistrarNuevaCuentaDocente(Cuenta cuentaDocente, Docente nuevoDocente)
        {
            ResultadoRegistro registrado = ResultadoRegistro.NoRegistrado;

            if (nuevoDocente != null)
            {
                DocenteDAO administradorDocente = new DocenteDAO();

                if (administradorDocente.ExisteDocente(nuevoDocente) == NO_EXISTE)
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
                        bool docenteRegistrado;

                        try
                        {
                            cuentaDocente.Pertenece = administradorUsuario.ObtenerUltimoUsuarioRegistrado();

                            administradorCuenta.GuardarCuenta(cuentaDocente);

                            nuevoDocente.IdUsuario = cuentaDocente.Pertenece.IdUsuario;


                            docenteRegistrado = administradorDocente.GuardarDocente(nuevoDocente);
                        }
                        catch (MySqlException)
                        {
                            throw;
                        }

                        if (docenteRegistrado)
                        {
                            registrado = ResultadoRegistro.Registrado;
                        }
                    }
                }
                else
                {
                    registrado = ResultadoRegistro.YaExiste;
                }
            }

            return registrado;
        }
    }
}
