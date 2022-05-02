using System;

namespace ConsoleApp_p2.Vista
{
    public class MensajeViewModel
    {

        public DateTime FechaHora { get; set; } = DateTime.Now;
        public string Texto { get; set; }
        public bool EsMio { get; set; } = false;
        public bool Visto { get; set; }

        public int MensajeCitadoIndex { get; set; } = -1;
    }
}
