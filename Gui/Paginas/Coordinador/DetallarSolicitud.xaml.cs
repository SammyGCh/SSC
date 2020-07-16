using DominioNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AccesoADatos.Implementacion;
using Gui.Ventanas;


namespace Gui.Paginas.Coordinador
{
    /// <summary>
    /// Interaction logic for DetallarSolicitud.xaml
    /// </summary>
    public partial class DetallarSolicitud : Page
    {
        public SolicitudCambio solicitud;

        public DetallarSolicitud(SolicitudCambio solicitudSeleccionada)
        {
            InitializeComponent();

            solicitud = solicitudSeleccionada;

            this.DataContext = solicitud;
        }

        private void RegresarAConsultar(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AprobarSolicitud(object sender, RoutedEventArgs e)
        {
            bool confirmar = AdministradorVentanasDialogo.MostrarVentanaConfirmacion("“¿Seguro que deseas autorizar la solicitud de modificación para este plan de curso?");

            if (confirmar)
            {
                if (ComentarioVacio())
                {
                    AdministradorVentanasDialogo.MostrarVentanaError("Esta vacio el campo de comentarios. Por favor verifique la información.");
                }
                else
                {
                    SolicitudCambioDAO solicitudDAO = new SolicitudCambioDAO();

                    solicitud.Comentarios = comentariosSolicitud.Text;

                    bool guardado = solicitudDAO.AprobarSolicitud(solicitud);

                    if (guardado)
                    {
                        AdministradorVentanasDialogo.MostrarVentanaExito("El plan de curso fue actualizado exitosamente.");
                    }
                    else
                    {
                        AdministradorVentanasDialogo.MostrarVentanaError("Ocurrió un fallo al intentar conectarse a la base de datos. Intente de nuevo más tarde.");
                    }

                    NavigationService.Navigate(new ConsultarSolicitudes());
                }
            }
        }

        private bool ComentarioVacio()
        {
            bool esVacio = false;

            if (String.IsNullOrWhiteSpace(comentariosSolicitud.Text))
            {
                esVacio = true;
            }

            return esVacio;
        }

        private void IrATemas(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No esta implementada esta funcionalidad");
        }

        private void IrAActividades(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No esta implementada esta funcionalidad");
        }

        private void IrATemasCambio(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No esta implementada esta funcionalidad");
        }

        private void IrAActividadesCambio(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No esta implementada esta funcionalidad");
        }
    }
}
