using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PruebaComponente.Web.Util
{
    public class util
    {
        public static void Succes(Page page, string message, string url)
        {
            string mensaje = "swal.fire({" +
                                    "title: 'Correcto'," +
                                    "text: '" + message + ".'," +
                                    "icon: 'success'," +
                                    "confirmButtonColor: '#4caf50'," +
                                    "confirmButtonText: 'Aceptar'" +
                                    "}).then((result)=> {" +
                                    "if(result.value){" +
                                    "window.location.href = '" + url + "'" +
                                    "}" +
                                    "setTimeout(() => location.href = '" + url + "', 10000);" +
                                    "});";

            ScriptManager.RegisterStartupScript(page, page.GetType(), "Message", mensaje, true);
        }

        public static void Info(Page page, Type type, string message)
        {
            string mensaje = "swal.fire('Info','" + message + "','info');";
            ScriptManager.RegisterStartupScript(page, type, "Message", mensaje, true);
        }

        public static void Alert(Page page, string message, string url)
        {
            string mensaje = "swal.fire({" +
                                    "title: 'Alerta'," +
                                    "text: '" + message + ".'," +
                                    "icon: 'warning'," +
                                    "confirmButtonColor: '#4caf50'," +
                                    "confirmButtonText: 'Aceptar'" +
                                    "}).then((result)=> {" +
                                    "if(result.value){" +
                                    "window.location.href = '" + url + "'" +
                                    "}" +
                                    "setTimeout(() => location.href = '" + url + "', 10000);" +
                                    "});";

            ScriptManager.RegisterStartupScript(page, page.GetType(), "Message", mensaje, true);
        }

        public static void Error(Page page, Type type, string message)
        {
            string mensaje = "swal.fire({" +
                "title: 'Error'," +
                "text: '" + message + ".'," +
                "icon: 'error'," +
                "showConfirmButton: 'false'," +
                "timer: '1500'}); ";
            ScriptManager.RegisterStartupScript(page, type, "Message", mensaje, true);
        }

    }
}