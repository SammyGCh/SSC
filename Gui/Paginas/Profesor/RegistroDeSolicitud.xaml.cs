using AccesoADatos.Implementacion;
using DominioNegocio;
using Gui.Ventanas;
using LogicaDominio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            MessageBoxResult esConfirmado = MessageBox.Show("¿Seguro deseas cancelar la solicitud?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (esConfirmado == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }

        private void EnviarSolicitud(object sender, RoutedEventArgs e)
        {
            MessageBoxResult esConfirmado = MessageBox.Show("¿Seguro deseas enviar una solicitud?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (esConfirmado == MessageBoxResult.Yes)
            {
                if (EsTextoCorrecto())
                {
                    SolicitudCambio solicitud = GenerarNuevaSolicitud();
                    SolicitudCambioDAO solicitudDAO = new SolicitudCambioDAO();

                    if (solicitudDAO.RegistrarSolicitud(solicitud))
                    {
                        MessageBox.Show("Solicitud enviada exitosamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.GoBack();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al enviar la solicitud", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    AdministradorVentanasDialogo.MostrarVentanaError("Uno o varios campos contienen datos no válidos. Por favor ingresa los datos necesarios");
                }
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

        private bool EsTextoCorrecto()
        {
            bool esCorrecto;

            esCorrecto = (!TextoVacio() && TextoValido());

            return esCorrecto;
        }

        private bool TextoValido()
        {
            return ValidadorTexto.EsTextoCorrecto(cambiosSolicitados.Text);
        }

        private bool TextoVacio()
        {
            return String.IsNullOrEmpty(cambiosSolicitados.Text);
        }
    }
}
