using PruebaComponente.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponente.BLL.Interfaces
{
    public interface ICrudServices
    {
        ConsultaUsuarioDTO ConsultaUsuario();
        ConsultaUsuarioDTO CrearUsuario();
        ConsultaUsuarioDTO EditarUsuario();
        ConsultaUsuarioDTO EliminarUsuario();
    }
}
