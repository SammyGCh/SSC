using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            NavigationService.Navigate(new ConsultarPlanes());
        }

        private void ConsultarSolicitudes(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsultarSolicitudes());
        }
    }
}
