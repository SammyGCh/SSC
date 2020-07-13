using AccesoADatos.Implementacion;
using DominioNegocio;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Gui.Paginas.Profesor
{
    /// <summary>
    /// Lógica de interacción para ListaDePlanesDeCurso.xaml
    /// </summary>
    public partial class ListaDePlanesDeCurso : Page
    {
        public ListaDePlanesDeCurso(int idCurso)
        {
            InitializeComponent();

            PlanDeCursoDAO planDAO = new PlanDeCursoDAO();
            List<PlanDeCurso> listaDeCursos = planDAO.ObtenerPlanesPorCurso(idCurso);
            tablaDePlanes.ItemsSource = listaDeCursos;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SolicitarActualizacion(object sender, RoutedEventArgs e)
        {
            PlanDeCurso cursoSeleccionado = (PlanDeCurso)tablaDePlanes.SelectedItem;

            NavigationService.Navigate(new RegistroDeSolicitud(cursoSeleccionado.IdPlanDeCurso));
        }
    }
}
