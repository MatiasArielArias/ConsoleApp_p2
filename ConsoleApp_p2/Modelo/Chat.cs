using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Modelo
{
    public class Chat
    {
        public Contacto contacto = new Contacto("Cargainicial", "Cargainicial");
        public List<Mensaje> mensajes = new List<Mensaje>();
        public Random Rng = new Random();

        public Chat(Contacto contacto)
        {
            this.contacto = contacto;
        }
        public int ContactoNoLeidos()
        {
            int mensajesNoLeidos = 0;
            foreach (Mensaje msj in mensajes)
            {
                if (!msj.EsMio && !msj.Visto)
                {
                    mensajesNoLeidos += 1;
                }

            }

            return mensajesNoLeidos;
        }
        public void Enviar(Mensaje mensaje)
        {
            if (!mensaje.texto.Contains("") || !mensaje.texto.Equals(null))
            {
                mensaje.EsMio = true;
                mensajes.Add(mensaje);
            }


        }
        public bool ContieneTermino(string textoABuscar)
        {
            for (int i = 0; i < mensajes.Count; i++)
            {
                if (mensajes[i].texto.Contains(textoABuscar))
                {
                    return true;
                }

            }
            return false;
        }
        public void ActualizarVisto()
        {
            for (int i = 0; i < mensajes.Count; i++)
            {
                if (!mensajes[i].EsMio && !mensajes[i].Visto)
                {
                    mensajes[i].Visto = true;
                }
            }
        }

        public int IndexDe(Mensaje mensaje)
        {

            for (int i = 0; i < mensajes.Count; i++)
            {
                if (!mensajes[i].texto.Contains(mensaje.texto))
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Refrescar()
        {
            int numero = Rng.Next(0, 100);
            Mensaje msjRobot = new Mensaje();
            if (numero < 25)
            {
                for (int i = 0; i < mensajes.Count; i++)
                    if (mensajes[i].EsMio)
                    {
                        mensajes[i].Visto = true;
                    }

                if (mensajes.Count == 0)
                {

                    msjRobot.texto = "Hola, ¿Como estas?";
                    mensajes.Add(msjRobot);
                }
                if (mensajes[mensajes.Count - 1].EsMio)
                {


                    msjRobot.texto = mensajes[mensajes.Count - 1].texto.ToUpper();
                    mensajes.Add(msjRobot);

                }
                else 
                {

                    msjRobot.texto = "Respondeme pliz";
                    mensajes.Add(msjRobot);

                }
                return true;
            }
            return false;
        }
        
    
    }
}
