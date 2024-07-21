using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioInicio;


await Inicializar();

static async Task Inicializar()//Nota recordar extraer bien las funciones locales para evitar dolores de cabeza con el operador await
{
    //Instanciando clases
    var start = new Iniciar();
    PersonajesJson archivos = new PersonajesJson();
    Torneo torneo = new Torneo();
    // Rutas de los archivos JSON
    string rutaListaPjs = "JsonFolder/Personajes.json";
    string rutaJugador = "JsonFolder/rutaJugador.json";
    string rutaGanadores = "JsonFolder/rutaGanadores.json";

    //Inicializar juego
    await start.InicializarJuego(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
}
