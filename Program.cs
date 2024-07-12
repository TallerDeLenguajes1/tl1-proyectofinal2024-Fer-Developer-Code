using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes;
using EspConstantes;

var archivos = new PersonajesJson();
string rutaListaPjs = "Json/Personajes.json";
string rutaJugador = "Json/rutaJugador.json";

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
}
else
{
    FabricaDePersonajes personajes = new FabricaDePersonajes();
    var fabrica = new FabricaDePersonajes();
    fabrica.CrearPersonajeUsuario();
    await personajes.CrearPersonajes();//Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
    archivos.GuardarPersonajes(personajes.ListaPersonajes, rutaListaPjs);
    archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);

}
/* Prueba para checar que cargue los datos de la API y de los personajes
void MostrarPersonaje(Personaje personaje)
{
    Console.WriteLine($"Nombre: {personaje.DatosPersonaje.Nombre}, Apodo: {personaje.DatosPersonaje.Apodo}");
    Console.WriteLine($"Raza: {personaje.DatosPersonaje.Raza}, Edad: {personaje.DatosPersonaje.Edad}");
    Console.WriteLine($"Velocidad: {personaje.CaracteristicasPersonaje.Velocidad}, Destreza: {personaje.CaracteristicasPersonaje.Destreza}");
    Console.WriteLine($"Fuerza: {personaje.CaracteristicasPersonaje.Fuerza}, Nivel: {personaje.CaracteristicasPersonaje.Nivel}");
    Console.WriteLine($"Armadura: {personaje.CaracteristicasPersonaje.Armadura}, Salud: {personaje.CaracteristicasPersonaje.Salud}");
    Console.WriteLine();
}*/
void ComenzarTorneo(List<Personaje> personajes, Personaje jugador)
{
    Random RandomGenerator = new Random();
    while (personajes.Count > 1)
    {
        var luchador1 = jugador;
        var posicionEnemigo = RandomGenerator.Next(personajes.Count);
        var luchador2 = personajes[posicionEnemigo];

        Console.WriteLine($"Combate entre {luchador1.DatosPersonaje.Nombre} y {luchador2.DatosPersonaje.Nombre}");

        while (luchador1.CaracteristicasPersonaje.Salud > 0 && luchador2.CaracteristicasPersonaje.Salud > 0)
        {
            luchador1.Atacar(luchador2);
            if (luchador2.CaracteristicasPersonaje.Salud <= 0)
            {
                Console.WriteLine($"{luchador1.DatosPersonaje.Nombre} ha ganado el combate.");
                personajes.Remove(luchador2);
                break;
            }
            luchador2.Atacar(luchador1);
            if (luchador1.CaracteristicasPersonaje.Salud <= 0)
            {
                Console.WriteLine($"{luchador2.DatosPersonaje.Nombre} ha ganado el combate.");
                personajes.Remove(luchador1);
                break;
            }
        }
    }
    var ganador = jugador;
    Console.WriteLine($"{ganador.DatosPersonaje.Nombre} es el campeón del torneo.");
}