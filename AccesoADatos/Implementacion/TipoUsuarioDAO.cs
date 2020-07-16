using System;
using System.Collections.Generic;
using System.Text;
using AccesoADatos.BaseDeDatos;
using AccesoADatos.Interfaces;
using DominioNegocio;
using MySql.Data.MySqlClient;

namespace AccesoADatos.Implementacion
{
    public class TipoUsuarioDAO : ITipoUsuarioDAO
    {
        private TipoUsuario tipoUsuario;
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private MySqlDataReader reader;

        public TipoUsuarioDAO()
        {
            conexion = new ConexionBD();
        }

        public TipoUsuario ObtenerTipoUsuarioPorId(int idTipoUsuario)
        {
            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT * FROM tipousuario WHERE idtipousuario = @idtipousuario"
                };

                query.Parameters.Add("@idtipousuario", MySqlDbType.Int32, 2).Value = idTipoUsuario;

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    tipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
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

            return tipoUsuario;
        }
    }
}
