using Gui.Ventanas;
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
using LogicaDominio.Interfaces;
using LogicaDominio;

namespace Gui.Paginas.Secretaria
{
    /// <summary>
    /// Lógica de interacción para RegistroCurso.xaml
    /// </summary>
    public partial class RegistroCurso : Page, IRegistro
    {
        public RegistroCurso()
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

        private void RegistrarCurso(object sender, RoutedEventArgs e)
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
                string mensaje = "Se registró el curso exitosamente.";
                AdministradorVentanasDialogo.MostrarVentanaExito(mensaje);
            }
        }

        public bool HayCamposVacios()
        {
            bool hayCamposVacios = false;

            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(descripcion.Text) ||
                String.IsNullOrWhiteSpace(nrc.Text) || turno.SelectedItem == null || String.IsNullOrWhiteSpace(seccion.Text) ||
                listaDocentes.SelectedItem == null)
            {
                hayCamposVacios = true;
            }

            return hayCamposVacios;
        }

        public bool HayCamposIncorrectos()
        {
            bool hayCamposIncorrectos = false;

            if (!ValidadorTexto.EsTextoCorrecto(nombre.Text) || !ValidadorTexto.EsTextoCorrecto(descripcion.Text) ||
                !ValidadorTexto.EsTextoCorrecto(seccion.Text) || !ValidadorTexto.EsNumeroValido(nrc.Text))
            {
                hayCamposIncorrectos = true;
            }

            return hayCamposIncorrectos;
        }
    }
}
