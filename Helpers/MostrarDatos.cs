using EspacioPersonajes.PersonajesFiles;
using EspacioJsonCreacion;
using EspacioConstantes.Helpers;
using EspacioArteAscii.GUI;
namespace EspacioMostrarDatos.Helpers
{
    public class MostrarDatos
    {
        HistorialGanadoresJson archivosPjsGanadores = new HistorialGanadoresJson();
        ArteAscii ascii = new ArteAscii();
        public void MostrarCaracteristicasLadoALado(Personaje jugador, Personaje oponente, string tituloJugador, string tituloOponente)
        {
            int mitadAncho = Console.WindowWidth / 2;

            // Crear el borde superior
            ascii.CambiarColorTexto("Cyan");
            Console.WriteLine(new string('-', Console.WindowWidth));

            // Dibujar la línea vertical
            for (int i = 1; i < CalcularAlturaMaxima(jugador, oponente) + 2; i++)
            {
                Console.SetCursorPosition(mitadAncho, i);
                Console.Write("|");
            }

            // Mostrar características del jugador
            ascii.CambiarColorTexto("Amarillo");
            MostrarCaracteristicasJugador(jugador, tituloJugador, 0, mitadAncho);

            // Mostrar características del oponente
            ascii.CambiarColorTexto("Amarillo");
            MostrarCaracteristicasJugador(oponente, tituloOponente, mitadAncho + 1, mitadAncho);

            // Dibujar la línea horizontal para el menú de combate
            int lineaHorizontalY = CalcularAlturaMaxima(jugador, oponente) + 2;
            Console.SetCursorPosition(0, lineaHorizontalY);
            ascii.CambiarColorTexto("Cyan");
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.ResetColor();
        }

        private int CalcularAlturaMaxima(Personaje jugador, Personaje oponente)
        {
            int alturaJugador = CalcularAltura(jugador);
            int alturaOponente = CalcularAltura(oponente);
            return Math.Max(alturaJugador, alturaOponente);
        }

        private int CalcularAltura(Personaje personaje)
        {
            // Contar el número de líneas necesarias para mostrar todas las características del personaje
            int lineas = 0;
            lineas++; // Título
            lineas++; // Nombre y Apodo
            lineas++; // Raza y Edad
            lineas++; // Velocidad y Agilidad
            lineas++; // Fuerza y Nivel
            lineas++; // Defensa, Salud y Suerte
            return lineas;
        }

        private void MostrarCaracteristicasJugador(Personaje personaje, string titulo, int inicioX, int anchoMaximo)
        {
            int y = 1;
            ascii.CambiarColorTexto("Amarillo");
            EscribirTextoCentradoEnCuadro(inicioX, y++, titulo, anchoMaximo);
            EscribirTextoCentradoEnCuadro(inicioX, y++, $"Nombre: {personaje.Datos.Nombre}", anchoMaximo);
            EscribirTextoCentradoEnCuadro(inicioX, y++, $"Apodo: {personaje.Datos.Apodo}", anchoMaximo);
            EscribirTextoCentradoEnCuadro(inicioX, y++, $"Raza: {personaje.Datos.Raza}, Edad: {personaje.Datos.Edad}", anchoMaximo);
            ascii.CambiarColorTexto("Verde");
            EscribirTextoCentradoEnCuadro(inicioX, y++, $"Velocidad: {personaje.Caracteristicas.Velocidad}, Agilidad: {personaje.Caracteristicas.Agilidad}", anchoMaximo);
            EscribirTextoCentradoEnCuadro(inicioX, y++, $"Fuerza: {personaje.Caracteristicas.Fuerza}, Nivel: {personaje.Caracteristicas.Nivel}", anchoMaximo);
            EscribirTextoCentradoEnCuadro(inicioX, y++, $"Defensa: {personaje.Caracteristicas.Defensa}, Salud: {personaje.Caracteristicas.Salud}, Suerte: {personaje.Caracteristicas.Suerte}", anchoMaximo);
        }

        private void EscribirTextoCentradoEnCuadro(int inicioX, int y, string texto, int anchoMaximo)
        {
            int posicionX = inicioX + (anchoMaximo - texto.Length) / 2;
            Console.SetCursorPosition(posicionX, y);
            Console.WriteLine(texto);
        }

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
        public void MostrarInformacionCombate(Personaje luchador1, Personaje luchador2, int numBatalla)
        {
            int totalEnemigos = Constantes.MaxEnemigos;
            Console.Clear(); // Limpiar la consola al principio de cada turno
            ascii.CambiarColorTexto("Amarillo");
            string presentacion;
            if (numBatalla == totalEnemigos)
            {
                ascii.CambiarColorTexto("Rojo");
                presentacion = $"¡COMBATE FINAL: {luchador1.Datos.Nombre} Y {luchador2.Datos.Nombre} AL CAMPO DE BATALLA!";
            }
            else
            {
                presentacion = $"¡Combate numero {numBatalla} entre {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre}!";
            }
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