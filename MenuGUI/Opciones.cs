using System.Diagnostics;
using EspacioJuego;
using EspacioJsonCreacion;
using EspacioTorneo;
namespace EspacioOpciones
{
    public class Creditos
    {
        public void MostrarCreditosYLeerReadme(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            try
            {
                // Ruta relativa al archivo README.md
                string readmeRuta = "readme.md";

                // Verifica si el archivo existe
                if (File.Exists(readmeRuta))
                {
                    // Ejecuta Visual Studio Code y abre el archivo README.md
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "code",
                        Arguments = readmeRuta,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Console.WriteLine("El archivo README.md no se encontró en la ruta especificada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al intentar abrir el archivo README.md: {ex.Message}");
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Juego empezar = new Juego();
            empezar.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
        }
    }
}