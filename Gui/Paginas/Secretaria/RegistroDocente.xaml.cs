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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gui.Ventanas;
using LogicaDominio.Interfaces;
using LogicaDominio;
using DominioNegocio;
using MySql.Data.MySqlClient;

namespace Gui.Paginas.Secretaria
{
    /// <summary>
    /// Lógica de interacción para RegistroDocente.xaml
    /// </summary>
    public partial class RegistroDocente : Page, IRegistro
    {
        public RegistroDocente()
        {
            InitializeComponent();
        }

        private void CancelarRegistro(object sender, RoutedEventArgs e)
        {
            string mensajeConfirmacion = "¿Seguro desea cancelar el registro?";
            bool cancelar = AdministradorVentanasDialogo.MostrarVentanaConfirmacion(mensajeConfirmacion);

            if (cancelar)
            {
                NavigationService.GoBack();
            }
        }

        private void RegistrarDocente(object sender, RoutedEventArgs e)
        {
            if (HayCamposVacios())
            {
                AdministradorVentanasDialogo.MostrarVentanaCamposVacios();
            }
            else if (HayCamposIncorrectos())
            {
                AdministradorVentanasDialogo.MostrarVentanaCamposIncorrectos();
            }
            else
            {
                try
                {
                    ResultadoRegistro guardado = GuardarDocenteRegistrado();
                    string mensaje;

                    if (guardado == ResultadoRegistro.Registrado)
                    {
                        mensaje = "Se registró el docente exitosamente.";
                        AdministradorVentanasDialogo.MostrarVentanaExito(mensaje);
                        LimpiarCampos();
                    }
                    else if (guardado == ResultadoRegistro.YaExiste)
                    {
                        mensaje = "El docente que intenta registrar ya existe. Por favor, verifique la información.";
                        AdministradorVentanasDialogo.MostrarVentanaError(mensaje);
                    }
                    else
                    {
                        mensaje = "Ocurrió un error al intertar registrar el docente. Intente más tarde.";
                        AdministradorVentanasDialogo.MostrarVentanaError(mensaje);
                    }
                    
                }
                catch (MySqlException ex)
                {
                    AdministradorVentanasDialogo.MostrarVentanaError(ex.Message);
                }
            }
        }

        private ResultadoRegistro GuardarDocenteRegistrado()
        {
            Cuenta cuentaDocente = new Cuenta()
            {
                Username = usuario.Text,
                Password = password.Text
            };

            Docente nuevoDocente = new Docente()
            {
                Nombres = nombres.Text,
                Apellidos = apellidos.Text,
                Genero = genero.Text,
                CorreoElectronico = correo.Text,
                NumeroPersonal = numeroPersonal.Text,
                FechaNacimiento = fechaNacimiento.SelectedDate.ToString().Substring(0, 10),
                Curp = curp.Text,
                Rfc = rfc.Text,
                PerfilProfesional = perfilProfesional.Text,
                AniosExperiencia = aniosExperiencia.Text
            };

            AdministradorDocente administradorDocente = new AdministradorDocente();

            ResultadoRegistro guardado;

            try
            {
                guardado = administradorDocente.RegistrarNuevaCuentaDocente(cuentaDocente, nuevoDocente);
            }
            catch (MySqlException)
            {
                throw;
            }

            return guardado;
        }

        public bool HayCamposVacios()
        {
            bool hayCamposVacios = false;

            if (String.IsNullOrWhiteSpace(usuario.Text) || String.IsNullOrWhiteSpace(password.Text) || 
                String.IsNullOrWhiteSpace(nombres.Text) || String.IsNullOrWhiteSpace(apellidos.Text) ||
                genero.SelectedItem == null || String.IsNullOrWhiteSpace(correo.Text) ||
                String.IsNullOrWhiteSpace(numeroPersonal.Text) || fechaNacimiento.SelectedDate == null ||
                String.IsNullOrWhiteSpace(curp.Text) || String.IsNullOrWhiteSpace(rfc.Text) ||
                String.IsNullOrWhiteSpace(perfilProfesional.Text) || String.IsNullOrWhiteSpace(aniosExperiencia.Text))
            {
                hayCamposVacios = true;
            }

            return hayCamposVacios;
        }

        public bool HayCamposIncorrectos()
        {
            bool hayCamposIncorrectos = false;

            if (!ValidadorTexto.EsNombreCorrecto(nombres.Text) || !ValidadorTexto.EsNombreCorrecto(apellidos.Text) ||
                !ValidadorTexto.EsTextoCorrecto(perfilProfesional.Text) || !ValidadorTexto.EsNumeroPersonal(numeroPersonal.Text) ||
                !ValidadorTexto.EsNumeroValido(aniosExperiencia.Text) || !ValidadorTexto.EsCorreoElectronico(correo.Text) ||
                !ValidadorTexto.EsCURP(curp.Text) || !ValidadorTexto.EsRFC(rfc.Text))
            {
                hayCamposIncorrectos = true;
            }

            return hayCamposIncorrectos;
        }

        public void LimpiarCampos()
        {
            nombres.Clear();
            apellidos.Clear();
            perfilProfesional.Clear();
            numeroPersonal.Clear();
            aniosExperiencia.Clear();
            correo.Clear();
            curp.Clear();
            rfc.Clear();
            genero.SelectedItem = null;
            fechaNacimiento.SelectedDate = null;
            usuario.Clear();
            password.Clear();
        }

        private void ValidarNombre(object sender, TextChangedEventArgs e)
        {
            string nombreAValidar = ((TextBox)sender).Text;

            if (ValidadorTexto.EsNombreCorrecto(nombreAValidar))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }

        private void ValidarCorreo(object sender, TextChangedEventArgs e)
        {
            string correo = ((TextBox)sender).Text;

            if (ValidadorTexto.EsCorreoElectronico(correo))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }

        private void ValidarNumeroPersonal(object sender, TextChangedEventArgs e)
        {
            string numeroPersonal = ((TextBox)sender).Text;

            if (ValidadorTexto.EsNumeroPersonal(numeroPersonal))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }

        private void EsCURP(object sender, TextChangedEventArgs e)
        {
            string curp = ((TextBox)sender).Text;

            if (ValidadorTexto.EsCURP(curp))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }

        private void EsRFC(object sender, TextChangedEventArgs e)
        {
            string rfc = ((TextBox)sender).Text;

            if (ValidadorTexto.EsRFC(rfc))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }

        private void ValidarTexto(object sender, TextChangedEventArgs e)
        {
            string texto = ((TextBox)sender).Text;

            if (ValidadorTexto.EsTextoCorrecto(texto))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }

        private void EsNumero(object sender, TextChangedEventArgs e)
        {
            string numero = ((TextBox)sender).Text;

            if (ValidadorTexto.EsNumeroValido(numero))
            {
                ((TextBox)sender).BorderBrush = Brushes.Blue;
            }
            else
            {
                ((TextBox)sender).BorderBrush = Brushes.Red;
            }
        }
    }
}
