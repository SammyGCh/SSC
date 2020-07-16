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
        private const int NO_EXISTE = 0;

        public AdministradorCurso()
        {
            administradorCurso = new CursoDAO();
        }

        public ResultadoRegistro RegistrarNuevoCurso(Curso curso)
        {
            ResultadoRegistro registrado = ResultadoRegistro.NoRegistrado;

            if (curso != null)
            {
                if (administradorCurso.ExisteCurso(curso) == NO_EXISTE)
                {
                    bool cursoRegistrado;
                    try
                    {
                        cursoRegistrado = administradorCurso.GuardarCurso(curso);
                    }
                    catch (MySqlException)
                    {
                        throw;
                    }

                    if (cursoRegistrado)
                    {
                        registrado = ResultadoRegistro.Registrado;
                    }
                }
                else
                {
                    registrado = ResultadoRegistro.YaExiste;
                }
            }

            return registrado;
        }
    }
}
