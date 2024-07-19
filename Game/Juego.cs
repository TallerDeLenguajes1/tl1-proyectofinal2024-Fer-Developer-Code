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
        private MostrarDatos mostrar = new MostrarDatos();
        private int PreguntarCambiarPersonaje()
        {
            string pregunta = "¿Deseas seguir con tu personaje actual o crear uno nuevo? (1: Sí, 2: No): ";
            string[] opciones = { "Si", "No" };
            MenuGrafico menuCambiarPersonaje = new MenuGrafico(pregunta, opciones);
            return menuCambiarPersonaje.Run();
        }

        public async void RunMainMenu(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            string presentacion = "Juego de la mazmorra (Titulo pendiente)";
            string[] opciones = { "Jugar", "Mostrar historial de Ganadores", "Creditos", "Salir" };
            MenuGrafico menuJuego = new MenuGrafico(presentacion, opciones);
            int opcion = menuJuego.Run();
            switch (opcion)
            {
                case 0:
                    await EmpezarJuego(archivos, torneo, rutaListaPjs, rutaJugador);
                    break;
                case 1:
                    mostrar.EscribirHistorialGanadores(rutaGanadores);
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de continuar
                    RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
                    break;
                case 2:
                    creditos.MostrarCreditosYLeerReadme(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
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
                        jugador = archivos.LeerJugador(rutaJugador);
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
        }
    }
}