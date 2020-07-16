using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;

namespace AccesoADatos.Interfaces
{
    public interface ICursoDAO
    {
        bool GuardarCurso(Curso curso);
        int ExisteCurso(Curso curso);
        List<Curso> GetCursosDeProfesor(int idDocente);
        bool ProfesorTieneCursos(int idDocente);
    }
}
