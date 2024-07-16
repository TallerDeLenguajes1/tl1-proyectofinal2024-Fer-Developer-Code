using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes.PersonajesFiles;
using EspacioArteAscii.Helpers;
using System.Diagnostics;

ArteAscii ascii = new ArteAscii();
PersonajesJson archivos = new PersonajesJson();
HistorialJson archivosPjsGanadores = new HistorialJson();

// Rutas de los archivos JSON
string rutaListaPjs = "JsonFolder/Personajes.json";
string rutaJugador = "JsonFolder/rutaJugador.json";
string rutaGanadores = "JsonFolder/rutaGanadores.json";

// Comprobamos si los archivos existen y leemos los datos
if (archivos.Existe(rutaListaPjs) && archivos.Existe(rutaJugador))
{
    List<Personaje> listaPersonajesGuardados = archivos.LeerPersonajes(rutaListaPjs);
    Personaje jugador = archivos.LeerJugador(rutaJugador);
    int respuesta;
    do
    {
        Console.Write("¿Deseas seguir con tu personaje actual o crear uno nuevo? (1: Sí, 2: No): ");
    } while (!int.TryParse(Console.ReadLine(), out respuesta) || (respuesta != 1 && respuesta != 2));

    if (respuesta == 1)
    {
        // El jugador desea seguir con su personaje actual
        Console.WriteLine("¡Excelente! Continuemos con tu personaje actual.");
    }
    else
    {
        Console.WriteLine("¡Entendido! Vamos a crear un nuevo personaje.");
        try
        {
            File.Delete(rutaJugador);
            Console.WriteLine($"El archivo {rutaJugador} ha sido borrado correctamente.");
            FabricaDePersonajes personajes = new FabricaDePersonajes();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            fabrica.CrearPersonajeUsuario();
            archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al borrar el archivo: {ex.Message}");
        }
    }
    ComenzarTorneo(archivos.LeerPersonajes(rutaListaPjs), archivos.LeerJugador(rutaJugador));
}
else
{
    FabricaDePersonajes personajes = new FabricaDePersonajes();
    FabricaDePersonajes fabrica = new FabricaDePersonajes();
    fabrica.CrearPersonajeUsuario();
    await personajes.CrearPersonajes(); //Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
    archivos.GuardarPersonajes(personajes.ListaPersonajes, rutaListaPjs);
    archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
    ComenzarTorneo(personajes.ListaPersonajes, fabrica.Pj);
}

// Metodos para el torneo
void ComenzarTorneo(List<Personaje> personajes, Personaje jugador)
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
        Console.WriteLine($"¡Combate entre {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre}!");

        MostrarCaracteristicas(luchador1);
        MostrarCaracteristicas(luchador2);

        while (luchador1.Caracteristicas.Salud > 0 && luchador2.Caracteristicas.Salud > 0)
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
                    Console.WriteLine($"Vida de {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}");
                    break;
                case 2:
                    luchador1.TomarPocion();
                    break;
                default:
                    break;
            }

            if (luchador2.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{luchador1.Datos.Nombre} ha ganado el combate.");
                personajes.Remove(luchador2);
                break;
            }

            luchador2.Atacar(luchador1);
            Console.WriteLine($"Vida de {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}");
            if (luchador1.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{luchador2.Datos.Nombre} ha ganado el combate.");
                if (luchador1 == jugador)
                {
                    jugadorDerrotado = true;
                }
                personajes.Remove(luchador1);
                break;
            }
        }
        Console.Clear();
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de continuar
    }
    stopwatch.Stop();
    if (!jugadorDerrotado)
    {
        // El jugador es el último en pie, por lo tanto, gana el torneo.
        Console.WriteLine("��Felicidades! Has ganado el torneo!");
        int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
        DetallesPartida detallesPartida = new DetallesPartida(duracion);
        archivosPjsGanadores.GuardarGanador(jugador, detallesPartida, rutaGanadores);
    }
    else if (jugadorDerrotado)
    {
        // El jugador ha sido derrotado, continuar el torneo entre los personajes restantes.
        Console.WriteLine($"{jugador.Datos.Nombre} ha sido derrotado y eliminado del torneo.");
        SimularTorneo(personajes, rutaGanadores, stopwatch);
    }
}
// En caso de que el jugador sea derrotado simula un torneo entre los personajes restantes
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
        int posicion1 = RandomGenerator.Next(personajes.Count);
        Personaje luchador1 = personajes[posicion1];
        personajes.RemoveAt(posicion1);

        int posicion2 = RandomGenerator.Next(personajes.Count);
        Personaje luchador2 = personajes[posicion2];
        personajes.RemoveAt(posicion2);

        Console.Clear();
        Console.WriteLine($"Combate entre {luchador1.Datos.Nombre} y {luchador2.Datos.Nombre}");
        MostrarCaracteristicas(luchador1);
        MostrarCaracteristicas(luchador2);

        while (luchador1.Caracteristicas.Salud > 0 && luchador2.Caracteristicas.Salud > 0)
        {
            luchador1.Atacar(luchador2);
            Console.WriteLine($"Vida de {luchador2.Datos.Nombre}: {luchador2.Caracteristicas.Salud}");

            Thread.Sleep(2000); // Pausa de 2 segundos

            if (luchador2.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{luchador1.Datos.Nombre} ha ganado el combate.");
                personajes.Add(luchador1);
                break;
            }

            luchador2.Atacar(luchador1);
            Console.WriteLine($"Vida de {luchador1.Datos.Nombre}: {luchador1.Caracteristicas.Salud}");

            Thread.Sleep(2000); // Pausa de 2 segundos

            if (luchador1.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{luchador2.Datos.Nombre} ha ganado el combate.");
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
        Console.WriteLine($"{ganador.Datos.Nombre} es el campeón del torneo.");
        int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
        DetallesPartida detallesPartida = new DetallesPartida(duracion);
        archivosPjsGanadores.GuardarGanador(ganador, detallesPartida, rutaGanadores);
    }
}
void MostrarCaracteristicas(Personaje personaje)
{
    Console.WriteLine($"Nombre: {personaje.Datos.Nombre}, Apodo: {personaje.Datos.Apodo}");
    Console.WriteLine($"Raza: {personaje.Datos.Raza}, Edad: {personaje.Datos.Edad}");
    Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}, Destreza: {personaje.Caracteristicas.Destreza}");
    Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}, Nivel: {personaje.Caracteristicas.Nivel}");
    Console.WriteLine($"Armadura: {personaje.Caracteristicas.Armadura}, Salud: {personaje.Caracteristicas.Salud}");
    Console.WriteLine();
}