using System;
using System.Collections.Generic;
using System.Text;
using AccesoADatos.Interfaces;
using DominioNegocio;
using MySql.Data.MySqlClient;
using AccesoADatos.BaseDeDatos;

namespace AccesoADatos.Implementacion
{
    public class CursoDAO : ICursoDAO
    {
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private MySqlDataReader reader;

        public CursoDAO()
        {
            conexion = new ConexionBD();
        }

        public int ExisteCurso(Curso curso)
        {
            int existe = 0;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT COUNT(curso.nrc), curso.turno, curso.seccion FROM curso WHERE curso.nrc = @nrc AND " +
                    "curso.turno = @turno AND curso.seccion = @seccion"
                };

                query.Parameters.Add("@nrc", MySqlDbType.VarChar, 10).Value = curso.Nrc;
                query.Parameters.Add("@turno", MySqlDbType.VarChar, 10).Value = curso.Turno;
                query.Parameters.Add("@seccion", MySqlDbType.VarChar, 45).Value = curso.Seccion;

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    existe = reader.GetInt32(0);
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

            return existe;
        }

        public bool GuardarCurso(Curso curso)
        {
            bool guardado = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "INSERT INTO curso (nombre, descripcion, nrc, status, turno, seccion, iddocente, idusuario) VALUES " +
                    "(@nombre, @descripcion, @nrc, @status, @turno, @seccion, @iddocente, @idusuario)"
                };

                query.Parameters.Add("@nombre", MySqlDbType.VarChar, 70).Value = curso.Nombre;
                query.Parameters.Add("@descripcion", MySqlDbType.VarChar, 500).Value = curso.Descripcion;
                query.Parameters.Add("@nrc", MySqlDbType.VarChar, 10).Value = curso.Nrc;
                query.Parameters.Add("@status", MySqlDbType.Int32, 2).Value = curso.Status;
                query.Parameters.Add("@turno", MySqlDbType.VarChar, 10).Value = curso.Turno;
                query.Parameters.Add("@seccion", MySqlDbType.VarChar, 45).Value = curso.Seccion;
                query.Parameters.Add("@iddocente", MySqlDbType.Int32, 2).Value = curso.ImpartidoPor.IdDocente;
                query.Parameters.Add("@idusuario", MySqlDbType.Int32, 2).Value = curso.ImpartidoPor.IdUsuario;

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

        public List<Curso> GetCursosDeProfesor(int idDocente)
        {
            List<Curso> listaDeCursos = new List<Curso>();
            Curso cursoObtenido;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT * FROM curso WHERE iddocente = @idDocente;"
                };

                MySqlParameter personal = new MySqlParameter("@idDocente", MySqlDbType.Int32, 11)
                {
                    Value = idDocente
                };

                query.Parameters.Add(personal);

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    cursoObtenido = new Curso
                    {
                        IdCurso = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Nrc = reader.GetString(3),
                        Status = reader.GetInt32(4),
                        Turno = reader.GetString(5),
                        Seccion = reader.GetString(6)
                    };

                    listaDeCursos.Add(cursoObtenido);
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

            return listaDeCursos;
        }

        public bool ProfesorTieneCursos(int idDocente)
        {
            List<Curso> listaDeCursos = new List<Curso>();
            Curso cursoObtenido;
            bool hayCursos = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT curso.idCurso, curso.nombre, curso.Descripcion, curso.Turno FROM curso WHERE curso.iddocente = @idDocente;"
                };

                MySqlParameter personal = new MySqlParameter("@idDocente", MySqlDbType.Int32, 11)
                {
                    Value = idDocente
                };

                query.Parameters.Add(personal);

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    cursoObtenido = new Curso
                    {
                        IdCurso = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Turno = reader.GetString(3)
                    };

                    listaDeCursos.Add(cursoObtenido);
                }

                hayCursos = (listaDeCursos.Count > 0);
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

            return hayCursos;
        }

        public Curso GetCursoPorID(int idCurso)
        {
            Curso cursoObtenido = null;
            DocenteDAO docenteDAO = new DocenteDAO();

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT " +
                    "curso.idcurso, " +
                    "curso.nombre, " +
                    "curso.descripcion, " +
                    "curso.nrc, " +
                    "curso.status, " +
                    "curso.turno, " +
                    "curso.seccion, " +
                    "curso.idUsuario " +
                    "FROM curso " +
                    "WHERE curso.idcurso = @idCurso;"
                };

                MySqlParameter curso = new MySqlParameter("@idCurso", MySqlDbType.Int32, 11)
                {
                    Value = idCurso
                };

                query.Parameters.Add(curso);

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    cursoObtenido = new Curso
                    {
                        IdCurso = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Nrc = reader.GetString(3),
                        Status = reader.GetInt32(4),
                        Turno = reader.GetString(5),
                        Seccion = reader.GetString(6),
                        ImpartidoPor = docenteDAO.ObtenerDocentePorId(reader.GetInt32(7))
                    };
                }
            }
            catch (MySqlException ex)
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

            return cursoObtenido;
        }
    }
}