using AccesoADatos.BaseDeDatos;
using AccesoADatos.Interfaces;
using DominioNegocio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Implementacion
{
    public class SolicitudCambioDAO : ISolicitudCambioDAO
    {
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private MySqlDataReader reader;

        public SolicitudCambioDAO()
        {
            conexion = new ConexionBD();
        }

        public bool RegistrarSolicitud(SolicitudCambio nuevaSolicitud)
        {
            bool guardado = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "INSERT INTO " +
                    "solicitudcambio(solicitudcambio.cambiosSolicitados, solicitudcambio.fecha, solicitudcambio.status, solicitudcambio.idplandecurso) " +
                    "VALUES (@cambiosSolicitados, @fecha, @status, @idPlanDeCurso)"
                };

                query.Parameters.Add("@cambiosSolicitados", MySqlDbType.VarChar, 600).Value = nuevaSolicitud.CambiosSolicitados;
                query.Parameters.Add("@fecha", MySqlDbType.VarChar, 40).Value = nuevaSolicitud.Fecha;
                query.Parameters.Add("@status", MySqlDbType.Int32, 11).Value = nuevaSolicitud.Status;
                query.Parameters.Add("@idPlanDeCurso", MySqlDbType.Int32, 11).Value = nuevaSolicitud.PlanDeCurso;

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
