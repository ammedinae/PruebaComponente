using PruebaComponente.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PruebaComponente.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICrudService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICrudService
    {
        [OperationContract]
        List<ConsultaUsuarioDTO> Consulta();

        [OperationContract]
        ConsultaUsuarioDTO ConsultaId(long id);

        [OperationContract]
        UsuarioDTO Crear(RequestCrearUsuario request);

        [OperationContract]
        UsuarioDTO Editar(RequestEditarUsuario request);

        [OperationContract]
        UsuarioDTO Eliminar(long id);
    }
}
