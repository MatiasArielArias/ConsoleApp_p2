
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_p2.Modelo
{
    public class MSNMessenger
    {
        public List<Contacto> contactos = new List<Contacto>();
        public List<Chat> chats = new List<Chat>();
        public BD bd = new BD();
        public bool AgregarContacto(Contacto contactoAAgregar)
        {
            
            for (int i =0;i<contactos.Count;i++)
            {
                if(contactos[i].Nombre.ToUpper()== contactoAAgregar.Nombre.ToUpper())
                {
                    return false;

                }
            }
            contactos.Add(contactoAAgregar); ;
            return true;
        }
        public Chat AgregarChat (Contacto contacto)
        {
            for (int i = 0; i < chats.Count; i++)
            {
                if (chats[i].contacto.Nombre.ToUpper().Equals(contacto.Nombre.ToUpper()))
                {
                    return chats[i];
                }    

            }
            Chat nuevoChat = new Chat(contacto);
            chats.Add(nuevoChat);
            return chats[chats.Count - 1];
        }
        public void Refescar ()
        {
            for(int i = 0; i <chats.Count;i++)
            {
                chats[i].Refrescar();
            }
        }
        public List<Chat> BuscarChats(string termino)
        { 
            List<Chat> chatARetornar = chats;
            chatARetornar.Clear();

            for(int i = 0; i < chats.Count; i++)
            {
                for (int j = 0;j< chats[i].mensajes.Count; j++)
                {
                    if (chats[i].mensajes[j].texto.Contains(termino) && !chatARetornar.Contains(chats[i]))
                    {
                        chatARetornar.Add(chats[i]);
                    }
                }
            }
                return chatARetornar;
        }
        public void CargarContactosFijos()
        {
            this.contactos = this.bd.contactosFijos;
        }
    }
}
