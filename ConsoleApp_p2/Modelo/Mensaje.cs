using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Modelo
{
    public class Mensaje
    {
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public string texto { get; set; }
        public bool EsMio { get; set; }
        public bool Visto { get; set; }
        public string MensajeRespondido { get; set; }
    }
}
