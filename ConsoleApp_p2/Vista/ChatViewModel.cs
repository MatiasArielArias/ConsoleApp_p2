using System.Collections.Generic;

namespace ConsoleApp_p2.Vista
{
    public class ChatViewModel
    {
        public string Nombre { get;  set; }
        public string Info { get;  set; }

        public List<MensajeViewModel> Mensajes { get; set; }

    }
}