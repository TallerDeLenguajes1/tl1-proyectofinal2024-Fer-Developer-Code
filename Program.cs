﻿using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes.PersonajesFiles;
using EspacioArteAscii.GUI;
using EspacioTorneo;
using EspacioMostrarDatos.Helpers;
using EspacioMenu;

string rutaGanadores = "JsonFolder/rutaGanadores";
ArteAscii ascii = new ArteAscii();
PersonajesJson archivos = new PersonajesJson();
Torneo torneo = new Torneo();
MostrarDatos mostrar = new MostrarDatos();

// Rutas de los archivos JSON
string rutaListaPjs = "JsonFolder/Personajes.json";
string rutaJugador = "JsonFolder/rutaJugador.json";

//Inicializar menu

ascii.MostrarLogo();
string saludo = "";
string[] opciones = {"Jugar", "Creditos", "Salir"};
MenuGrafico menuJuego = new MenuGrafico(saludo, opciones);
int indiceMenu = menuJuego.Run();

// Comprobamos si los archivos existen y leemos los datos
if (archivos.Existe(rutaListaPjs) && archivos.Existe(rutaJugador))
{
    List<Personaje> listaPersonajesGuardados = archivos.LeerPersonajes(rutaListaPjs);
    Personaje jugador = archivos.LeerJugador(rutaJugador);
    int respuesta = PreguntarCambiarPersonaje();

    if (respuesta == 0)
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
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            fabrica.CrearPersonajeUsuario();
            archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al borrar el archivo: {ex.Message}");
        }
    }
    torneo.ComenzarTorneo(listaPersonajesGuardados, jugador);
}
else
{
    FabricaDePersonajes fabrica = new FabricaDePersonajes();
    fabrica.CrearPersonajeUsuario();
    await fabrica.CrearPersonajes(); //Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
    archivos.GuardarPersonajes(fabrica.ListaPersonajes, rutaListaPjs);
    archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
    torneo.ComenzarTorneo(fabrica.ListaPersonajes, fabrica.Pj);
}
mostrar.EscribirHistorialGanadores(rutaGanadores);

int PreguntarCambiarPersonaje()
{
    string pregunta = "¿Deseas seguir con tu personaje actual o crear uno nuevo? (1: Sí, 2: No): ";
    string[] opciones = { "Si", "No" };
    MenuGrafico menuCambiarPersonaje = new MenuGrafico(pregunta, opciones);
    return menuCambiarPersonaje.Run();
}