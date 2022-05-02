using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp_p2.Modelo
{
    public class BD
    {
        public  List<Contacto> contactosFijos = new List<Contacto>();


        public BD()
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Contacto a = new Contacto("PEPE", "PEPE ARGENTO");
            Contacto b = new Contacto("Rmon", "Un tipazo");
            Contacto c = new Contacto("Juan", "Domingo no hablar");
            contactosFijos.Add(a);
            contactosFijos.Add(b);
            contactosFijos.Add(c);
        }
    }
}
