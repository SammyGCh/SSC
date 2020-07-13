using AccesoADatos.Implementacion;
using DominioNegocio;
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
    /// Lógica de interacción para RegistroDeSolicitud.xaml
    /// </summary>
    public partial class RegistroDeSolicitud : Page
    {
        private int idPlanDeCurso;

        public RegistroDeSolicitud(int idPlanDeCurso)
        {
            InitializeComponent();
            this.idPlanDeCurso = idPlanDeCurso;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EnviarSolicitud(object sender, RoutedEventArgs e)
        {
            SolicitudCambio solicitud = GenerarNuevaSolicitud();
            SolicitudCambioDAO solicitudDAO = new SolicitudCambioDAO();

            if (solicitudDAO.RegistrarSolicitud(solicitud))
            {
                MessageBox.Show("Solicitud enviada exitosamente", "Exito", MessageBoxButton.OK,MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al enviar la solicitud", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private SolicitudCambio GenerarNuevaSolicitud()
        {
            SolicitudCambio nuevaSolicitud = new SolicitudCambio
            {
                CambiosSolicitados = cambiosSolicitados.Text,
                Fecha = DateTime.Now.ToString(),
                Status = 0,
                PlanDeCurso = idPlanDeCurso
            };

            return nuevaSolicitud;
        }
    }
}
