using EspacioJsonCreacion;
using EspacioArteAscii.GUI;
using EspacioTorneo;
using EspacioMostrarDatos.Helpers;
using EspacioJuego;
ArteAscii ascii = new ArteAscii();

PersonajesJson archivos = new PersonajesJson();
Torneo torneo = new Torneo();
MostrarDatos mostrar = new MostrarDatos();
Juego empezar = new Juego();
// Rutas de los archivos JSON
string rutaListaPjs = "JsonFolder/Personajes.json";
string rutaJugador = "JsonFolder/rutaJugador.json";
string rutaGanadores = "JsonFolder/rutaGanadores.json";

//Title = "Jueguito"; Añade el titulo a la terminal de una clase, ejecutar despues
//Inicializar menu
ascii.MostrarLogo();
empezar.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);