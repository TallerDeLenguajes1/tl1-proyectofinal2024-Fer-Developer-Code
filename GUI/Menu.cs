using EspacioArteAscii.GUI;
namespace EspacioMenu
{
    public class Menu
    {
        ArteAscii ascii = new ArteAscii();
        private string info;
        private string[] opciones;
        private int index;
        public Menu(string Info, string[] opciones)
        {
            this.info = Info;
            this.opciones = opciones;
            this.index = 0;
        }
        private void MostrarOpciones()
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                string opcionActual = opciones[i];
                string prefijo;
                if (i == index)
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
        public int Run(){
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                MostrarOpciones();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
            } while (keyPressed != ConsoleKey.Enter);
            return index;
        }
    }
}