using PruebaComponente.BLL.DTO;
using PruebaComponente.BLL.Interfaces;
using PruebaComponente.BLL.Services;
using PruebaComponente.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PruebaComponente.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CrudService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CrudService.svc o CrudService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CrudService : ICrudService
    {
        //public ICrudServices _crudServices { get; set; }

        public List<ConsultaUsuarioDTO> Consulta()
        {
            List<ConsultaUsuarioDTO> respuesta = new List<ConsultaUsuarioDTO>();

            //respuesta = _crudServices.ConsultaUsuario();
            respuesta = CrudServices.ConsultaUsuario();

            return respuesta;
        }

        public ConsultaUsuarioDTO ConsultaId(long id)
        {
            ConsultaUsuarioDTO respuesta = new ConsultaUsuarioDTO();

            //respuesta = _crudServices.ConsultaUsuario();
            respuesta = CrudServices.ConsultaUsuarioId(id);

            return respuesta;
        }

        public UsuarioDTO Crear(RequestCrearUsuario request)
        {
            UsuarioDTO respuesta = new UsuarioDTO();

            respuesta.Respuesta = CrudServices.CrearUsuario(request);

            return respuesta;
        }

        public UsuarioDTO Editar(RequestEditarUsuario request)
        {
            UsuarioDTO respuesta = new UsuarioDTO();

            respuesta.Respuesta = CrudServices.EditarUsuario(request);

            return respuesta;
        }

        public UsuarioDTO Eliminar(long id)
        {
            UsuarioDTO respuesta = new UsuarioDTO();

            respuesta.Respuesta = CrudServices.EliminarUsuario(id);

            return respuesta;
        }
    }
}
