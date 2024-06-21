using espacioFabricaPersonajes;

FabricaDePersonajes personajes = new FabricaDePersonajes();
await personajes.CrearPersonajes();//Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
foreach (var item in personajes.ListaPersonajes)
{
    Console.WriteLine(item.DatosPersonaje.Nombre);
}