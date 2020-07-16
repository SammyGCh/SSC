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

namespace Gui.Paginas.Directivo
{
    /// <summary>
    /// Lógica de interacción para InicioDirectivo.xaml
    /// </summary>
    public partial class InicioDirectivo : Page
    {
        public InicioDirectivo()
        {
            InitializeComponent();
        }

        private void ConsultarDocentes(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConsultaDocentes());
        }
    }
}
