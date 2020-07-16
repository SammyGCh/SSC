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
using DominioNegocio;
using AccesoADatos.Implementacion;

namespace Gui.Paginas.Directivo
{
    /// <summary>
    /// Lógica de interacción para DetallesDocente.xaml
    /// </summary>
    public partial class DetallesDocente : Page
    {
        public DetallesDocente(Docente docenteMostrado)
        {
            InitializeComponent();
            DocenteDAO docenteDAO = new DocenteDAO();
            Docente docenteDetallado = docenteDAO.ObtenerDocenteId(docenteMostrado.IdUsuario);
            docenteMostrado.AniosExperiencia = docenteDetallado.Nombres;
            docenteMostrado.Curp = docenteDetallado.Apellidos;
            docenteMostrado.FechaNacimiento = docenteDetallado.Genero;
            docenteMostrado.NumeroPersonal = docenteDetallado.CorreoElectronico;
            docenteMostrado.Rfc = docenteDetallado.Rfc;
            docenteMostrado.PerfilProfesional = docenteDetallado.PerfilProfesional;
            this.DataContext = docenteMostrado;
            CursoDAO cursoDAO = new CursoDAO();
            List<Curso> planesCurso = cursoDAO.GetCursosDeProfesor(docenteMostrado.IdDocente);
            tablasCurso.ItemsSource = planesCurso;
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
