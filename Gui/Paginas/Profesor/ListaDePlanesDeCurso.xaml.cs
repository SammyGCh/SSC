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

namespace Gui.Paginas.Profesor
{
    /// <summary>
    /// Lógica de interacción para ListaDePlanesDeCurso.xaml
    /// </summary>
    public partial class ListaDePlanesDeCurso : Page
    {
        public ListaDePlanesDeCurso()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
