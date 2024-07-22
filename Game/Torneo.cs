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
        HistorialJson archivosPjsGanadores = new HistorialJson();
        ArteAscii ascii = new ArteAscii();
        string rutaGanadores = "JsonFolder/rutaGanadores.json";
        // Metodos para el torneo
        public void ComenzarTorneo(List<Personaje> personajes, Personaje jugador)
        {
            Stopwatch stopwatch = new Stopwatch(); // Iniciar contador de tiempo
            Random RandomGenerator = new Random();
            bool jugadorDerrotado = false;

            while (personajes.Count > 1 && !jugadorDerrotado)
            {
                Personaje luchador1 = jugador;
                int posicionEnemigo = RandomGenerator.Next(personajes.Count);
                Personaje luchador2 = personajes[posicionEnemigo];
                stopwatch.Start();
                Console.Clear(); // Limpiar la consola

                //Insertar aca una presentacion sobre los luchadores 
                string presentacion = $"¡Combate entre {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre}!";
                ascii.EscribirCentrado(presentacion);
                ascii.EscribirCentrado(new string('-', Console.WindowWidth));

                while (luchador1.Caracteristicas.Salud > 0 && luchador2.Caracteristicas.Salud > 0)
                {
                    showStats.MostrarCaracteristicas(luchador1, "Jugador");
                    showStats.MostrarCaracteristicas(luchador2, "Oponente");

                    string entrada = "Elige tu acción:";
                    string[] opciones = { "Atacar", "Tomar pociones" };
                    string[] asciiTrofeo = ascii.AsciiTrofeo;


                    MenuGrafico menuAcciones = new MenuGrafico(asciiTrofeo,entrada, opciones);
                    int accionJugador = menuAcciones.Run();

                    switch (accionJugador)
                    {
                        case 0:
                            luchador1.Atacar(luchador2);
                            string saludOponente = $"Vida de {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}";
                            ascii.EscribirCentrado(saludOponente);
                            ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                            Console.ReadKey(); 
                            break;
                        case 1:
                            luchador1.TomarPocion();
                            ascii.EscribirCentrado("El jugador ha tomado una pocion");
                            ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                            Console.ReadKey(); 
                            break;
                        default:
                            break;
                    }

                    if (luchador2.Caracteristicas.Salud <= 0)
                    {
                        ascii.EscribirCentrado($"{luchador1.Datos.Nombre} ha ganado el combate.");
                        ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                        Console.ReadKey(); 
                        personajes.Remove(luchador2);
                        break;
                    }

                    luchador2.Atacar(luchador1);
                    ascii.EscribirCentrado($"Vida de {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}");
                    ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                    Console.ReadKey(); 
                    if (luchador1.Caracteristicas.Salud <= 0)
                    {
                        ascii.EscribirCentrado($"{luchador2.Datos.Nombre} ha ganado el combate.");
                        Thread.Sleep(123);
                        if (luchador1 == jugador)
                        {
                            jugadorDerrotado = true;
                        }
                        personajes.Remove(luchador1);
                        break;
                    }
                }
                Console.Clear();
                ascii.EscribirCentrado("Presiona cualquier tecla para continuar...");
                Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de continuar
            }
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