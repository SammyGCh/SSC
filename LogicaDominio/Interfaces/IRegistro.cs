using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDominio.Interfaces
{
    public interface IRegistro
    {
        bool HayCamposVacios();
        bool HayCamposIncorrectos();
        void LimpiarCampos();
    }
}
