using System;
using System.Collections.Generic;
using System.Text;
using DominioNegocio;

namespace AccesoADatos.Interfaces
{
    public interface IDocenteDAO
    {
        bool GuardarDocente(Docente docente);
        List<Docente> ObtenerDocentesActivos();
        int ExisteDocente(Docente docente);
    }
}
