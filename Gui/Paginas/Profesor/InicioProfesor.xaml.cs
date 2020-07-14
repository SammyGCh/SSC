using AccesoADatos.Implementacion;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Gui.Paginas.Profesor
{
    /// <summary>
    /// Lógica de interacción para ProfesorHome.xaml
    /// </summary>
    public partial class InicioProfesor : Page
    {
        private int idDocente;

        public InicioProfesor(int idDocente)
        {
            InitializeComponent();
            this.idDocente = idDocente;
        }

        private void ConsultarMisCursos(object sender, RoutedEventArgs e)
        {
            if (CursosDisponibles())
            {
                NavigationService.Navigate(new ListaDeCursos(idDocente));
            }
            else
            {
                MessageBox.Show("No tienes cursos registrados","Opcion no disponible",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }

        private bool CursosDisponibles()
        {
            bool hayCursos;

            CursoDAO cursoDAO = new CursoDAO();
            hayCursos = cursoDAO.ProfesorTieneCursos(idDocente);

            return hayCursos;
        }
    }
}
