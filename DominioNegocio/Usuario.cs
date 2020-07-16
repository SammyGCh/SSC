using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Usuario
    {
        private int idUsuario;
        private string nombres;
        private string apellidos;
        private string genero;
        private string correoElectronico;
        private TipoUsuario pertenece;

        public int IdUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        public string Nombres
        {
            get => nombres;
            set => nombres = value;
        }

        public string Apellidos
        {
            get => apellidos;
            set => apellidos = value;
        }

        public string Genero
        {
            get => genero;
            set => genero = value;
        }

        public string CorreoElectronico
        {
            get => correoElectronico;
            set => correoElectronico = value;
        }

        public TipoUsuario Pertenece
        {
            get => pertenece;
            set => pertenece = value;
        }

        public override string ToString()
        {
            return Apellidos + " " + Nombres;
        }
    }
}
