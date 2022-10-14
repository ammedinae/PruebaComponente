using PruebaComponente.BLL.DTO;
using PruebaComponente.BLL.Services;
using PruebaComponente.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaComponente.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Log")]
    public class LogController : ApiController
    {
        [HttpPost]
        [Route("LogCreate")]
        public IHttpActionResult LogCreate([FromBody] LogDTO logDTO)
        {
            bool valida = Log.GuardarLog(logDTO);

            if (valida)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}