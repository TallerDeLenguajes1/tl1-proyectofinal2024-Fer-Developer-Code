using EspacioArteAscii.GUI;
namespace EspacioMenu
{
    public class MenuGrafico
    {
        ArteAscii ascii = new ArteAscii();
        private string textoEntrada;
        private string[] opciones;
        private int indexSelec;

        public MenuGrafico(string TextoEntrada, string[] opciones)
        {
            this.textoEntrada = TextoEntrada;
            this.opciones = opciones;
            this.indexSelec = 0;
        }
        private void MostrarOpciones()
        {
            Console.ResetColor();
            for (int i = 0; i < opciones.Length; i++)
            {
                string opcionActual = opciones[i];
                string prefijo;
                if (i == indexSelec)
                {
                    prefijo = "*";
                    ascii.CambiarColorTexto("Negro");
                    ascii.CambiarColorFondo("Blanco");
                }
                else
                {
                    prefijo = " ";
                    ascii.CambiarColorTexto("Blanco");
                    ascii.CambiarColorFondo("Negro");
                }
                Console.WriteLine($"{prefijo} << {opcionActual} >>");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Console.WriteLine(textoEntrada);
                MostrarOpciones();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //Actualizar index basado en flechas
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    indexSelec--;
                    if (indexSelec < 0)
                    {
                        indexSelec = opciones.Length - 1;//Te devuelve al ultimo item del menu
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    indexSelec++;
                    if (indexSelec >= opciones.Length)
                    {
                        indexSelec = 0; //Te devuelve al primer item del menu
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return indexSelec;
        }
    }
    //Environment.Exit(0);//Cierra la app
}