using AccesoADatos.Interfaces;
using DominioNegocio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Implementacion
{
    public class CursoDAO : ICursoDao
    {
        private MySqlDataReader reader;

        public CursoDAO()
        {

        }

        public List<Curso> GetCursosDeProfesor(String numeroDePersonal)
        {
            List<Curso> listaDeCursos = new List<Curso>();
            MySqlConnection mySqlConnection;

            MySqlCommand query;
            Curso cursoObtenido;

            try
            {
                mySqlConnection = connection.OpenConnection();
                query = new MySqlCommand("", mySqlConnection)
                {
                    CommandText = "SELECT * FROM Curso WHERE Docente.numeroPersonal = @numeroPersonal"
                };

                MySqlParameter personal = new MySqlParameter("@numeroPersonal", MySqlDbType.VarChar, 10)
                {
                    Value = numeroDePersonal
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
                        Seccion = reader.GetString(6),
                        IdDocente = reader.GetInt32(7),
                        IdUsuario = reader.GetInt32(8)

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
                connection.CloseConnection();
            }

            return listaDeCursos;
        }
    }
}