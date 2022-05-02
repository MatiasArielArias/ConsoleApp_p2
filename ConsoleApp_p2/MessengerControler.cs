using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_p2.Vista;
using ConsoleApp_p2.Modelo;


namespace ConsoleApp_p2s
{
    public class MessengerController
    {
        private MSNMessenger Modelo = new MSNMessenger();

        private MSNMessengerView Vista = new MSNMessengerView();



        public void Funcionar ()
        {
            this.Modelo.CargarContactosFijos();
            int opcion = -1;
            while (true)
            { 
               opcion=(int)this.Vista.MostarMenuPrincipal();
                if (opcion == 0)
                {
                    this.Modelo.Refescar();
                    NuevoContacto();
                }
                if (opcion == 1)
                {
                    this.Modelo.Refescar();
                    NuevoChat();
                }
                if (opcion == 2)
                {
                    this.Modelo.Refescar();
                    VerChats(this.Modelo.chats);
                }
                if (opcion == 3)
                {
                    this.Modelo.Refescar();
                    BuscarChats();

                }
            }

        }

        private void BuscarChats()
        {
            
            List<Chat> chats = new List<Chat>();
            string termino;
            termino = this.Vista.MostrarPantallaDeBusqueda();
            if(termino != null)
            {
                for (int i =0; i< this.Modelo.chats.Count; i ++)
                {
                    if(this.Modelo.chats[i].ContieneTermino(termino))
                    {
                        chats.Add(this.Modelo.chats[i]);
                    }
                }

                VerChats(chats);
            }
           
        }

        private void VerChats(List<Chat> chats)
        {
            int elec;
            List<ChatItemViewModel> chatsItemViews = new List<ChatItemViewModel>();
            
            for(int i = 0; i <chats.Count; i++)
            {
                ChatItemViewModel chatsView = new ChatItemViewModel();
                chatsView.Nombre = chats[i].contacto.Nombre;
                chatsView.Info = chats[i].contacto.Info;
                chatsView.CantMsjsNuevos = chats[i].ContactoNoLeidos();
                chatsView.UltimoMsj = chats[i].mensajes[chats[i].mensajes.Count - 1].texto ;

                chatsItemViews.Add(chatsView);
            }
            elec = this.Vista.MostrarPantallaSeleccionDeChat(chatsItemViews);
            if (elec != -1)
            {
                for (int i = 0; i < this.Modelo.contactos.Count; i++)
                {
                    if (chatsItemViews[elec].Nombre == this.Modelo.contactos[i].Nombre)
                    {
                        Chatear(this.Modelo.AgregarChat(this.Modelo.contactos[i]));
                    }
                }
            }
        }

        public void NuevoContacto()
        {

            ContactoViewModel a;
            a= this.Vista.MostrarPantallaCrearContacto();
            if (a != null)
            {
                Contacto contacto = new Contacto(a.Nombre, a.Info);
                if(!this.Modelo.AgregarContacto(contacto))
                {
                    this.Vista.MostrarError("Error para cargar. No se pudo agregar");
                }
            }
            

        }

        public void Chatear(Chat chat)
        {
            ChatViewModel vistaChat = new ChatViewModel();
            vistaChat.Mensajes = new List<MensajeViewModel>();
            MensajeViewModel mensajeView = new MensajeViewModel();

            vistaChat.Nombre = chat.contacto.Nombre;
            vistaChat.Info = chat.contacto.Info;
            for (int i = 0; i < chat.mensajes.Count; i++)
            {
                
                MensajeViewModel mensajeFor = new MensajeViewModel();
                chat.mensajes[i].Visto = true;

                mensajeFor.FechaHora = chat.mensajes[i].FechaHora;
                mensajeFor.Texto = chat.mensajes[i].texto;
                mensajeFor.EsMio = chat.mensajes[i].EsMio;
                mensajeFor.Visto = chat.mensajes[i].Visto;

                vistaChat.Mensajes.Add(mensajeFor);
            }

            mensajeView = this.Vista.MostrarPantallaDeChat(vistaChat);
            while (mensajeView != null)
            {
                Mensaje mensaje = new Mensaje();
                mensaje.FechaHora = mensajeView.FechaHora;
                mensaje.texto = mensajeView.Texto;
                mensaje.EsMio = mensajeView.EsMio;
                mensaje.Visto = mensajeView.Visto;

                chat.Enviar(mensaje);
                chat.ActualizarVisto();
                chat.Refrescar();

                vistaChat.Mensajes.Add(mensajeView);

               
                if (vistaChat.Mensajes.Count != chat.mensajes.Count)
                {
                    MensajeViewModel mensajeIf = new MensajeViewModel();

                    mensajeIf.FechaHora = chat.mensajes[chat.mensajes.Count - 1].FechaHora;
                    mensajeIf.Texto = chat.mensajes[chat.mensajes.Count - 1].texto;
                    mensajeIf.EsMio = chat.mensajes[chat.mensajes.Count - 1].EsMio;
                    mensajeIf.Visto = chat.mensajes[chat.mensajes.Count - 1].Visto;

                    vistaChat.Mensajes.Add(mensajeIf);
                }

                mensajeView = this.Vista.MostrarPantallaDeChat(vistaChat);
            }
        }
        private void NuevoChat()
        {
            int elec;
            List<ContactoViewModel> contactoList = new List<ContactoViewModel>();
            for (int i = 0; i < this.Modelo.contactos.Count; i++)
            {
                ContactoViewModel contactoView = new ContactoViewModel();
                contactoView.Nombre = this.Modelo.contactos[i].Nombre;
                contactoView.Info = this.Modelo.contactos[i].Info;
                contactoList.Add(contactoView);

            }

           
            elec = this.Vista.MostrarPantallaSeleccionDeContacto(contactoList);
            if(elec != -1)
            {
                Chatear(this.Modelo.AgregarChat(this.Modelo.contactos[elec]));
            }

        }

    }
}
