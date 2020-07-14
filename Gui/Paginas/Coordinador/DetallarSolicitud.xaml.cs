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
            bool confirmar = AdministradorVentanasDialogo.MostrarVentanaConfirmacion("Seguro que deseas aprobar esta solicitud?");

            if (confirmar)
            {
                if (ComentarioVacio())
                {
                    AdministradorVentanasDialogo.MostrarVentanaCamposVacios();
                }
                else
                {
                    SolicitudCambioDAO solicitudDAO = new SolicitudCambioDAO();
                    bool guardado = solicitudDAO.AprobarSolicitud(solicitud);

                    if (guardado)
                    {
                        AdministradorVentanasDialogo.MostrarVentanaExito("Aprobación guardada exitosamente");
                    }
                    else
                    {
                        AdministradorVentanasDialogo.MostrarVentanaError("Ocurrio un fallo al guardar la aprobación. Intente de nuevo mas tarde.");
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
    }
}
