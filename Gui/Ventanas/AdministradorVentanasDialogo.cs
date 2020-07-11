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

        public static void MostrarVentanaError(string mensajeError)
        {
            MessageBox.Show(mensajeError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MostrarVentanaCamposVacios()
        {
            MessageBox.Show("Uno o varios campos están vacíos. Por favor ingresa los datos necesarios.", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MostrarVentanaExito(string mensajeExito)
        {
            MessageBox.Show(mensajeExito, "Éxito",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public static void MostrarVentanaCamposIncorrectos()
        {
            MessageBox.Show("La información en uno o varios campos es incorrecta. Por favor verifica la información.",
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
