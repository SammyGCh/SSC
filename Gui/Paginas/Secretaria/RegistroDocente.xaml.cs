﻿using System;
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
using Gui.Ventanas;
using LogicaDominio.Interfaces;
using LogicaDominio;

namespace Gui.Paginas.Secretaria
{
    /// <summary>
    /// Lógica de interacción para RegistroDocente.xaml
    /// </summary>
    public partial class RegistroDocente : Page, IRegistro
    {
        public RegistroDocente()
        {
            InitializeComponent();
        }

        private void CancelarRegistro(object sender, RoutedEventArgs e)
        {
            string mensajeConfirmacion = "¿Seguro desea cancelar el registro?";
            bool cancelar = AdministradorVentanasDialogo.MostrarVentanaConfirmacion(mensajeConfirmacion);

            if (cancelar)
            {
                NavigationService.GoBack();
            }
        }

        private void RegistrarDocente(object sender, RoutedEventArgs e)
        {
            if (HayCamposVacios())
            {
                AdministradorVentanasDialogo.MostrarVentanaCamposVacios();
            }
            else if (HayCamposIncorrectos())
            {
                AdministradorVentanasDialogo.MostrarVentanaCamposIncorrectos();
            }
            else
            {
                string mensaje = "Se registró el docente exitosamente.";
                AdministradorVentanasDialogo.MostrarVentanaExito(mensaje);
            }
        }

        public bool HayCamposVacios()
        {
            bool hayCamposVacios = false;

            if (String.IsNullOrWhiteSpace(usuario.Text) || String.IsNullOrWhiteSpace(password.Text) || 
                String.IsNullOrWhiteSpace(nombres.Text) || String.IsNullOrWhiteSpace(apellidos.Text) ||
                genero.SelectedItem == null || String.IsNullOrWhiteSpace(correo.Text) ||
                String.IsNullOrWhiteSpace(numeroPersonal.Text) || fechaNacimiento.SelectedDate == null ||
                String.IsNullOrWhiteSpace(curp.Text) || String.IsNullOrWhiteSpace(rfc.Text) ||
                String.IsNullOrWhiteSpace(perfilProfesional.Text) || String.IsNullOrWhiteSpace(aniosExperiencia.Text))
            {
                hayCamposVacios = true;
            }

            return hayCamposVacios;
        }

        public bool HayCamposIncorrectos()
        {
            bool hayCamposIncorrectos = false;

            if (!ValidadorTexto.EsTextoCorrecto(nombres.Text) || !ValidadorTexto.EsTextoCorrecto(apellidos.Text) ||
                !ValidadorTexto.EsTextoCorrecto(perfilProfesional.Text) || !ValidadorTexto.EsNumeroPersonal(numeroPersonal.Text) ||
                !ValidadorTexto.EsNumeroValido(aniosExperiencia.Text) || !ValidadorTexto.EsCorreoElectronico(correo.Text) ||
                !ValidadorTexto.EsCURP(curp.Text) || !ValidadorTexto.EsRFC(rfc.Text))
            {
                hayCamposIncorrectos = true;
            }

            return hayCamposIncorrectos;
        }
    }
}
