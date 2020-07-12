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
using System.Windows.Shapes;

namespace Gui.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void HabilitarBoton(object sender, RoutedEventArgs e)
        {
            if (usuario.Text.Length == 0 || password.Password.Length == 0)
            {
                botonLogin.IsEnabled = false;
            }
            else
            {
                botonLogin.IsEnabled = true;
            }
        }
    }
}
