using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class TipoUsuario
    {
        private int idTipoUsuario;
        private string nombre;

        public int IdTipoUsuario
        {
            get => idTipoUsuario;
            set => idTipoUsuario = value;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
    }
}
