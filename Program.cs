using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioInicio;


await InicializarPrograma();

static async Task InicializarPrograma()//Nota recordar extraer bien las funciones locales para evitar dolores de cabeza con el operador await
{
    //Instanciando clases
    var startGame = new Iniciar();
    PersonajesJson archivos = new PersonajesJson();
    Torneo torneo = new Torneo();
    // Rutas de los archivos JSON
    string rutaListaPjs = "JsonFolder/Personajes.json";
    string rutaJugador = "JsonFolder/rutaJugador.json";
    string rutaGanadores = "JsonFolder/rutaGanadores.json";

    //Inicializar juego
    await startGame.InicializarJuego(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
}
