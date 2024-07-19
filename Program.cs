using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioInicio;

//Instanciando clases
var start = new Iniciar();
PersonajesJson archivos = new PersonajesJson();
Torneo torneo = new Torneo();
// Rutas de los archivos JSON
string rutaListaPjs = "JsonFolder/Personajes.json";
string rutaJugador = "JsonFolder/rutaJugador.json";
string rutaGanadores = "JsonFolder/rutaGanadores.json";

//Inicializar juego
start.InicializarJuego(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);