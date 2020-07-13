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
using System.Windows.Shapes;
using Gui.Paginas.Profesor;
using Gui.Paginas.Secretaria;

namespace Gui.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        private int idDocente = 1;

        public Inicio()
        {
            InitializeComponent();
            frameInicio.Content = new InicioProfesor(idDocente);
        }
    }
}
