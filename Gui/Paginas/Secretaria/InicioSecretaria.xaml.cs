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

namespace Gui.Paginas.Secretaria
{
    /// <summary>
    /// Lógica de interacción para InicioSecretaria.xaml
    /// </summary>
    public partial class InicioSecretaria : Page
    {
        public InicioSecretaria()
        {
            InitializeComponent();
        }

        private void RegistrarDocente(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistroDocente());
        }

        private void RegistrarCurso(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistroCurso());
        }
    }
}
