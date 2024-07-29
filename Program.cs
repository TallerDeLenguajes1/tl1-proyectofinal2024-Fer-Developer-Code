using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioInicio;
using EspacioMenu;
using EspacioArteAscii.GUI;

await InicializarPrograma();

static async Task InicializarPrograma()//Nota recordar extraer bien las funciones locales para evitar dolores de cabeza con el operador await
{
    //Instanciando clases
    var startGame = new Iniciar();
    PersonajesJson archivos = new PersonajesJson();
    Torneo torneo = new Torneo();
    ArteAscii ascii = new ArteAscii();
    // Rutas de los archivos JSON
    string rutaListaPjs = "JsonFolder/Personajes.json";
    string rutaJugador = "JsonFolder/rutaJugador.json";
    string rutaGanadores = "JsonFolder/rutaGanadores.json";

    //Inicializar juego
    await startGame.InicializarJuego(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
    //Preguntar si desea seguir jugando o salir
    string[] opciones = { "Seguir Jugando", "Salir" };
    string elegir = "¿Desea seguir jugando?";
    string[] portada = ascii.asciiMago;

    MenuGrafico menuJuego = new MenuGrafico(portada, elegir, opciones);
    int opcion = menuJuego.Run();
    switch (opcion)
    {
        case 0:
            await InicializarPrograma();
            break;
        case 1:
            break;
    }
}