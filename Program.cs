using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes;
using EspConstantes;

var archivos = new PersonajesJson();
string nombreArchivo = "Json/Personajes.json";

await verificarArchivos(archivos, nombreArchivo);

void MostrarPersonaje(FabricaDePersonajes personajes)
{
    foreach (var personaje in personajes.ListaPersonajes)
    {
        Console.WriteLine($"Nombre: {personaje.DatosPersonaje.Nombre}, Apodo: {personaje}");
        Console.WriteLine($"Raza: {personaje}, Edad: {personaje}");
        Console.WriteLine($"Velocidad: {personaje}, Destreza: {personaje}");
        Console.WriteLine($"Fuerza: {personaje}, Nivel: {personaje}");
        Console.WriteLine($"Armadura: {personaje}, Salud: {personaje}");
        Console.WriteLine();
    }
}

async Task verificarArchivos(PersonajesJson archivos, string nombreArchivo)
{
    if (archivos.Existe(nombreArchivo))
    {
        List<Personaje> listaPersonajesGuardados = archivos.LeerPersonajes(nombreArchivo);
        for (int i = 0; i < Constantes.MaxEnemigos; i++)
        {
            Console.WriteLine($"Tu oponente es {listaPersonajesGuardados[i].DatosPersonaje.Nombre}");
            Console.WriteLine($"Raza: {listaPersonajesGuardados[i].DatosPersonaje.Raza}, Edad: {listaPersonajesGuardados[i].DatosPersonaje.Edad}");
            Console.WriteLine($"Velocidad: {listaPersonajesGuardados[i].CaracteristicasPersonaje.Velocidad}, Destreza: {listaPersonajesGuardados[i].CaracteristicasPersonaje.Destreza}");
            Console.WriteLine($"HP: {listaPersonajesGuardados[i].CaracteristicasPersonaje.Salud}");
        }
    }
    else
    {
        FabricaDePersonajes personajes = new FabricaDePersonajes();
        await personajes.CrearPersonajes();//Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
        archivos.GuardarPersonajes(personajes.ListaPersonajes, nombreArchivo);
        MostrarPersonaje(personajes);
    }
}