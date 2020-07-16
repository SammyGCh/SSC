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
using AccesoADatos.Implementacion;
using DominioNegocio;
using Gui.Ventanas;
namespace Gui.Paginas.Directivo
{
    /// <summary>
    /// Lógica de interacción para ConsultaDocentes.xaml
    /// </summary>
    public partial class ConsultaDocentes : Page
    {
        public ConsultaDocentes()
        {
            InitializeComponent();
            DocenteDAO docenteDAO = new DocenteDAO();
            List<Docente> docentesLista = docenteDAO.ObtenerDocentesActivos();
            if(docentesLista == null)
            {
                AdministradorVentanasDialogo.MostrarVentanaError("No existe ningun docente registrado aun");
                NavigationService.GoBack();
            }
            tablaDeDocentes.ItemsSource = docentesLista;
            
        }
        private void Cancelar(object sender, RoutedEventArgs e)
        {

            if (AdministradorVentanasDialogo.MostrarVentanaConfirmacion("¿Seguro que desea salir?") == true)
            {
                NavigationService.GoBack();
            }
        }
        private void DetallarAcademico(object sender, RoutedEventArgs e)
        {
            DataGrid listaAcademicos = tablaDeDocentes;
            Docente docenteSelecionado = (Docente)listaAcademicos.SelectedItem;
            NavigationService.Navigate(new DetallesDocente(docenteSelecionado));
        }
    }
}
