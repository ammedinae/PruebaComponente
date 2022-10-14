using Newtonsoft.Json;
using PruebaComponente.BLL.DTO;
using PruebaComponente.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponente.BLL.Services
{
    public class CrudServices
    {
        public static List<ConsultaUsuarioDTO> ConsultaUsuario()
        {
            try
            {
                List<ConsultaUsuarioDTO> respuesta = new List<ConsultaUsuarioDTO>();

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    respuesta = (from u in db.Usuario
                                 select new ConsultaUsuarioDTO
                                 {
                                     Id = u.Id,
                                     Nombre = u.Nombre,
                                     FechaNacimiento = u.FechaNacimiento,
                                     Sexo = u.Sexo
                                 }).ToList();
                }

                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    JsonSalida = JsonConvert.SerializeObject(respuesta),
                    Codigo = 200,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return respuesta;
            }
            catch (Exception ex)
            {
                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Codigo = 500,
                    MensajeError = ex.Message,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return null;
            }
        }

        public static ConsultaUsuarioDTO ConsultaUsuarioId(long id)
        {
            try
            {
                ConsultaUsuarioDTO respuesta = new ConsultaUsuarioDTO();

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    respuesta = (from u in db.Usuario
                                 where u.Id == id
                                 select new ConsultaUsuarioDTO
                                 {
                                     Id = u.Id,
                                     Nombre = u.Nombre,
                                     FechaNacimiento = u.FechaNacimiento,
                                     Sexo = u.Sexo
                                 }).FirstOrDefault();
                }

                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    JsonEntrada = id.ToString(),
                    JsonSalida = JsonConvert.SerializeObject(respuesta),
                    Codigo = 200,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return respuesta;
            }
            catch (Exception ex)
            {
                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Codigo = 500,
                    MensajeError = ex.Message,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return null;
            }
        }

        public static bool CrearUsuario(RequestCrearUsuario request)
        {
            try
            {
                bool respuesta = false;

                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    FechaNacimiento = request.FechaNacimiento,
                    Sexo = request.Sexo,
                };

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();

                    if (usuario.Id > 0)
                    {
                        respuesta = true;
                    }
                }

                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    JsonEntrada = JsonConvert.SerializeObject(request),
                    JsonSalida = respuesta.ToString(),
                    Codigo = 200,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return respuesta;
            }
            catch (Exception ex)
            {
                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Codigo = 500,
                    MensajeError = ex.Message,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return false;
            }
        }

        public static bool EditarUsuario(RequestEditarUsuario request)
        {
            try
            {
                bool respuesta = false;

                Usuario usuario = new Usuario()
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    FechaNacimiento = request.FechaNacimiento,
                    Sexo = request.Sexo,
                };

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    var existeUsuario = db.Usuario.Where(x => x.Id == request.Id).FirstOrDefault();

                    if (existeUsuario != null)
                    {
                        db.Entry(existeUsuario).CurrentValues.SetValues(usuario);
                        db.SaveChanges();

                        if (usuario.Id > 0)
                        {
                            respuesta = true;
                        }
                    }
                    else
                    {
                        respuesta = false;
                    }
                }

                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    JsonEntrada = JsonConvert.SerializeObject(request),
                    JsonSalida = respuesta.ToString(),
                    Codigo = 200,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return respuesta;
            }
            catch (Exception ex)
            {
                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Codigo = 500,
                    MensajeError = ex.Message,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return false;
            }
        }

        public static bool EliminarUsuario(long id)
        {
            try
            {
                bool respuesta = false;

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    var existeUsuario = db.Usuario.Where(x => x.Id == id).FirstOrDefault();

                    if (existeUsuario != null)
                    {
                        db.Usuario.Remove(existeUsuario);
                        db.SaveChanges();

                        var existeUsuarioAun = db.Usuario.Where(x => x.Id == id).FirstOrDefault();

                        if (existeUsuarioAun == null)
                        {
                            respuesta = true;
                        }
                    }                    
                }

                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    JsonEntrada = id.ToString(),
                    JsonSalida = respuesta.ToString(),
                    Codigo = 200,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return respuesta;
            }
            catch (Exception ex)
            {
                LogDTO log = new LogDTO()
                {
                    Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Codigo = 500,
                    MensajeError = ex.Message,
                    FechaRegisrtro = DateTime.Now,
                };

                Util.UtilApi.CrearLog(log);

                return false;
            }
        }
    }
}
