using System;
using System.Collections.Generic;
using System.Text;
using AccesoADatos.Interfaces;
using DominioNegocio;
using MySql.Data.MySqlClient;
using AccesoADatos.BaseDeDatos;

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

        public List<SolicitudCambio> GetSolicitudesDeCambio()
        {
            List<SolicitudCambio> listaDeSolicitudes = new List<SolicitudCambio>();
            SolicitudCambio solicitudObtenida = new SolicitudCambio();
            CursoDAO cursoDAO = new CursoDAO();

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT * FROM solicitudcambio"
                };

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    solicitudObtenida = new SolicitudCambio
                    {
                        CambiosSolicitados = reader.GetString(0),
                        Fecha = reader.GetString(1),
                        Status = reader.GetInt32(2),
                        PlanDeCurso = reader.GetInt32(3)

                    };

                    listaDeSolicitudes.Add(solicitudObtenida);
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

            return listaDeSolicitudes;
        }

        public bool AprobarSolicitud(SolicitudCambio solicitudAprobada)
        {
            bool aprobado = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "UPDATE solicitudcambio  SET cambiosSolicitados=@cambiosSolicitados, status=@status WHERE solicitudcambio.idsolicitudcambio = @idsolicitudcambio "
                };

                query.Parameters.Add("@cambiosSolicitados", MySqlDbType.VarChar, 600).Value = solicitudAprobada.CambiosSolicitados;
                query.Parameters.Add("@status", MySqlDbType.Int32, 2).Value = solicitudAprobada.Status;
                query.Parameters.Add("@idsolicitudcambio", MySqlDbType.Int32, 2).Value = solicitudAprobada.IdSolicitudCambio;

                query.ExecuteNonQuery();
                aprobado = true;
            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return aprobado;
        }
    }
}
