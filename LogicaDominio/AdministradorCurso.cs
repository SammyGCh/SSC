using System;
using System.Collections.Generic;
using System.Text;
using AccesoADatos.Implementacion;
using DominioNegocio;
using MySql.Data.MySqlClient;

namespace LogicaDominio
{
    public class AdministradorCurso
    {
        private CursoDAO administradorCurso;

        public AdministradorCurso()
        {
            administradorCurso = new CursoDAO();
        }

        public bool RegistrarNuevoCurso(Curso curso)
        {
            bool registrado = false;

            if (curso != null)
            {
                try
                {
                    registrado = administradorCurso.GuardarCurso(curso);
                }
                catch (MySqlException)
                {
                    throw;
                }
            }

            return registrado;
        }
    }
}
