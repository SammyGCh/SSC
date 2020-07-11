using System;
using System.Windows;

namespace Gui.Ventanas
{
    public static class AdministradorVentanasDialogo
    {
        public static bool MostrarVentanaConfirmacion(string mensajeConfirmacion)
        {
            bool confirmacion = false;

            MessageBoxResult respuestaUsuario = MessageBox.Show(mensajeConfirmacion, "Confirmación",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (respuestaUsuario == MessageBoxResult.Yes)
            {
                confirmacion = true;
            }

            return confirmacion;
        }
    }
}
