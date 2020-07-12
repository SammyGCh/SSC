using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;

namespace AccesoADatos.Interfaces
{
    public interface ICursoDao
    {
        List<Curso> GetCursosDeProfesor(String numeroDePersonal);
    }
}
