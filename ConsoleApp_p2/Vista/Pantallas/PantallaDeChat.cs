using System;



namespace ConsoleApp_p2.Vista.Pantallas
{
    public class PantallaDeChat
    {
        private ConsoleUtils ConsoleUtils = new ConsoleUtils();


        public MensajeViewModel Mostrar(ChatViewModel cvm)
        {
            MostrarInfoContacto(cvm.Nombre, cvm.Info);

            for (int i = 0; i < cvm.Mensajes.Count; i++)
            {
                MostrarMensaje(cvm, i, cvm.Mensajes[i]);

            }

            Console.WriteLine("Ayuda: \":salir\" | \":nro\" para citar un mensaje| \":-1\" para cancelar cita");
            int msjindex = -1;
            string msj = "";

            while (msj.Length == 0)
            {

                msj = ConsoleUtils.PedirString("Usted > ");

                if (msj.Length > 0)
                {
                    if (msj.StartsWith(":"))
                    {
                        string cmd = msj.Substring(1);
                        if (cmd.ToLower() == "salir")
                            return null;

                        if (!int.TryParse(cmd, out msjindex) || msjindex >= cvm.Mensajes.Count)
                        {
                            Console.WriteLine("comando invalido.");
                            msjindex = -1;
                        }
                        else
                        {
                            if (msjindex < 0)
                                Console.WriteLine($"Cita cancelada");
                            else
                                Console.WriteLine($"Citando mensaje [{msjindex}]");
                        }

                        msj = "";
                    }
                    else
                    {
                        return new MensajeViewModel()
                        {
                            EsMio = true,
                            Texto = msj,
                            MensajeCitadoIndex = msjindex
                        };
                    }
                }
            }



            return null;
        }


        private string FormatearFecha(DateTime fechaHora)
        {
            return $"{fechaHora.Day:00}/{fechaHora.Month:00}/{fechaHora.Year} {fechaHora.Hour:00}:{fechaHora.Minute:00}";
        }


        private void MostrarCita(ChatViewModel cvm, int msjIndex, bool esMia, int an)
        {

            MensajeViewModel msj = cvm.Mensajes[msjIndex];


            string fecha;
            string quien = "Yo";
            string txt = $"||{msj.Texto}";



            if (!msj.EsMio)
                quien = cvm.Nombre;

            fecha = $"||{quien} - {FormatearFecha(msj.FechaHora)}";

            if (esMia)
            {
                Console.WriteLine(fecha.PadRight(an).PadLeft(Console.WindowWidth));
                Console.WriteLine(txt.PadRight(an).PadLeft(Console.WindowWidth));
            }
            else
            {
                Console.WriteLine(fecha);
                Console.WriteLine(txt);
            }

        }


        private void MostrarMensaje(ChatViewModel cvm, int index, MensajeViewModel msj)
        {
            string texto = $"|{msj.Texto}";
            string fecha = FormatearFecha(msj.FechaHora);

            int maxLen = CalcularMaxLen(cvm, msj);


            if (msj.EsMio)
            {
                string visto = "";
                if (msj.Visto)
                {
                    visto = "(visto)";
                }

                texto = texto.PadRight(maxLen).PadLeft(Console.WindowWidth);
                Console.WriteLine($"|[{index}] Yo - {fecha} {visto}".PadRight(maxLen).PadLeft(Console.WindowWidth));
            }
            else
            {
                Console.WriteLine($"|[{index}] {cvm.Nombre} - {fecha}");
            }

            if (msj.MensajeCitadoIndex > -1)
            {
                MostrarCita(cvm, msj.MensajeCitadoIndex, msj.EsMio, maxLen);
            }

            Console.WriteLine(texto);


            Console.WriteLine();
        }

        private int CalcularMaxLen(ChatViewModel cvm, MensajeViewModel msj)
        {
            int maxLen = Math.Max(msj.Texto.Length + 1, 45);




            if (msj.MensajeCitadoIndex > -1)
            {
                MensajeViewModel msjresp = cvm.Mensajes[msj.MensajeCitadoIndex];
                maxLen = Math.Max(maxLen, msjresp.Texto.Length + 2);
                maxLen = Math.Max(maxLen, cvm.Nombre.Length);
            }



            return maxLen;
        }

        private void MostrarInfoContacto(string nombre, string info)
        {
            Console.WriteLine("".PadRight(Console.WindowWidth, '='));
            Console.WriteLine(nombre);
            Console.WriteLine(info);
            Console.WriteLine("".PadRight(Console.WindowWidth, '='));
        }
    }
}
