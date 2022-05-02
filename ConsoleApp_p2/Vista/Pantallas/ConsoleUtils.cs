using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Vista.Pantallas
{
    public class ConsoleUtils
    {
        public string PedirString(string msj)
        {
            Console.Write(msj);
            return Console.ReadLine();
        }

        public int PedirIntEnRango(string msj, int min, int max)
        {
            int rv;

            while (!int.TryParse(PedirString(msj), out rv) || rv < min || rv > max) ;

            return rv;
        }
    }
}
