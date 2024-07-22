using System.Diagnostics;
using EspacioJuego;
using EspacioJsonCreacion;
using EspacioTorneo;
using EspacioArteAscii.GUI;

namespace EspacioOpciones
{
    public class Creditos
    {
        public async Task MostrarCreditosYLeerReadme(PersonajesJson archivos, Torneo torneo, string rutaListaPjs, string rutaJugador, string rutaGanadores)
        {
            ArteAscii ascii = new ArteAscii();
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
                    ascii.EscribirCentrado("El archivo README.md no se encontró en la ruta especificada.");
                }
            }
            catch (Exception ex)
            {
                ascii.EscribirCentrado($"Ocurrió un error al intentar abrir el archivo README.md: {ex.Message}");
            }

            ascii.EscribirCentrado("Presione una tecla para continuar");
            Console.ReadKey();
            Juego empezar = new Juego();//Debe estar dentro del metodo y no en la clase porque se rompe el program
            await empezar.RunMainMenu(archivos, torneo, rutaListaPjs, rutaJugador, rutaGanadores);
        }
    }
}