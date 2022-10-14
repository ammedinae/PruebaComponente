using PruebaComponente.BLL.DTO;
using PruebaComponente.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponente.BLL.Services
{
    public class Log
    {
        public static bool GuardarLog(LogDTO logDTO)
        {
            try
            {
                bool respuesta = false;

                using (dboPruebaComponenteEntities db = new dboPruebaComponenteEntities())
                {
                    LogTransaccion log = new LogTransaccion()
                    {
                        Metodo = logDTO.Metodo,
                        JsonEntrada = logDTO.JsonEntrada,
                        JsonSalida = logDTO.JsonSalida,
                        Codigo = logDTO.Codigo,
                        MensajeError = logDTO.MensajeError,
                        FechaRegistro = logDTO.FechaRegisrtro,
                    };

                    db.LogTransaccion.Add(log);
                    db.SaveChanges();

                    if (log.Id > 0)
                    {
                        respuesta = true;
                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }
    }
}
