using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Gui.Ventanas;

namespace Gui.Paginas.Coordinador
{
    /// <summary>
    /// Interaction logic for InicioCoordinador.xaml
    /// </summary>
    public partial class InicioCoordinador : Page
    {
        public InicioCoordinador()
        {
            InitializeComponent();
        }
        private void ConsultarPlanes(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No se ha implementado esta funcionalidad");
        }

        private void ConsultarSolicitudes(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsultarSolicitudes());
        }

        private void ConsultarReportes(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No se ha implementado esta funcionalidad");
        }

        private void ConsultarDocentes(object sender, RoutedEventArgs e)
        {
            AdministradorVentanasDialogo.MostrarVentanaError("No se ha implementado esta funcionalidad");
        }
    }
}
