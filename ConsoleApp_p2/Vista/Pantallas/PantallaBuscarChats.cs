using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Vista.Pantallas
{
    public class PantallaBuscarChats
    {
        private ConsoleUtils ConsoleUtils = new ConsoleUtils();

        public string Mostrar()
        {
            string rv = ConsoleUtils.PedirString("Indique termino de busqueda (Deje vacio para salir):");

            if (rv.Length == 0)
                return null;
            return rv;
        }

    }
}
