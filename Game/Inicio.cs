using EspacioArteAscii.GUI;
using EspacioJuego;
using EspacioJsonCreacion;
using EspacioTorneo;
using static System.Console;
namespace EspacioInicio
{
    public class Iniciar
    {
        public void InicializarJuego(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            Title = "La mazmorra oscura";
            ArteAscii ascii = new ArteAscii();
            ascii.MostrarLogo();
            //Title = "Jueguito"; Añade el titulo a la terminal de una clase, ejecutar despues
            Juego empezar = new Juego();
            empezar.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
        }
    }
}