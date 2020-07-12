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
                    bool guardado = GuardarDocenteRegistrado();
                    string mensaje;

                    if (guardado)
                    {
                        mensaje = "Se registró el docente exitosamente.";
                        AdministradorVentanasDialogo.MostrarVentanaExito(mensaje);
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

        private bool GuardarDocenteRegistrado()
        {
            bool guardado;
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
    }
}
