using AccesoADatos.Interfaces;
using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using AccesoADatos.BaseDeDatos;

namespace AccesoADatos.Implementacion
{
    public class PlanDeCursoDAO : IPlanDeCursoDAO
    {
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private MySqlDataReader reader;

        public PlanDeCursoDAO()
        {
            conexion = new ConexionBD();
        }

        public bool CursoTienePlanes(int idCurso)
        {
            List<PlanDeCurso> listaDePlanes = new List<PlanDeCurso>();
            PlanDeCurso planObtenido;
            bool hayplanes = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT " +
                    "plandecurso.idplandecurso, " +
                    "plandecurso.objetivoGeneral, " +
                    "plandecurso.periodo, " +
                    "plandecurso.referencias " +
                    "FROM plandecurso where plandecurso.idcurso = @idCurso;"
                };

                MySqlParameter curso = new MySqlParameter("@idCurso", MySqlDbType.Int32, 11)
                {
                    Value = idCurso
                };

                query.Parameters.Add(curso);

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    planObtenido = new PlanDeCurso
                    {
                        IdPlanDeCurso = reader.GetInt32(0),
                        ObjetivoGeneral = reader.GetString(1),
                        Periodo = reader.GetString(2),
                        Referencias = reader.GetString(3)
                    };

                    listaDePlanes.Add(planObtenido);
                }

                hayplanes = (listaDePlanes.Count > 0);
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conexion.CerrarConexion();
            }

            return hayplanes;
        }

        public List<PlanDeCurso> ObtenerPlanesPorCurso(int idCurso)
        {
            List<PlanDeCurso> listaDePlanes = new List<PlanDeCurso>();
            PlanDeCurso planObtenido;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT " +
                    "plandecurso.idplandecurso, " +
                    "plandecurso.objetivoGeneral, " +
                    "plandecurso.periodo, " +
                    "plandecurso.referencias " +
                    "FROM plandecurso where plandecurso.idcurso = @idCurso;"
                };

                MySqlParameter curso = new MySqlParameter("@idCurso", MySqlDbType.Int32, 11)
                {
                    Value = idCurso
                };

                query.Parameters.Add(curso);

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    planObtenido = new PlanDeCurso
                    {
                        IdPlanDeCurso = reader.GetInt32(0),
                        ObjetivoGeneral = reader.GetString(1),
                        Periodo = reader.GetString(2),
                        Referencias = reader.GetString(3)
                    };

                    listaDePlanes.Add(planObtenido);
                }
            }
            catch (MySqlException ex)
            {

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conexion.CerrarConexion();
            }

            return listaDePlanes;
        }

        public PlanDeCurso ObtenerPlanDeCurso(int idPlanDeCurso)
        {
            PlanDeCurso planObtenido = null;
            CursoDAO cursoDAO = new CursoDAO();

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT " +
                    "plandecurso.objetivoGeneral, " +
                    "plandecurso.periodo, " +
                    "plandecurso.referencias, " +
                    "plandecurso.idcurso, " +
                    "plandecurso.nombre " +
                    "FROM plandecurso WHERE plandecurso.idplandecurso = @idPlanDeCurso;"
                };

                MySqlParameter idPlan = new MySqlParameter("@idPlanDeCurso", MySqlDbType.Int32, 11)
                {
                    Value = idPlanDeCurso
                };

                query.Parameters.Add(idPlan);

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    planObtenido = new PlanDeCurso
                    {
                        ObjetivoGeneral = reader.GetString(0),
                        Periodo = reader.GetString(1),
                        Referencias = reader.GetString(2),
                        Curso = cursoDAO.GetCursoPorID(reader.GetInt32(3)),
                        Nombre = reader.GetString(4)
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

            return planObtenido;
        }
    }
}
