
﻿using AccesoADatos.BaseDeDatos;
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
        private const int STATUS_APROBADO = 1;
        private const int STATUS_PENDIENTE = 0;

        public SolicitudCambioDAO()
        {
            conexion = new ConexionBD();
        }

        public bool ExisteSolicitudPendiente(int idPlan)
        {
            bool existe = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT " +
                    "count(solicitudcambio.idsolicitudcambio) " +
                    "from solicitudcambio,plandecurso " +
                    "where solicitudcambio.idplandecurso = @idPlanDeCurso;"
                };

                query.Parameters.Add("@idPlanDeCurso", MySqlDbType.Int32, 11).Value = idPlan;

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetInt32(0) != 0)
                    {
                        existe = true;
                    }
                }

            }
            catch (MySqlException)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return existe;
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

         public List<SolicitudCambio> GetSolicitudesDeCambio()
        {
            List<SolicitudCambio> listaDeSolicitudes = new List<SolicitudCambio>();
            SolicitudCambio solicitudObtenida = new SolicitudCambio();
            PlanDeCursoDAO planDeCursoDAO = new PlanDeCursoDAO();

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT " +
                    "solicitudcambio.idsolicitudcambio, " +
                    "solicitudcambio.cambiosSolicitados, " +
                    "solicitudcambio.fecha, " +
                    "solicitudcambio.status, " +
                    "solicitudcambio.idplandecurso, " +
                    "solicitudcambio.comentarios, " +
                    "solicitudcambio.idOriginal " +
                    "FROM solicitudcambio;"
                };

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    solicitudObtenida = new SolicitudCambio
                    {
                        IdSolicitudCambio = reader.GetInt32(0),
                        CambiosSolicitados = reader.GetString(1),
                        Fecha = reader.GetString(2),
                        Status = reader.GetInt32(3),
                        PlanDeCurso = planDeCursoDAO.ObtenerPlanDeCurso(reader.GetInt32(4)),
                        PlanOriginal = planDeCursoDAO.ObtenerPlanDeCurso(reader.GetInt32(6))
                    };

                    if (!reader.IsDBNull(5))
                    {
                        solicitudObtenida.Comentarios = reader.GetString(5);
                    }

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
                    CommandText = "UPDATE solicitudcambio  SET comentarios=@comentarios, status=@status WHERE solicitudcambio.idsolicitudcambio = @idsolicitudcambio "
                };

                query.Parameters.Add("@comentarios", MySqlDbType.VarChar, 300).Value = solicitudAprobada.Comentarios;
                query.Parameters.Add("@status", MySqlDbType.Int32, 2).Value = STATUS_APROBADO;
                query.Parameters.Add("@idsolicitudcambio", MySqlDbType.Int32, 2).Value = solicitudAprobada.IdSolicitudCambio;

                query.ExecuteNonQuery();
                aprobado = true;
            }
            catch (MySqlException ex)
            {
                
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return aprobado;
        }

    }
}
