using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Cuenta
    {
        private int idCuenta;
        private string username;
        private string password;
        private int status;
        private Usuario pertenece;

        public int IdCuenta
        {
            get => idCuenta;
            set => idCuenta = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public int Status
        {
            get => status;
            set => status = value;
        }

        public Usuario Pertenece
        {
            get => pertenece;
            set => pertenece = value;
        }
    }
}
