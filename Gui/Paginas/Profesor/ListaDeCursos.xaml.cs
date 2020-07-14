using AccesoADatos.Implementacion;
using DominioNegocio;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Gui.Paginas.Profesor
{
    /// <summary>
    /// Lógica de interacción para ListaDeCursos.xaml
    /// </summary>
    public partial class ListaDeCursos : Page
    {
        private int idDocente;
        public ListaDeCursos(int idDocente)
        {
            InitializeComponent();
            this.idDocente = idDocente;
            CursoDAO cursoDAO = new CursoDAO();
            List<Curso> listaDeCursos = cursoDAO.GetCursosDeProfesor(idDocente);
            tablaDeCursos.ItemsSource = listaDeCursos;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void VerPlanes(object sender, RoutedEventArgs e)
        {
            Curso cursoSeleccionado = (Curso)tablaDeCursos.SelectedItem;

            if (PlanesDisponibles(cursoSeleccionado.IdCurso))
            {
                NavigationService.Navigate(new ListaDePlanesDeCurso(cursoSeleccionado.IdCurso));
            }
            else
            {
                MessageBox.Show("Este curso no cuenta con planes disponibles", "Opcion no disponible", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private bool PlanesDisponibles(int idCurso)
        {
            bool hayplanes;
            PlanDeCursoDAO dao = new PlanDeCursoDAO();

            hayplanes = dao.CursoTienePlanes(idCurso);

            return hayplanes;
        }
    }
}
