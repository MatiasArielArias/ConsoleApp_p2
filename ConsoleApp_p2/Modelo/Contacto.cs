using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Modelo
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Info { get; set; }

        public Contacto(string nombre, string info)
        {
            if(nombre !=null && info != null)
            {
                this.Nombre = nombre;
                this.Info = info;
            }
        }

    }
}
