using EspacioPersonajes.PersonajesFiles;
using EspacioMostrarDatos.Helpers;
using EspacioJsonCreacion;
using System.Diagnostics;
using EspacioArteAscii.GUI;
using EspacioMenu;

namespace EspacioTorneo
{
    public class Torneo
    {
        MostrarDatos showStats = new MostrarDatos();
        HistorialGanadoresJson archivosPjsGanadores = new HistorialGanadoresJson();
        ArteAscii ascii = new ArteAscii();
        string rutaGanadores = "JsonFolder/rutaGanadores.json";
        // Metodos para el torneo
        public void ComenzarTorneo(List<Personaje> personajes, Personaje jugador)
        {
            Stopwatch stopwatch = new Stopwatch(); // Iniciar contador de tiempo
            Random RandomGenerator = new Random();
            bool jugadorDerrotado = false;
            jugadorDerrotado = PeleaDelJugador(personajes, jugador, stopwatch, RandomGenerator, jugadorDerrotado);
            stopwatch.Stop();
            if (!jugadorDerrotado)
            {
                // El jugador es el último en pie, por lo tanto, gana el torneo.
                ascii.EscribirCentrado("Felicidades! Has ganado el torneo!");
                ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
                DetallesPartida detallesPartida = new DetallesPartida(duracion, jugador.ContadorAtaques);
                archivosPjsGanadores.GuardarGanador(jugador, detallesPartida, rutaGanadores);
            }
            else if (jugadorDerrotado)
            {
                // El jugador ha sido derrotado, continuar el torneo entre los personajes restantes.
                ascii.EscribirCentrado($"{jugador.Datos.Nombre} ha sido derrotado y eliminado del torneo.");
                ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                SimularTorneo(personajes, rutaGanadores, stopwatch);
            }
        }

