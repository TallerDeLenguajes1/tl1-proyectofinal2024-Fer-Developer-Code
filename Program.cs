using espacioFabricaPersonajes;
using EspacioJsonCreacion;
using EspacioPersonajes.PersonajesFiles;
using EspacioArteAscii.GUI;
using EspacioTorneo;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ArteAscii ascii = new ArteAscii();
        PersonajesJson archivos = new PersonajesJson();
        var torneo = new Torneo();

        // Rutas de los archivos JSON
        string rutaListaPjs = "JsonFolder/Personajes.json";
        string rutaJugador = "JsonFolder/rutaJugador.json";

        // Comprobamos si los archivos existen y leemos los datos
        if (archivos.Existe(rutaListaPjs) && archivos.Existe(rutaJugador))
        {
            List<Personaje> listaPersonajesGuardados = archivos.LeerPersonajes(rutaListaPjs);
            Personaje jugador = archivos.LeerJugador(rutaJugador);
            int respuesta;
            do
            {
                Console.Write("¿Deseas seguir con tu personaje actual o crear uno nuevo? (1: Sí, 2: No): ");
            } while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta != 1 && respuesta != 2);

            if (respuesta == 1)
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
                    FabricaDePersonajes personajes = new FabricaDePersonajes();
                    FabricaDePersonajes fabrica = new FabricaDePersonajes();
                    fabrica.CrearPersonajeUsuario();
                    archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al borrar el archivo: {ex.Message}");
                }
            }
            torneo.ComenzarTorneo(archivos.LeerPersonajes(rutaListaPjs), archivos.LeerJugador(rutaJugador));
        }
        else
        {
            FabricaDePersonajes personajes = new FabricaDePersonajes();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            fabrica.CrearPersonajeUsuario();
            await personajes.CrearPersonajes(); //Logro funcionar, supongo que es porque despues de todo este tiempo habia que tener cuidado con el await
            archivos.GuardarPersonajes(personajes.ListaPersonajes, rutaListaPjs);
            archivos.GuardarPersonajeJugador(fabrica.Pj, rutaJugador);
            torneo.ComenzarTorneo(personajes.ListaPersonajes, fabrica.Pj);
        }
    }
}