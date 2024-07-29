using EspacioPersonajes.PersonajesFiles;
using EspacioMostrarDatos.Helpers;
using EspacioJsonCreacion;
using System.Diagnostics;
using EspacioArteAscii.GUI;
using EspacioMenu;

namespace EspacioSimularTorneo
{
    public class ClaseSimularTorneo
    {
        // En caso de que el jugador sea derrotado simula un torneo entre los personajes restantes
        public void SimularTorneo(List<Personaje> listaPersonajes, string rutaGanadores, Stopwatch stopwatch)
        {
            ArteAscii ascii = new ArteAscii();
            HistorialGanadoresJson archivosPjsGanadores = new HistorialGanadoresJson();
            MostrarDatos showStats = new MostrarDatos();

            int cantidadCombates = listaPersonajes.Count();
            int numeroCombate = 1;

            // Continuar el stopwatch si no se había detenido en ComenzarTorneo
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            Random RandomGenerator = new Random();
            while (listaPersonajes.Count > 1)
            {
                int posicion1 = RandomGenerator.Next(listaPersonajes.Count);
                Personaje luchador1 = listaPersonajes[posicion1];
                listaPersonajes.RemoveAt(posicion1);

                int posicion2 = RandomGenerator.Next(listaPersonajes.Count);
                Personaje luchador2 = listaPersonajes[posicion2];
                listaPersonajes.RemoveAt(posicion2);

                Console.Clear();
                if (numeroCombate == cantidadCombates)
                {
                    ascii.EscribirCentrado($"FINAL COMBAT entre los NPCs {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre} pertenecientes al juego");
                }
                else
                {
                    ascii.EscribirCentrado($"Combate numero {numeroCombate} entre los NPCs {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre} pertenecientes al juego");
                }

                showStats.MostrarCaracteristicas(luchador1, "Luchador 1");
                showStats.MostrarCaracteristicas(luchador2, "Luchador 2");
                string borde = new string('-', Console.WindowWidth);
                Console.WriteLine(borde);

                while (luchador1.Caracteristicas.Salud > 0 && luchador2.Caracteristicas.Salud > 0)
                {
                    ascii.CambiarColorTexto("Amarillo");
                    luchador1.Atacar(luchador2);
                    ascii.EscribirCentrado($"Vida de luchador 2 {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}");
                    Console.ResetColor();

                    //Thread.Sleep(2000); // Pausa de 2 segundos

                    if (luchador2.Caracteristicas.Salud <= 0)
                    {
                        ascii.EscribirCentrado($"{luchador1.Datos.Nombre} ha ganado el combate.");
                        listaPersonajes.Add(luchador1);
                        break;
                    }

                    ascii.CambiarColorTexto("Rojo");
                    luchador2.Atacar(luchador1);
                    ascii.EscribirCentrado($"Vida de luchador 1 {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}");
                    Console.ResetColor();

                    //Thread.Sleep(2000); // Pausa de 2 segundos

                    if (luchador1.Caracteristicas.Salud <= 0)
                    {
                        ascii.EscribirCentrado($"{luchador2.Datos.Nombre} ha ganado el combate.");
                        listaPersonajes.Add(luchador2);
                        break;
                    }
                }
                numeroCombate++;
            }
            // Detener el stopwatch al finalizar SimularTorneo
            stopwatch.Stop();
            Personaje ganador = listaPersonajes.FirstOrDefault();
            if (ganador != null)
            {
                int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
                ascii.EscribirCentrado($"{ganador.Datos.Nombre} es el campeón del torneo.");
                ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                DetallesPartida detallesPartida = new DetallesPartida(duracion, ganador.ContadorAtaques, DateTime.Now);
                archivosPjsGanadores.GuardarGanador(ganador, detallesPartida, rutaGanadores);
            }
        }
    }
}