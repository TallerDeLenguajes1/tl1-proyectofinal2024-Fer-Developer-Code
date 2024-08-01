using EspacioArteAscii.GUI;
using EspacioMostrarDatos.Helpers;
using EspacioPersonajes.PersonajesFiles;
namespace EspacioMenu
{
    public class MenuGrafico
    {
        ArteAscii ascii = new ArteAscii();
        private string textoEntrada;
        private string[] opciones;
        private string[] graficoAscii;
        private int indexSelec;

        public MenuGrafico(string[] GraficoAscii, string TextoEntrada, string[] opciones)
        {
            this.textoEntrada = TextoEntrada;
            this.opciones = opciones;
            this.graficoAscii = GraficoAscii;
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
                ascii.EscribirCentrado($"{prefijo} << {opcionActual} >>");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                ascii.CambiarColorTexto("naranja");
                ascii.CentrarAscii(graficoAscii);
                ascii.EscribirCentrado(textoEntrada);
                ascii.CambiarColorTexto("Blanco");
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
        public int RunCombate(Personaje luchador1, Personaje luchador2)
        {
            MostrarDatos showStats = new MostrarDatos();
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                showStats.MostrarCaracteristicasLadoALado(luchador1, luchador2, "Jugador", "Oponente");
                ascii.CambiarColorTexto("Rojo");
                ascii.CentrarAscii(graficoAscii);
                ascii.EscribirCentrado(textoEntrada);
                ascii.CambiarColorTexto("Blanco");
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
}