        private bool PeleaDelJugador(List<Personaje> personajes, Personaje jugador, Stopwatch stopwatch, Random RandomGenerator, bool jugadorDerrotado)
        {


            void MostrarMensaje(string mensaje, string color = "Blanco")
            {
                ascii.CambiarColorTexto(color);
                ascii.EscribirCentrado(mensaje);
                Console.ResetColor();
            }

            while (personajes.Count > 1 && !jugadorDerrotado)
            {
                Personaje luchador1 = jugador;
                int posicionEnemigo = RandomGenerator.Next(personajes.Count);
                Personaje luchador2 = personajes[posicionEnemigo];
                stopwatch.Start();

                showStats.MostrarInformacionCombate(luchador1, luchador2);
                MostrarMensaje("Presiona cualquier tecla para continuar...");
                Console.ReadKey();

                while (luchador1.Caracteristicas.Salud > 0 && luchador2.Caracteristicas.Salud > 0)
                {
                    string entrada = "Elige tu acción:";
                    string[] opciones = { "Atacar", "Tomar pociones" };
                    string[] asciiTrofeo = ascii.AsciiTrofeo;
                    MenuGrafico menuAcciones = new MenuGrafico(asciiTrofeo, entrada, opciones);

                    // Mostrar opciones en una sección específica
                    Console.SetCursorPosition(0, Console.WindowHeight - opciones.Length - 5); // Ajustar la posición según sea necesario
                    int accionJugador = menuAcciones.Run();

                    switch (accionJugador)
                    {
                        case 0:
                            Console.Clear();
                            luchador1.Atacar(luchador2);
                            MostrarMensaje($"El jugador ha atacado a {luchador2.Datos.Nombre}", "Naranja");
                            ascii.CentrarAscii(ascii.AsciiAtaque);
                            MostrarMensaje($"Vida de {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}", "Rojo");
                            MostrarMensaje("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 1:
                            Console.Clear();
                            luchador1.TomarPocion();
                            ascii.CentrarAscii(ascii.AsciiPocion);
                            MostrarMensaje($"El jugador ha tomado una poción", "Verde");
                            MostrarMensaje($"Salud restante:{luchador1.Caracteristicas.Salud}, Pociones restantes:{luchador1.Pociones}", "verde");
                            MostrarMensaje("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            break;
                    }

                    if (luchador2.Caracteristicas.Salud <= 0)
                    {
                        ascii.CentrarAscii(ascii.AsciiVictoria);
                        MostrarMensaje($"{luchador1.Datos.Nombre} ha ganado el combate.", "Amarillo");
                        luchador1.Caracteristicas.MejorarAtributos();
                        personajes.Remove(luchador2);
                        MostrarMensaje("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    Console.Clear();
                    luchador2.Atacar(luchador1);
                    MostrarMensaje($"El oponente ha atacado a {luchador1.Datos.Nombre}", "Rojo");
                    ascii.CentrarAscii(ascii.AsciiAtaque);
                    MostrarMensaje($"Vida de {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}", "Rojo");
                    MostrarMensaje("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();

                    if (luchador1.Caracteristicas.Salud <= 0)
                    {
                        Console.Clear();
                        ascii.CentrarAscii(ascii.AsciiDerrota);
                        MostrarMensaje($"{luchador2.Datos.Nombre} ha ganado el combate.", "Amarillo");
                        MostrarMensaje("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        if (luchador1 == jugador)
                        {
                            jugadorDerrotado = true;
                        }
                        personajes.Remove(luchador1);
                        Console.Clear();

                        break;
                    }
                }
            }

            return jugadorDerrotado;
        }



        // En caso de que el jugador sea derrotado simula un torneo entre los personajes restantes
        public void SimularTorneo(List<Personaje> personajes, string rutaGanadores, Stopwatch stopwatch)
        {
            // Continuar el stopwatch si no se había detenido en ComenzarTorneo
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            Random RandomGenerator = new Random();
            while (personajes.Count > 1)
            {
                int posicion1 = RandomGenerator.Next(personajes.Count);
                Personaje luchador1 = personajes[posicion1];
                personajes.RemoveAt(posicion1);

                int posicion2 = RandomGenerator.Next(personajes.Count);
                Personaje luchador2 = personajes[posicion2];
                personajes.RemoveAt(posicion2);

                Console.Clear();
                ascii.EscribirCentrado($"Combate entre {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre}");
                showStats.MostrarCaracteristicas(luchador1, "Luchador 1");
                showStats.MostrarCaracteristicas(luchador2, "Luchador 2");

                while (luchador1.Caracteristicas.Salud > 0 && luchador2.Caracteristicas.Salud > 0)
                {
                    luchador1.Atacar(luchador2);
                    ascii.EscribirCentrado($"Vida de {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}");

                    Thread.Sleep(2000); // Pausa de 2 segundos

                    if (luchador2.Caracteristicas.Salud <= 0)
                    {
                        ascii.EscribirCentrado($"{luchador1.Datos.Nombre} ha ganado el combate.");
                        personajes.Add(luchador1);
                        break;
                    }

                    luchador2.Atacar(luchador1);
                    ascii.EscribirCentrado($"Vida de {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}");

                    Thread.Sleep(2000); // Pausa de 2 segundos

                    if (luchador1.Caracteristicas.Salud <= 0)
                    {
                        ascii.EscribirCentrado($"{luchador2.Datos.Nombre} ha ganado el combate.");
                        personajes.Add(luchador2);
                        break;
                    }
                }
            }
            // Detener el stopwatch al finalizar SimularTorneo
            stopwatch.Stop();
            Personaje ganador = personajes.FirstOrDefault();
            if (ganador != null)
            {
                ascii.EscribirCentrado($"{ganador.Datos.Nombre} es el campeón del torneo.");

                int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
                DetallesPartida detallesPartida = new DetallesPartida(duracion, ganador.ContadorAtaques);
                archivosPjsGanadores.GuardarGanador(ganador, detallesPartida, rutaGanadores);
            }
        }
    }
}