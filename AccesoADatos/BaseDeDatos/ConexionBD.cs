using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace AccesoADatos.BaseDeDatos
{
    public class ConexionBD
    {
        private string informacionConexion;
        private MySqlConnection conexion;

        private void Conectar()
        {
            try
            {
                informacionConexion = ConfigurationManager.ConnectionStrings["connectionSetting"].ConnectionString;
                conexion = new MySqlConnection(informacionConexion);
                conexion.Open();
            }
            catch (MySqlException)
            {

                throw;
            }
        }

        public MySqlConnection AbrirConexion()
        {
            try
            {
                Conectar();
            }
            catch (MySqlException)
            {
                throw;
            }

            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion != null)
            {
                try
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
                catch (MySqlException)
                {
                    throw;
                }
            }
        }
    }
}
