﻿using AccesoADatos.BaseDeDatos;
using MySql.Data.MySqlClient;
using DominioNegocio;
using AccesoADatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoADatos.Implementacion
{
    public class CuentaDAO : ICuentaDAO
    {
        private readonly ConexionBD conexion;
        private MySqlConnection conexionMysql;
        private MySqlCommand query;
        private const int ACTIVO = 1;

        public CuentaDAO()
        {
            conexion = new ConexionBD();
        }

        public bool GuardarCuenta(Cuenta cuenta)
        {
            bool guardado = false;

            try
            {
                conexionMysql = conexion.AbrirConexion();
                query = new MySqlCommand("", conexionMysql)
                {
                    CommandText = "INSERT INTO cuenta (username, password, status, idusuario) VALUES " +
                    "(@username, @password, @status, @idusuario)"
                };

                query.Parameters.Add("@username", MySqlDbType.VarChar, 45).Value = cuenta.Username;
                query.Parameters.Add("@password", MySqlDbType.VarChar, 255).Value = cuenta.Password;
                query.Parameters.Add("@status", MySqlDbType.Int32, 2).Value = ACTIVO;
                query.Parameters.Add("@idusuario", MySqlDbType.Int32, 2).Value = cuenta.Pertenece.IdUsuario;

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
