using EspacioJuego;
using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioArteAscii.GUI;
using static System.Console;
using EspacioMenu;

namespace EspacioInicio
{
    public class Iniciar
    {
        public async Task InicializarJuego(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            Console.Clear();
            Title = "CodeRealm: El Reino de las Clases";
            //Title = "Jueguito"; Añade el titulo a la terminal de una clase, ejecutar despues
            ArteAscii ascii = new ArteAscii();
            ascii.MostrarLogo();
            Juego menuPrincipal = new Juego();
            await menuPrincipal.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);

            //Preguntar si desea seguir jugando o salir
            string[] opciones = { "Seguir Jugando", "Salir" };
            string elegir = "¿Desea seguir jugando?";
            string[] portada = ascii.asciiMago;

            MenuGrafico menuJuego = new MenuGrafico(portada, elegir, opciones);
            int opcion = menuJuego.Run();
            switch (opcion)
            {
                case 0:
                    await menuPrincipal.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
                    break;
                case 1:
                    break;
            }
        }
    }
}