using System;
using System.Collections.Generic;

namespace ConsoleApp_p2.Vista.Pantallas
{
    public class PantallaSeleccionContacto
    {
        private ConsoleUtils ConsoleUtils = new ConsoleUtils();

        public int Mostrar(List<ContactoViewModel> contactos)
        {

            for (int i = 0; i < contactos.Count; i++)
            {
                MostrarContacto(i, contactos[i]);
            }

            Console.WriteLine($"{contactos.Count} - Cancelar");

            int rv = ConsoleUtils.PedirIntEnRango("Su eleccion: ", 0, contactos.Count);

            if (rv == contactos.Count)
                return -1;

            return rv;
        }

        private void MostrarContacto(int i, ContactoViewModel contacto)
        {
            Console.WriteLine($"|{i} - {contacto.Nombre}");
            Console.WriteLine($"|{contacto.Info}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
