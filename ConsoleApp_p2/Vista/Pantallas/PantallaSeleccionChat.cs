using System;
using System.Collections.Generic;
 

namespace ConsoleApp_p2.Vista.Pantallas
{
    public class PantallaSeleccionChat
    {
        private ConsoleUtils ConsoleUtils = new ConsoleUtils();

        public int Mostrar(List<ChatItemViewModel> chats)
        {
            Console.WriteLine("Seleccion de chat:");

            for (int i = 0; i < chats.Count; i++)
            {
                MostrarChat(i, chats[i]);
            }

            Console.WriteLine($"{chats.Count} - Cancelar");

            int rv = ConsoleUtils.PedirIntEnRango("Su eleccion: ", 0, chats.Count);

            if (rv == chats.Count)
                return -1;

            return rv;
        }

        private void MostrarChat(int i, ChatItemViewModel chatItemViewModel)
        {
            Console.WriteLine($"|{i} - {chatItemViewModel.Nombre} ({chatItemViewModel.CantMsjsNuevos} Nuevos)");
            Console.WriteLine($"|{chatItemViewModel.Info}");
            Console.WriteLine($"|{chatItemViewModel.UltimoMsj}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
