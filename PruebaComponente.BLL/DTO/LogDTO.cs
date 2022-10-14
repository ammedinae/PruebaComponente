using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponente.BLL.DTO
{
    public class LogDTO
    {
        public string Metodo { get; set; }
        public string JsonEntrada { get; set; }
        public string JsonSalida { get; set; }
        public long Codigo { get; set; }
        public string MensajeError { get; set; }
        public DateTime FechaRegisrtro { get; set; }
    }
}
