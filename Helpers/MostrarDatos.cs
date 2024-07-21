using EspacioPersonajes.PersonajesFiles;
using EspacioJsonCreacion;
using System.Text;
using EspacioArteAscii.GUI;
namespace EspacioMostrarDatos.Helpers
{
    public class MostrarDatos
    {
        HistorialJson archivosPjsGanadores = new HistorialJson();
        ArteAscii ascii = new ArteAscii();
        public void MostrarCaracteristicas(Personaje personaje, string titulo)
        {
            // Crear un borde decorativo
            string borde = new string('-', Console.WindowWidth);//Imprime tantas lineas como ancho tenga la consola

            ascii.CambiarColorTexto("Cyan");
            EscribirLineaConEfecto(borde);
            ascii.CambiarColorTexto("Amarillo");
            Console.WriteLine($"{titulo}");
            Console.WriteLine($"Nombre: {personaje.Datos.Nombre}, Apodo: {personaje.Datos.Apodo}");
            Console.WriteLine($"Raza: {personaje.Datos.Raza}, Edad: {personaje.Datos.Edad}");
            ascii.CambiarColorTexto("Verde");
            Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}, Destreza: {personaje.Caracteristicas.Agilidad}");
            Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}, Nivel: {personaje.Caracteristicas.Nivel}");
            Console.WriteLine($"Armadura: {personaje.Caracteristicas.Defensa}, Salud: {personaje.Caracteristicas.Salud}, Suerte: {personaje.Caracteristicas.Suerte}");
            ascii.CambiarColorTexto("Cyan");
            Console.WriteLine(borde);
            Console.ResetColor();
        }

        private static void EscribirConEfecto(string texto)
        {
            foreach (char c in texto)
            {
                Console.Write(c);
            }
        }
        private static void EscribirLineaConEfecto(string texto)
        {
            int posicionX = (Console.WindowWidth - texto.Length) / 2;
            Console.SetCursorPosition(posicionX, Console.CursorTop);
            EscribirConEfecto(texto);
            Console.WriteLine();
        }

        public void EscribirHistorialGanadores(string rutaGanadores)
        {
            List<HistorialPartida> ganadores = archivosPjsGanadores.LeerGanadores(rutaGanadores);
            if (ganadores.Count == 0)
            {
                ascii.CambiarColorTexto("Rojo");
                EscribirLineaConEfecto("No hay ganadores registrados.");
                Console.ResetColor();
                return;
            }

            ascii.CambiarColorTexto("Cyan");
            EscribirLineaConEfecto("Historial de ganadores:");
            ascii.CambiarColorTexto("Verde");

            foreach (HistorialPartida ganador in ganadores)
            {
                MostrarCaracteristicas(ganador.Ganador, "Ganadores del torneo");
                ascii.CambiarColorTexto("Magenta");
                EscribirLineaConEfecto($"Duración del torneo: {ganador.InformacionPartida.Duracion} segundos");
                EscribirLineaConEfecto($"Cantidad de ataques: {ganador.InformacionPartida.ContadorAtaques}");
                EscribirLineaConEfecto($"Hora de la victoria: {ganador.InformacionPartida.Hora.Hour}:{ganador.InformacionPartida.Hora.Minute}");
                ascii.CambiarColorTexto("Magenta");
            }

            Console.ResetColor();
        }

    }
}