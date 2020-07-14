
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using DominioNegocio;
using AccesoADatos.Implementacion;
using Gui.Ventanas;

namespace Gui.Paginas.Coordinador
{
    /// <summary>
    /// Interaction logic for ConsultarSolicitudes.xaml
    /// </summary>
    public partial class ConsultarSolicitudes : Page
    {
        private readonly ObservableCollection<SolicitudCambio> solicitudes;
        private SolicitudCambio solicitudSeleccionada;

        public ConsultarSolicitudes()
        {
            InitializeComponent();

            SolicitudCambioDAO solicitudCambioDAO = new SolicitudCambioDAO();
            List<SolicitudCambio> listaDeSolicitudes = solicitudCambioDAO.GetSolicitudesDeCambio();

            if (listaDeSolicitudes.Count == 0)
            {
                AdministradorVentanasDialogo.MostrarVentanaError("No existen Solicitudes de cambio.");

                NavigationService.GoBack();
            }
            else
            {
                solicitudes = new ObservableCollection<SolicitudCambio>(listaDeSolicitudes);
                tablaDeSolicitudes.ItemsSource = solicitudes;
            }
        }

        private void RegresarAInicio(object sender, RoutedEventArgs e)
        {
            solicitudSeleccionada = (SolicitudCambio)tablaDeSolicitudes.SelectedItem;

            NavigationService.Navigate(new DetallarSolicitud(solicitudSeleccionada));
        }
    }
}
