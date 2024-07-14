using EspacioPersonajes;
using System.Text.Json;

namespace EspacioJsonCreacion
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> personajes, string ruta)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var personajesJson = JsonSerializer.Serialize(personajes, opciones);
            File.WriteAllText(ruta, personajesJson);
        }

        public List<Personaje> LeerPersonajes(string ruta)
        {
            var personajesJson = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Personaje>>(personajesJson);
        }

        public void GuardarPersonajeJugador(Personaje personaje, string ruta)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var personajeJson = JsonSerializer.Serialize(personaje, opciones);
            File.WriteAllText(ruta, personajeJson);
        }

        public Personaje LeerJugador(string ruta)
        {
            var personajeJson = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<Personaje>(personajeJson);
        }

        public bool Existe(string ruta)
        {
            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }
    }

    public class HistorialJson
    {
        public void GuardarGanador(Personaje ganador, DetallesPartida detalles, string ruta)
        {
            List<HistorialPartida> ganadoresExistentes = Existe(ruta) ? LeerGanadores(ruta) : new List<HistorialPartida>();
            ganadoresExistentes.Add(new HistorialPartida { Ganador = ganador, Detalles = detalles });
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var ganadoresJson = JsonSerializer.Serialize(ganadoresExistentes, opciones);
            File.WriteAllText(ruta, ganadoresJson);
        }

        public List<HistorialPartida> LeerGanadores(string ruta)
        {
            var ganadoresJson = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<HistorialPartida>>(ganadoresJson);
        }

        public bool Existe(string ruta)
        {
            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }
    }

    public class DetallesPartida
    {
        public int ContadorAtaques { get; set; }
        public int Duracion { get; set; }

        public DetallesPartida(int contadorAtaques, int duracion)
        {
            ContadorAtaques = contadorAtaques;
            Duracion = duracion;
        }
    }

    public class HistorialPartida
    {
        public Personaje Ganador { get; set; }
        public DetallesPartida Detalles { get; set; }
    }
}
void ComenzarTorneo(List<Personaje> personajes, Personaje jugador)
{
    Stopwatch stopwatch = new Stopwatch(); // Iniciar contador de tiempo global del torneo
    Random RandomGenerator = new Random();
    bool jugadorDerrotado = false;
    long tiempoInicialJugador = 0; // Para registrar el tiempo inicial del jugador

    while (personajes.Count > 1 && !jugadorDerrotado)
    {
        var luchador1 = jugador;
        var posicionEnemigo = RandomGenerator.Next(personajes.Count);
        var luchador2 = personajes[posicionEnemigo];
        stopwatch.Start(); // Iniciar el stopwatch al comienzo del combate
        tiempoInicialJugador = stopwatch.ElapsedMilliseconds; // Registrar el tiempo inicial del jugador

        Console.Clear(); // Limpiar la consola
        Console.WriteLine($"¡Combate entre {luchador1.DatosPersonaje.Nombre} y {luchador2.DatosPersonaje.Nombre}!");

        MostrarCaracteristicas(luchador1);
        MostrarCaracteristicas(luchador2);

        while (luchador1.CaracteristicasPersonaje.Salud > 0 && luchador2.CaracteristicasPersonaje.Salud > 0)
        {
            int respuesta;
            do
            {
                Console.WriteLine("Elige tu acción:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Tomar poción de vida");
                Console.Write("Opción: ");
            } while (!int.TryParse(Console.ReadLine(), out respuesta) || (respuesta != 1 && respuesta != 2));

            switch (respuesta)
            {
                case 1:
                    luchador1.Atacar(luchador2);
                    Console.WriteLine($"Vida de {luchador2.DatosPersonaje.Nombre}: {luchador2.CaracteristicasPersonaje.Salud}");
                    break;
                case 2:
                    luchador1.TomarPocion();
                    break;
                default:
                    break;
            }

            if (luchador2.CaracteristicasPersonaje.Salud <= 0)
            {
                Console.WriteLine($"{luchador1.DatosPersonaje.Nombre} ha ganado el combate.");
                personajes.Remove(luchador2);
                break;
            }

            luchador2.Atacar(luchador1);
            Console.WriteLine($"Vida de {luchador1.DatosPersonaje.Nombre}: {luchador1.CaracteristicasPersonaje.Salud}");

            if (luchador1.CaracteristicasPersonaje.Salud <= 0)
            {
                Console.WriteLine($"{luchador2.DatosPersonaje.Nombre} ha ganado el combate.");
                jugadorDerrotado = true;
                personajes.Remove(luchador1);
                break;
            }
        }

        // Detener el stopwatch al final del combate
        stopwatch.Stop();
    }

    if (personajes.Count == 0 && !jugadorDerrotado)
    {
        // El jugador es el último en pie, por lo tanto, gana el torneo.
        int duracion = (int)(stopwatch.ElapsedMilliseconds - tiempoInicialJugador) / 1000; // Duración en segundos sumando el tiempo del jugador 1
        var detallesPartida = new DetallesPartida(jugador.ContadorAtaques, duracion);
        archivosPjsGanadores.GuardarGanador(jugador, detallesPartida, rutaGanadores);
    }
    else if (jugadorDerrotado)
    {
        // El jugador ha sido derrotado, continuar el torneo entre los personajes restantes.
        Console.WriteLine($"{jugador.DatosPersonaje.Nombre} ha sido derrotado y eliminado del torneo.");
        SimularTorneo(personajes, rutaGanadores, stopwatch);
    }
}

