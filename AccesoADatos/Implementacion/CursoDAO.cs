﻿using System;
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
    }
}
