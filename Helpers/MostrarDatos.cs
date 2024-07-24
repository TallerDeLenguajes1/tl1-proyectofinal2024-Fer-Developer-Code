using EspacioPersonajes.PersonajesFiles;
using EspacioJsonCreacion;
using System.Text;
using EspacioArteAscii.GUI;
namespace EspacioMostrarDatos.Helpers
{
    public class MostrarDatos
    {
        HistorialGanadoresJson archivosPjsGanadores = new HistorialGanadoresJson();
        ArteAscii ascii = new ArteAscii();
        public void MostrarCaracteristicas(Personaje personaje, string titulo)
        {
            // Crear un borde decorativo
            string borde = new string('-', Console.WindowWidth);//Imprime tantas lineas como ancho tenga la consola

            ascii.CambiarColorTexto("Cyan");
            EscribirLineaConEfecto(borde);
            ascii.CambiarColorTexto("Amarillo");
            ascii.EscribirCentrado($"{titulo}");
            ascii.EscribirCentrado($"Nombre: {personaje.Datos.Nombre}, Apodo: {personaje.Datos.Apodo}");
            ascii.EscribirCentrado($"Raza: {personaje.Datos.Raza}, Edad: {personaje.Datos.Edad}");
            ascii.CambiarColorTexto("Verde");
            ascii.EscribirCentrado($"Velocidad: {personaje.Caracteristicas.Velocidad}, Agilidad: {personaje.Caracteristicas.Agilidad}");
            ascii.EscribirCentrado($"Fuerza: {personaje.Caracteristicas.Fuerza}, Nivel: {personaje.Caracteristicas.Nivel}");
            ascii.EscribirCentrado($"Defensa: {personaje.Caracteristicas.Defensa}, Salud: {personaje.Caracteristicas.Salud}, Suerte: {personaje.Caracteristicas.Suerte}");
            ascii.CambiarColorTexto("Cyan");
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
            Console.Clear();
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

            foreach (HistorialPartida participante in ganadores)
            {
                MostrarCaracteristicas(participante.Ganador, "Ganadores del torneo");
                ascii.CambiarColorTexto("Magenta");
                EscribirLineaConEfecto($"Duración del torneo: {participante.InformacionPartida.Duracion} segundos");
                EscribirLineaConEfecto($"Cantidad de ataques: {participante.InformacionPartida.ContadorAtaques}");
                EscribirLineaConEfecto($"Hora de la victoria: {participante.InformacionPartida.Fecha.Hour:D2}:{participante.InformacionPartida.Fecha.Minute:D2}");//Este enfoque garantiza que los números de un solo dígito se presenten con un cero inicial, dando como resultado algo como "Hora de la victoria: 18:08" en lugar de "Hora de la victoria: 18:8".
                EscribirLineaConEfecto($"El dia {participante.InformacionPartida.Fecha.Day} del mes {participante.InformacionPartida.Fecha.Month}");
                ascii.CambiarColorTexto("Magenta");
            }
            Console.ResetColor();
        }
        public void MostrarInformacionCombate(Personaje luchador1, Personaje luchador2)
        {
            Console.Clear(); // Limpiar la consola al principio de cada turno
            ascii.CambiarColorTexto("Amarillo");
            string presentacion = $"¡Combate entre {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre}!";

            ascii.CentrarAscii(ascii.AsciiCombate);
            ascii.EscribirCentrado(presentacion);
            ascii.EscribirCentrado("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            // Mostrar características de ambos luchadores
            MostrarCaracteristicas(luchador1, "Jugador");
            MostrarCaracteristicas(luchador2, "Oponente");
            Console.WriteLine();
        }
    }
}