using EspacioArteAscii;
using espacioFabricaPersonajes;
using EspacioApiJsonToCsharp.Helpers;
using System.Text.Json;
using EspacioFunciones.Helpers;
/*ArteAscii ImgJuego = new ArteAscii();
ImgJuego.MostrarLogo();
FabricaDePersonajes crearPersonajes = new FabricaDePersonajes();
/*foreach (var item in crearPersonajes.ListaPersonajes)
{
    Console.WriteLine(item.DatosPersonaje.Nombre);
}*/
await probando();
static async Task probando()
{
    FuncionesAsync funcionesAsync = new FuncionesAsync();
    await funcionesAsync.Prueba();
}