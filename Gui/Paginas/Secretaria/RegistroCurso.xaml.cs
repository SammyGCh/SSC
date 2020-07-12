using Gui.Ventanas;
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
using LogicaDominio.Interfaces;
using LogicaDominio;
using AccesoADatos.Implementacion;
using DominioNegocio;
using MySql.Data.MySqlClient;

namespace Gui.Paginas.Secretaria
{
    /// <summary>
    /// Lógica de interacción para RegistroCurso.xaml
    /// </summary>
    public partial class RegistroCurso : Page, IRegistro
    {
        public RegistroCurso()
        {
            InitializeComponent();
            DocenteDAO docenteDao = new DocenteDAO();

            
            List<Docente> docentesActivos = docenteDao.ObtenerDocentesActivos();
            listaDocentes.ItemsSource = docentesActivos;
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

        private void RegistrarCurso(object sender, RoutedEventArgs e)
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
                string mensaje;
                try
                {
                    bool guardado = GuardarCursoRegistrado();

                    if (guardado)
                    {
                        mensaje = "Se registró el curso exitosamente.";
                        AdministradorVentanasDialogo.MostrarVentanaExito(mensaje);
                        LimpiarCampos();
                    }
                }
                catch (MySqlException ex)
                {
                    AdministradorVentanasDialogo.MostrarVentanaError(ex.Message);
                }
            }
        }

        public bool GuardarCursoRegistrado()
        {
            Curso nuevoCurso = new Curso()
            {
                Nombre = nombre.Text,
                Descripcion = descripcion.Text,
                Nrc = nrc.Text,
                Turno = turno.Text,
                Seccion = seccion.Text,
                ImpartidoPor = listaDocentes.SelectedItem as Docente
            };

            AdministradorCurso administradorCurso = new AdministradorCurso();

            bool guardado;
            try
            {
                guardado = administradorCurso.RegistrarNuevoCurso(nuevoCurso);
            }
            catch (MySqlException)
            {
                throw;
            }

            return guardado;
        }

        public bool HayCamposVacios()
        {
            bool hayCamposVacios = false;

            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(descripcion.Text) ||
                String.IsNullOrWhiteSpace(nrc.Text) || turno.SelectedItem == null || String.IsNullOrWhiteSpace(seccion.Text) ||
                listaDocentes.SelectedItem == null)
            {
                hayCamposVacios = true;
            }

            return hayCamposVacios;
        }

        public bool HayCamposIncorrectos()
        {
            bool hayCamposIncorrectos = false;

            if (!ValidadorTexto.EsTextoCorrecto(nombre.Text) || !ValidadorTexto.EsTextoCorrecto(descripcion.Text) ||
                !ValidadorTexto.EsNumeroValido(seccion.Text) || !ValidadorTexto.EsNumeroValido(nrc.Text))
            {
                hayCamposIncorrectos = true;
            }

            return hayCamposIncorrectos;
        }

        public void LimpiarCampos()
        {
            nombre.Clear();
            descripcion.Clear();
            nrc.Clear();
            turno.SelectedItem = null;
            seccion.Clear();
            listaDocentes.SelectedItem = null;
        }
    }
}
