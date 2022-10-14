using PruebaComponente.API.Models;
using PruebaComponente.BLL.DTO;
using PruebaComponente.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace PruebaComponente.API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        [Route("echoping")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("echouser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        /// <summary>
        /// Metodo encargado de realizar la autenticación
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        /// <response code="200">Devuelve el token con las credenciales correctas</response>
        /// <response code="400">Las credenciales no son correctas por lo tanto no devuelve el token</response>
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var respuesta = Autentication.Login(loginDTO.UserName);
            string passencript = SHA256Encrypt(loginDTO.Password);

            bool isCredentialValid = (passencript.ToUpper() == respuesta.Password.ToUpper());
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.UserName);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }

            return null;
        }

        static public string SHA256Encrypt(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
    }
}