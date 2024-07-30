using EspacioPersonajes.PersonajesFiles;
using EspacioMostrarDatos.Helpers;
using EspacioJsonCreacion;
using System.Diagnostics;
using EspacioArteAscii.GUI;
using EspacioMenu;
using EspacioSimularTorneo;


namespace EspacioTorneo
{
    public class Torneo
    {
        ClaseSimularTorneo torneo = new ClaseSimularTorneo();
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
                ascii.CambiarColorTexto("Verde");
                string[] asciiVictoria = ascii.AsciiVictoria;
                string[] asciiTrono = ascii.AsciiTrono;
                ascii.CentrarAscii(asciiVictoria);
                ascii.EscribirCentrado("Felicidades! Has ganado el torneo!");
                PressToContinue();
                ascii.EscribirCentrado("Eres el ganador indiscutido del trono de hierro, listo para gobernar como un tirano");
                ascii.CentrarAscii(asciiTrono);
                PressToContinue();
                int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
                DetallesPartida detallesPartida = new DetallesPartida(duracion, jugador.ContadorAtaques, DateTime.Now);
                archivosPjsGanadores.GuardarGanador(jugador, detallesPartida, rutaGanadores);
            }
            else if (jugadorDerrotado)
            {
                // El jugador ha sido derrotado, continuar el torneo entre los personajes restantes.
                torneo.SimularTorneo(personajes, rutaGanadores, stopwatch);
            }
        }

        private void PressToContinue()
        {
            ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private bool PeleaDelJugador(List<Personaje> personajes, Personaje jugador, Stopwatch stopwatch, Random RandomGenerator, bool jugadorDerrotado)
        {
            int numBatalla = 1;
            void MostrarMensaje(string mensaje, string color = "Blanco")
            {
                ascii.CambiarColorTexto(color);
                ascii.EscribirCentrado(mensaje);
                Console.ResetColor();
            }

            while (personajes.Count >= 1 && !jugadorDerrotado)//Añadido el igual para que me tome el ultimo enemigo de la lista
            {
                Personaje luchador1 = jugador;
                int posicionEnemigo = RandomGenerator.Next(personajes.Count);
                Personaje luchador2 = personajes[posicionEnemigo];
                stopwatch.Start();

                showStats.MostrarInformacionCombate(luchador1, luchador2, numBatalla);
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
                            ascii.CambiarColorTexto("Verde");
                            ascii.CentrarAscii(ascii.AsciiAtaque);
                            MostrarMensaje($"El jugador ha atacado a {luchador2.Datos.Nombre}", "Naranja");
                            MostrarMensaje($"Vida de {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}", "Rojo");
                            MostrarMensaje("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 1:
                            Console.Clear();
                            luchador1.TomarPocion();
                            ascii.CambiarColorTexto("Verde");
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
                        personajes.Remove(luchador2);
                        string[] asciiVictoria = ascii.AsciiVictoria;
                        ascii.CambiarColorTexto("Amarillo");
                        ascii.CentrarAscii(asciiVictoria);
                        MostrarMensaje($"{luchador1.Datos.Nombre} ha ganado el combate.", "Amarillo");
                        MostrarMensaje("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        luchador1.Caracteristicas.MejorarAtributos();
                        Console.Clear();
                        break;
                    }

                    Console.Clear();
                    luchador2.Atacar(luchador1);
                    ascii.CambiarColorTexto("Rojo");
                    ascii.CentrarAscii(ascii.AsciiAtaque);
                    MostrarMensaje($"El oponente ha atacado a {luchador1.Datos.Nombre}", "Rojo");
                    MostrarMensaje($"Vida de {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}", "Rojo");
                    MostrarMensaje("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();

                    if (luchador1.Caracteristicas.Salud <= 0)
                    {
                        string[] asciiDerrota = ascii.AsciiDerrota;
                        Console.Clear();
                        ascii.CambiarColorTexto("Rojo");
                        ascii.CentrarAscii(asciiDerrota);
                        MostrarMensaje($"{luchador2.Datos.Nombre} ha ganado el combate.", "Amarillo");
                        ascii.EscribirCentrado($"{jugador.Datos.Nombre} ha sido derrotado y eliminado del torneo.");
                        ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.ResetColor();
                        if (luchador1 == jugador)
                        {
                            jugadorDerrotado = true;
                        }
                        personajes.Remove(luchador1);
                        Console.Clear();
                        break;
                    }
                }
                numBatalla++;
            }
            return jugadorDerrotado;
        }
    }
}