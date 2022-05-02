using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Vista.Pantallas
{
    public class PantallaCrearContacto
    {
        private ConsoleUtils ConsoleUtils = new ConsoleUtils();

        public ContactoViewModel Mostrar()
        {
            string nombre;
            string info;

            Console.WriteLine("Nuevo Contacto:");

            if ((nombre = ConsoleUtils.PedirString("Nombre (vacio para cancelar): ")).Length == 0)
                return null;

            if ((info = ConsoleUtils.PedirString("Info (vacio para cancelar): ")).Length == 0)
                return null;

            return new ContactoViewModel()
            {
                Nombre = nombre,
                Info = info
            };
        }

    }
}
