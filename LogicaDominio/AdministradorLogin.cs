using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;
using AccesoADatos.Implementacion;
using MySql.Data.MySqlClient;

namespace LogicaDominio
{
    public static class AdministradorLogin
    {
        private const int EXISTE_CUENTA = 1;
        public const int TIPO_SECRETARIA = 1;
        public const int TIPO_COORDINADOR = 2;
        public const int TIPO_DIRECTOR = 3;
        public const int TIPO_DOCENTE = 4;

        public static bool ExisteCuenta(string username, string password)
        {
            bool existe = false;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                CuentaDAO cuentaDao = new CuentaDAO();
                int resultadoDeConsulta;

                try
                {
                    resultadoDeConsulta = cuentaDao.ExisteCuenta(username, password);
                }
                catch (MySqlException)
                {
                    throw;
                }

                if (resultadoDeConsulta == EXISTE_CUENTA)
                {
                    existe = true;
                }
            }

            return existe;
        }

        public static Usuario BuscarUsuarioIngresado(Cuenta cuenta)
        {
            Usuario usuarioIngresado;
            UsuarioDAO usuarioDao = new UsuarioDAO();

            try
            {
                usuarioIngresado = usuarioDao.ObtenerUsuarioPorCuenta(cuenta);
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }

            return usuarioIngresado;
        }
    }
}
