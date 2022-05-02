using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Vista.Pantallas
{
    public class MenuPrincipal
    {
        private ConsoleUtils ConsoleUtils = new ConsoleUtils();

        public MenuPrincipalOpt Mostrar()
        {

            string[] opts = Enum.GetNames(typeof(MenuPrincipalOpt));
            MenuPrincipalOpt[] valores = (MenuPrincipalOpt[])Enum.GetValues(typeof(MenuPrincipalOpt));


            Console.WriteLine("=====MSN MESSENGER=====");
            for (int i = 0; i < opts.Length; i++)
            {
                Console.WriteLine($"{i} - {opts[i]}");
            }



            int rv = ConsoleUtils.PedirIntEnRango("Su eleccion: ", 0, opts.GetUpperBound(0));


            return valores[rv];
        }



    }
}
