using Newtonsoft.Json;
using PruebaComponente.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponente.BLL.Util
{
    class UtilApi
    {
        public static string ObtenerToken()
        {
            try
            {
                string tokens = null;
                string Url = "https://localhost:44329/";
                HttpClient tokenHttp = new HttpClient();
                tokenHttp.BaseAddress = new Uri(Url);

                var user = "UserPrueba";
                var password = "UserPrueba";

                var Request = new Dictionary<string, string>
                    {
                        {"UserName", user },
                        {"Password", password }
                    };
                var APIResponse = tokenHttp.PostAsync("api/login/authenticate", new FormUrlEncodedContent(Request)).Result;
                if (APIResponse.IsSuccessStatusCode)
                {
                    var resultString = APIResponse.Content.ReadAsStringAsync().Result;
                    tokens = JsonConvert.DeserializeObject<string>(resultString);
                }

                return tokens;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool CrearLog(LogDTO logDTO)
        {
            bool Validar = false;

            string Url = "https://localhost:44329/api/Log/LogCreate";
            string Token = ObtenerToken();
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        request.Content = new StringContent(JsonConvert.SerializeObject(logDTO), Encoding.UTF8, "application/json");
                        var Respuesta = httpClient.SendAsync(request).Result;

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            Validar = true;
                        }
                    }
                }
            }
            return Validar;
        }
    }
}
