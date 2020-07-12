using System;
using System.Collections.Generic;
using System.Text;

namespace DominioNegocio
{
    public class Docente : Usuario
    {
        private int idDocente;
        private string aniosExperiencia;
        private string curp;
        private string fechaNacimiento;
        private string numeroPersonal;
        private string perfilProfesional;
        private string rfc;

        public int IdDocente
        {
            get => idDocente;
            set => idDocente = value;
        }

        public string AniosExperiencia
        {
            get => aniosExperiencia;
            set => aniosExperiencia = value;
        }

        public string Curp
        {
            get => curp;
            set => curp = value;
        }

        public string FechaNacimiento
        {
            get => fechaNacimiento;
            set => fechaNacimiento = value;
        }

        public string NumeroPersonal
        {
            get => numeroPersonal;
            set => numeroPersonal = value;
        }

        public string PerfilProfesional
        {
            get => perfilProfesional;
            set => perfilProfesional = value;
        }

        public string Rfc
        {
            get => rfc;
            set => rfc = value;
        }
    }
}
