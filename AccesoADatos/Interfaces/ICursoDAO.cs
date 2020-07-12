using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;

namespace AccesoADatos.Interfaces
{
    public interface ICursoDAO
    {
        bool GuardarCurso(Curso curso);

        List<Curso> GetCursosDeProfesor(String numeroDePersonal);
    }
}