void SimularTorneo(List<Personaje> personajes, string rutaGanadores, Stopwatch stopwatch)
{
    // Continuar el stopwatch si no se había detenido en ComenzarTorneo
    if (!stopwatch.IsRunning)
    {
        stopwatch.Start();
    }

    Random RandomGenerator = new Random();
    while (personajes.Count > 1)
    {
        var posicion1 = RandomGenerator.Next(personajes.Count);
        var luchador1 = personajes[posicion1];
        personajes.RemoveAt(posicion1);

        var posicion2 = RandomGenerator.Next(personajes.Count);
        var luchador2 = personajes[posicion2];
        personajes.RemoveAt(posicion2);

        Console.Clear();
        Console.WriteLine($"Combate entre {luchador1.DatosPersonaje.Nombre} y {luchador2.DatosPersonaje.Nombre}");
        MostrarCaracteristicas(luchador1);
        MostrarCaracteristicas(luchador2);

        while (luchador1.CaracteristicasPersonaje.Salud > 0 && luchador2.CaracteristicasPersonaje.Salud > 0)
        {
            luchador1.Atacar(luchador2);
            Console.WriteLine($"Vida de {luchador2.DatosPersonaje.Nombre}: {luchador2.CaracteristicasPersonaje.Salud}");

            Thread.Sleep(2000); // Pausa de 2 segundos

            if (luchador2.CaracteristicasPersonaje.Salud <= 0)
            {
                Console.WriteLine($"{luchador1.DatosPersonaje.Nombre} ha ganado el combate.");
                personajes.Add(luchador1);
                break;
            }

            luchador2.Atacar(luchador1);
            Console.WriteLine($"Vida de {luchador1.DatosPersonaje.Nombre}: {luchador1.CaracteristicasPersonaje.Salud}");

            Thread.Sleep(2000); // Pausa de 2 segundos

            if (luchador1.CaracteristicasPersonaje.Salud <= 0)
            {
                Console.WriteLine($"{luchador2.DatosPersonaje.Nombre} ha ganado el combate.");
                personajes.Add(luchador2);
                break;
            }
        }
    }

    // Detener el stopwatch al finalizar SimularTorneo
    stopwatch.Stop();

    var ganador = personajes.FirstOrDefault();
    if (ganador != null)
    {
        Console.WriteLine($"{ganador.DatosPersonaje.Nombre} es el campeón del torneo.");
        int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración total del torneo
        archivosPjsGanadores.GuardarGanador(ganador, duracion, rutaGanadores);
    }
}
