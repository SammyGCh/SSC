using System;
using System.Collections.Generic;
using System.Text;
using AccesoADatos.Interfaces;
using DominioNegocio;
using MySql.Data.MySqlClient;
using AccesoADatos.BaseDeDatos;

namespace AccesoADatos.Implementacion
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private Usuario usuario;
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private MySqlDataReader reader;
        private const int TIPO_DOCENTE = 4;

        public UsuarioDAO()
        {
            conexion = new ConexionBD();
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT * FROM usuario WHERE idusuario = @idusuario"
                };

                query.Parameters.Add("@idusuario", MySqlDbType.Int32, 2).Value = idUsuario;

                reader = query.ExecuteReader();

                TipoUsuarioDAO administradorTipoUsuario = new TipoUsuarioDAO();

                while (reader.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Genero = reader.GetString(3),
                        CorreoElectronico = reader.GetString(4),
                        Pertenece = administradorTipoUsuario.ObtenerTipoUsuarioPorId(reader.GetInt32(5))
                    };
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                conexion.CerrarConexion();
            }
            return usuario;
        }

        public int ObtenerIdUsuarioPorNombre(string nombre)
        {
            int idUsuario = 0;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT idusuario, cuenta.idusuario, cuenta.status FROM usuario, cuenta WHERE nombres = @nombres AND " +
                    "idusuario = cuenta.idusuario " +
                    "AND cuenta.status = 1"
                };

                query.Parameters.Add("@nombres", MySqlDbType.Int32, 2).Value = nombre;

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    idUsuario = reader.GetInt32(0);
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                conexion.CerrarConexion();
            }

            return idUsuario;
        }

        public Usuario ObtenerUltimoUsuarioRegistrado()
        {
            usuario = null;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT MAX(idusuario) FROM usuario"
                };

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = reader.GetInt32(0)
                    };
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                conexion.CerrarConexion();
            }

            return usuario;
        }

        public bool GuardarUsuario(Usuario usuario)
        {
            bool guardado = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "INSERT INTO usuario (nombres, apellidos, genero, correoElectronico, idtipousuario) VALUES " +
                    "(@nombres, @apellidos, @genero, @correoElectronico, @idtipousuario)"
                };

                query.Parameters.Add("@nombres", MySqlDbType.VarChar, 70).Value = usuario.Nombres;
                query.Parameters.Add("@apellidos", MySqlDbType.VarChar, 80).Value = usuario.Apellidos;
                query.Parameters.Add("@genero", MySqlDbType.VarChar, 9).Value = usuario.Genero;
                query.Parameters.Add("@correoElectronico", MySqlDbType.VarChar, 70).Value = usuario.CorreoElectronico;
                query.Parameters.Add("@idtipousuario", MySqlDbType.Int32, 2).Value = TIPO_DOCENTE;

                query.ExecuteNonQuery();
                guardado = true;
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return guardado;
        }
    }
}
