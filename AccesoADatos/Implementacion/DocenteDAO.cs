using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;
using AccesoADatos.Interfaces;
using AccesoADatos.BaseDeDatos;
using MySql.Data.MySqlClient;

namespace AccesoADatos.Implementacion
{
    public class DocenteDAO : IDocenteDAO
    {
        private Docente docente;
        private List<Docente> docentes;
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private MySqlDataReader reader;
        private const int ACTIVO = 1;
        private const int USUARIO_DOCENTE = 4;

        public DocenteDAO()
        {
            conexion = new ConexionBD();
        }

        public bool GuardarDocente(Docente docente)
        {
            bool guardado = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "INSERT INTO docente (aniosExperiencia, curp, fechaNacimiento, numeroPersonal, perfilProfesional, rfc, idusuario) VALUES " +
                    "(@aniosExperiencia, @curp, @fechaNacimiento, @numeroPersonal, @perfilProfesional, @rfc, @idusuario)"
                };

                query.Parameters.Add("@aniosExperiencia", MySqlDbType.VarChar, 2).Value = docente.AniosExperiencia;
                query.Parameters.Add("@curp", MySqlDbType.VarChar, 18).Value = docente.Curp;
                query.Parameters.Add("@fechaNacimiento", MySqlDbType.VarChar, 9).Value = docente.FechaNacimiento;
                query.Parameters.Add("@numeroPersonal", MySqlDbType.VarChar, 10).Value = docente.NumeroPersonal;
                query.Parameters.Add("@perfilProfesional", MySqlDbType.VarChar, 100).Value = docente.PerfilProfesional;
                query.Parameters.Add("@rfc", MySqlDbType.VarChar, 13).Value = docente.Rfc;
                query.Parameters.Add("@idusuario", MySqlDbType.Int32, 2).Value = docente.IdUsuario;

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

        public List<Docente> ObtenerDocentesActivos()
        {
            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT usuario.idusuario, usuario.nombres, usuario.apellidos, usuario.genero, usuario.correoElectronico, " +
                    "usuario.idtipousuario, docente.idusuario, docente.iddocente, cuenta.idusuario, cuenta.status FROM usuario, docente, cuenta " +
                    "WHERE usuario.idusuario = cuenta.idusuario AND cuenta.status = @status AND usuario.idtipousuario = @tipousuario"
                };

                query.Parameters.Add("@status", MySqlDbType.Int32, 2).Value = ACTIVO;
                query.Parameters.Add("@tipousuario", MySqlDbType.Int32, 2).Value = USUARIO_DOCENTE;

                reader = query.ExecuteReader();

                docentes = new List<Docente>();

                while (reader.Read())
                {
                    docente = new Docente()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Genero = reader.GetString(3),
                        CorreoElectronico = reader.GetString(4),
                        IdDocente = reader.GetInt32(7)
                    };

                    docentes.Add(docente);
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

            return docentes;
        }
        
        public int ExisteDocente(Docente docente)
        {
            int existe = 0;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT COUNT(docente.numeroPersonal) FROM docente WHERE docente.numeroPersonal = @numeroPersonal"
                };

                query.Parameters.Add("@numeroPersonal", MySqlDbType.VarChar, 10).Value = docente.NumeroPersonal;

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
                conexion.CerrarConexion();
            }

            return existe;
        }
        
        public Docente ObtenerDocenteId(int idDocente)
        {
            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT * from docente WHERE idUsuario = @idDocente"
                };

                query.Parameters.Add("@idDocente", MySqlDbType.Int32, 2).Value = idDocente;

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    docente = new Docente()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Genero = reader.GetString(3),
                        CorreoElectronico = reader.GetString(4),
                        PerfilProfesional = reader.GetString(5),
                        Rfc = reader.GetString(6),
                        IdDocente = reader.GetInt32(7)
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

            return docente;
        }
        
        public Docente ObtenerDocentePorId(int idProfessor)
        {
            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "SELECT usuario.idusuario, usuario.nombres, usuario.apellidos, usuario.genero, usuario.correoElectronico, " +
                    "usuario.idtipousuario, docente.idusuario, docente.iddocente, cuenta.idusuario, cuenta.status FROM usuario, docente, cuenta " +
                    "WHERE usuario.idusuario = @idprofessor AND usuario.idtipousuario = @tipousuario"
                };

                query.Parameters.Add("@idprofessor", MySqlDbType.Int32, 2).Value = idProfessor;
                query.Parameters.Add("@tipousuario", MySqlDbType.Int32, 2).Value = USUARIO_DOCENTE;

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    docente = new Docente()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Genero = reader.GetString(3),
                        CorreoElectronico = reader.GetString(4),
                        IdDocente = reader.GetInt32(7)
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

            return docente;
        }
    }
}
