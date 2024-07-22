using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes.PersonajesFiles;
using EspacioArteAscii.GUI;
using EspacioTorneo;
using EspacioMostrarDatos.Helpers;
using EspacioMenu;
using EspacioOpciones;

namespace EspacioJuego
{
    public class Juego
    {
        Creditos creditos = new Creditos();
        ArteAscii ascii = new ArteAscii();
        private MostrarDatos mostrar = new MostrarDatos();
        private int PreguntarCambiarPersonaje()
        {
            string pregunta = "¿Deseas seguir con tu personaje actual o crear uno nuevo?";
            string[] opciones = { "Si", "No" };
            string[] guerreros = ascii.AsciiGuerreros;

            MenuGrafico menuCambiarPersonaje = new MenuGrafico(guerreros, pregunta, opciones);
            return menuCambiarPersonaje.Run();
        }

        public async Task RunMainMenu(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            string[] opciones = { "Jugar", "Mostrar historial de Ganadores", "Acerca de", "Salir" };
            string elegir = "Elige una opcion";
            string[] portada = new string[]
            {
@" _____             _       ______              _            ",
@"/  __ \           | |      | ___ \            | |           ",
@"| /  \/  ___    __| |  ___ | |_/ / ___   __ _ | | _ __ ___  ",
@"| |     / _ \  / _` | / _ \|    / / _ \ / _` || || '_ ` _ \ ",
@"| \__/\| (_) || (_| ||  __/| |\ \|  __/| (_| || || | | | | |",
@" \____/ \___/  \__,_| \___|\_| \_|\___| \__,_||_||_| |_| |_|",
"                                             ",
"                      +.                     ",
"               .:-===-##.=--:.               ",
"           .-=+++++=-#*%*-+++++=-.           ",
"         -++++++++==%+###%-=+++++++:         ",
"       -+++++++++==@##%@%%@:+++++++++:       ",
"   . .++++++++++-+%*++*###%@+-+++++++++. .   ",
"  : :+++++++++-+####*+=++*%###+-=+++++++. :  ",
" :.:++++++++==#%@@***=*+=#*#@@%#-=+++++++..: ",
" - +++++++++=-#@@%.#+*+***#.@@@%:-++++++++ : ",
"- :+-=-=+-+==%%@@*#*+-*+-*++#@@@@#*==+++++. -",
"= =-*++*+*==@##@@@+:::::::--%@@@#%@@+-++++- =",
"= +=:+*=*+*%#%%@@@::.  :..-*+@%##***#*===+- =",
"= ++++*#*=++%#%@@@--  .=:.+++@#**#%%#%%%#=. =",
"- =*@@%*===-=#@@@@@=...-:::%#*#@@%*+#####%#:-",
" +#@%*+*=---==-++#@%+:..:=#%*@@@#*###*##%@%#.",
".#@@##*#@#+=%%%@@*%@+%===--==+#%*#***+*%%@@#=",
":%@@%**+*%@@%*@@@@+%@*-=*=-=+*==*+++*++%@@@%-",
".%@@@%*++++++%@@@@#+#==*=-:::=+-*++++++@@@@@-",
" =@@@@%##**#*%@@@@@+*=++==--+++=##+++*%@@@@#.",
"  *@@@@@@#-::@%%@@@++#=*=*+***+=%%+=@@@@@@%= ",
"   +%%%%=:+:@@#%@@%++#**#******%%@:-:*%%%*:  ",
"    .-: .--@%##@@@*+**#+*++#@@@##%@--  .     ",
"          :+##%@@%++*+@***++#@@%#*=:         ",
"             .=*#++*+*@%+*+++#*=.            ",
"                                             "
};

            MenuGrafico menuJuego = new MenuGrafico(portada, elegir, opciones);
            int opcion = menuJuego.Run();
            switch (opcion)
            {
                case 0:
                    await EmpezarJuego(archivos, torneo, rutaListaPjs, rutaJugador);
                    break;
                case 1:
                    mostrar.EscribirHistorialGanadores(rutaGanadores);
                    ascii.EscribirCentrado("Presione una tecla para continuar");
                    Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de continuar
                    await RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
                    break;
                case 2:
                    await creditos.MostrarCreditosYLeerReadme(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
                    break;
                case 3:
                    Environment.Exit(0);//Cierra la app
                    Console.ReadKey();
                    break;
            }
        }

        private async Task EmpezarJuego(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador)
        {
            // Comprobamos si los archivos existen y leemos los datos
            if (archivos.Existe(rutaListaPjs) && archivos.Existe(rutaJugador))
            {
                List<Personaje> listaPersonajesGuardados = archivos.LeerPersonajes(rutaListaPjs);
                Personaje jugador = archivos.LeerJugador(rutaJugador);
                int respuesta = PreguntarCambiarPersonaje();

                if (respuesta == 0)
                {
                    // El jugador desea seguir con su personaje actual
                    ascii.EscribirCentrado("¡Excelente! Continuemos con tu personaje actual.");
                }
                else
                {
                    ascii.EscribirCentrado("¡Entendido! Vamos a crear un nuevo personaje.");
                    try
                    {
                        File.Delete(rutaJugador);
                        ascii.EscribirCentrado($"El archivo {rutaJugador} ha sido borrado correctamente.");
                        FabricaDePersonajes fabrica = new FabricaDePersonajes();
                        fabrica.CrearPersonajeUsuario();
                        archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
                        jugador = archivos.LeerJugador(rutaJugador);
                    }
                    catch (Exception ex)
                    {
                        ascii.EscribirCentrado($"Error al borrar el archivo: {ex.Message}");
                    }
                }
                torneo.ComenzarTorneo(listaPersonajesGuardados, jugador);
            }
            else
            {
                FabricaDePersonajes fabrica = new FabricaDePersonajes();
                fabrica.CrearPersonajeUsuario();
                archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
                await fabrica.CrearPersonajes(); //Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
                archivos.GuardarPersonajes(fabrica.ListaPersonajes, rutaListaPjs);
                torneo.ComenzarTorneo(fabrica.ListaPersonajes, fabrica.Pj);
            }
        }
    }
}