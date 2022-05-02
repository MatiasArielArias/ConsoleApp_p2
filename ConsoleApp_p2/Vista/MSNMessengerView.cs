using System;
using System.Collections.Generic;
using ConsoleApp_p2.Vista.Pantallas;


namespace ConsoleApp_p2.Vista
{
    public class MSNMessengerView
    {
        private MenuPrincipal MenuPrincipal = new MenuPrincipal();
        private PantallaDeChat PantallaDeChat = new PantallaDeChat();
        private PantallaSeleccionChat PantallaSeleccionChat = new PantallaSeleccionChat();
        private PantallaSeleccionContacto PantallaSeleccionContacto = new PantallaSeleccionContacto();
        private PantallaBuscarChats PantallaBuscarChats = new PantallaBuscarChats();
        private PantallaCrearContacto PantallaCrearContacto = new PantallaCrearContacto();



        /// <summary>
        /// Muestra un mensaje en rojo en pantalla y espera a que el usuario presione una tecla.
        /// </summary>
        /// <param name="msj"></param>
        public void MostrarError(string msj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msj);
            Console.ResetColor();
            
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }


        /// <summary>
        /// Muestra pantalla de chat.
        /// </summary>
        /// <param name="cvm"></param>
        /// <returns>El mensaje escrito por el usuario o null si decidio salir.</returns>
        public MensajeViewModel MostrarPantallaDeChat(ChatViewModel cvm)
        {
            if (cvm == null)
                throw new ArgumentNullException();
            Console.Clear();
            return this.PantallaDeChat.Mostrar(cvm);
        }


        /// <summary>
        /// Muestra pantalla de seleccion de chats
        /// </summary>
        /// <param name="cvm"></param>
        /// <returns>el index del chat elegido o -1 si eligio cancelar.</returns>
        public int MostrarPantallaSeleccionDeChat(List<ChatItemViewModel> cvm)
        {
            if (cvm == null)
                throw new ArgumentNullException();
            Console.Clear();
            return this.PantallaSeleccionChat.Mostrar(cvm);
        }

       

        /// <summary>
        /// Muestra la pantalla de creacion de contacto
        /// </summary>
        /// <returns>un nuevo contacto con la informacion provista o null si el usuario decidio cancelar</returns>
        public ContactoViewModel MostrarPantallaCrearContacto()
        {
            Console.Clear();
            return this.PantallaCrearContacto.Mostrar();
        }


        /// <summary>
        /// Muestra pantalla de seleccion de contactos
        /// </summary>
        /// <param name="cvm"></param>
        /// <returns>el index del contacto elegido o -1 si eligio cancelar.</returns>
        public int MostrarPantallaSeleccionDeContacto(List<ContactoViewModel> cvm)
        {
            if (cvm == null)
                throw new ArgumentNullException();
            Console.Clear();
            return this.PantallaSeleccionContacto.Mostrar(cvm);
        }

        /// <summary>
        /// Muestra el menu principal
        /// </summary>
        /// <returns>la opcion elegida por el usuario.</returns>
        public MenuPrincipalOpt MostarMenuPrincipal()
        {
            Console.Clear();
            return this.MenuPrincipal.Mostrar();
        }

        /// <summary>
        /// Muestra la pantalla de busqueda de chats.
        /// </summary>
        /// <returns>el termino indicado por el usuario o null si decidio cancelar la busqueda.</returns>
        public string MostrarPantallaDeBusqueda()
        {
            Console.Clear();
            return this.PantallaBuscarChats.Mostrar();
        }

    }
}
