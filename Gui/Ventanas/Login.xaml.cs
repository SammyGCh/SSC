using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using LogicaDominio;
using DominioNegocio;
using Gui.Paginas.Secretaria;

namespace Gui.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void HabilitarBoton(object sender, RoutedEventArgs e)
        {
            if (usuario.Text.Length == 0 || password.Password.Length == 0)
            {
                botonLogin.IsEnabled = false;
            }
            else
            {
                botonLogin.IsEnabled = true;
            }
        }

        private void IniciarSesion(object sender, RoutedEventArgs e)
        {
            bool existeCuenta;
            string mensaje;

            try
            {
                existeCuenta = AdministradorLogin.ExisteCuenta(usuario.Text, password.Password);

                if (existeCuenta)
                {
                    Cuenta cuentaIngresada = new Cuenta()
                    {
                        Username = usuario.Text,
                        Password = password.Password
                    };

                    IrAVentanaInicio(cuentaIngresada);
                }
                else
                {
                    mensaje = "El usuario y/o contraseña ingresados son incorrectos. Por favor verifique la información.";
                    AdministradorVentanasDialogo.MostrarVentanaError(mensaje);
                }
            }
            catch (MySqlException)
            {
                mensaje = "Ocurrió un error en la conexión. Intente más tarde.";

                AdministradorVentanasDialogo.MostrarVentanaError(mensaje);
            }
            catch (NullReferenceException ex)
            {
                mensaje = "Ocurrió un error en la conexión. Intente más tarde.";

                AdministradorVentanasDialogo.MostrarVentanaError(ex.Message);
            }
        }

        private void IrAVentanaInicio(Cuenta cuenta)
        {
            Usuario usuarioIngresado;

            try
            {
                usuarioIngresado = AdministradorLogin.BuscarUsuarioIngresado(cuenta);
                Page ventanaInicioDeUsuario = null;

                switch (usuarioIngresado.Pertenece.IdTipoUsuario)
                {
                    case AdministradorLogin.TIPO_SECRETARIA:
                        ventanaInicioDeUsuario = new InicioSecretaria();
                        break;
                    case AdministradorLogin.TIPO_COORDINADOR:
                        break;
                    case AdministradorLogin.TIPO_DIRECTOR:
                        break;
                    case AdministradorLogin.TIPO_DOCENTE:
                        break;
                }

                Inicio ventanaInicio = new Inicio(ventanaInicioDeUsuario);
                ventanaInicio.Show();
                this.Close();
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}
