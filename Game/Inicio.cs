using EspacioJuego;
using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioArteAscii.GUI;
using static System.Console;
namespace EspacioInicio
{
    public class Iniciar
    {
        public void InicializarJuego(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            Title = "CodeRealm: El Reino de las Clases";
            //Title = "Jueguito"; Añade el titulo a la terminal de una clase, ejecutar despues
            ArteAscii ascii = new ArteAscii();
            ascii.MostrarLogo();
            Juego empezar = new Juego();
            empezar.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
        }
    }
}