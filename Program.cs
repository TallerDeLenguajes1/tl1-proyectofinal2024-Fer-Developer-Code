using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes;

var archivos = new PersonajesJson();
string nombreArchivo = "Personajes.json";

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
    }
    else
    {
        FabricaDePersonajes personajes = new FabricaDePersonajes();
        await personajes.CrearPersonajes();//Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
        archivos.GuardarPersonajes(personajes.ListaPersonajes, nombreArchivo);
        MostrarPersonaje(personajes);
    }
}