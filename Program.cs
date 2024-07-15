using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes;
using EspacioArteAscii;
using System.Diagnostics;

var ascii = new ArteAscii();
var archivos = new PersonajesJson();
var archivosPjsGanadores = new HistorialJson();

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
            var fabrica = new FabricaDePersonajes();
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
    var fabrica = new FabricaDePersonajes();
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
        var luchador1 = jugador;
        var posicionEnemigo = RandomGenerator.Next(personajes.Count);
        var luchador2 = personajes[posicionEnemigo];
        stopwatch.Start();
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
        var detallesPartida = new DetallesPartida(duracion);
        archivosPjsGanadores.GuardarGanador(jugador, detallesPartida, rutaGanadores);
    }
    else if (jugadorDerrotado)
    {
        // El jugador ha sido derrotado, continuar el torneo entre los personajes restantes.
        Console.WriteLine($"{jugador.DatosPersonaje.Nombre} ha sido derrotado y eliminado del torneo.");
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
        int duracion = (int)stopwatch.Elapsed.TotalSeconds; // Duración en segundos
        var detallesPartida = new DetallesPartida(duracion);
        archivosPjsGanadores.GuardarGanador(ganador, detallesPartida, rutaGanadores);
    }
}
void MostrarCaracteristicas(Personaje personaje)
{
    Console.WriteLine($"Nombre: {personaje.DatosPersonaje.Nombre}, Apodo: {personaje.DatosPersonaje.Apodo}");
    Console.WriteLine($"Raza: {personaje.DatosPersonaje.Raza}, Edad: {personaje.DatosPersonaje.Edad}");
    Console.WriteLine($"Velocidad: {personaje.CaracteristicasPersonaje.Velocidad}, Destreza: {personaje.CaracteristicasPersonaje.Destreza}");
    Console.WriteLine($"Fuerza: {personaje.CaracteristicasPersonaje.Fuerza}, Nivel: {personaje.CaracteristicasPersonaje.Nivel}");
    Console.WriteLine($"Armadura: {personaje.CaracteristicasPersonaje.Armadura}, Salud: {personaje.CaracteristicasPersonaje.Salud}");
    Console.WriteLine();
}