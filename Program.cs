using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes;
using EspConstantes;

var archivos = new PersonajesJson();
string nombreArchivo = "Json/Personajes.json";


void MostrarPersonaje(Personaje personaje)
{
    Console.WriteLine($"Nombre: {personaje.DatosPersonaje.Nombre}, Apodo: {personaje.DatosPersonaje.Apodo}");
    Console.WriteLine($"Raza: {personaje.DatosPersonaje.Raza}, Edad: {personaje.DatosPersonaje.Edad}");
    Console.WriteLine($"Velocidad: {personaje.CaracteristicasPersonaje.Velocidad}, Destreza: {personaje.CaracteristicasPersonaje.Destreza}");
    Console.WriteLine($"Fuerza: {personaje.CaracteristicasPersonaje.Fuerza}, Nivel: {personaje.CaracteristicasPersonaje.Nivel}");
    Console.WriteLine($"Armadura: {personaje.CaracteristicasPersonaje.Armadura}, Salud: {personaje.CaracteristicasPersonaje.Salud}");
    Console.WriteLine();
}


if (archivos.Existe(nombreArchivo))
{
    List<Personaje> listaPersonajesGuardados = archivos.LeerPersonajes(nombreArchivo);
    var fabrica = new FabricaDePersonajes();
    fabrica.CrearPersonajeUsuario();
    for (int i = 0; i < Constantes.MaxEnemigos; i++)
    {
        MostrarPersonaje(listaPersonajesGuardados[i]);
    }
    MostrarPersonaje(fabrica.Pj);
}
else
{
    FabricaDePersonajes personajes = new FabricaDePersonajes();
    await personajes.CrearPersonajes();//Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
    archivos.GuardarPersonajes(personajes.ListaPersonajes, nombreArchivo);
}
