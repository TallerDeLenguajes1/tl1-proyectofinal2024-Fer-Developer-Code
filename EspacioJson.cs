using System.Text.Json;
using EspacioPersonajes;
namespace EspacioJsonCreacion
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
        {
            string jsonListaPersonajes = JsonSerializer.Serialize(listaPersonajes);
            File.WriteAllText(nombreArchivo, jsonListaPersonajes);
        }
        public void GuardarPersonajeJugador(Personaje jugador, string nombreArchivo)
        {
            string jsonPersonajeJugador = JsonSerializer.Serialize(jugador);
            File.WriteAllText(nombreArchivo, jsonPersonajeJugador);
        }
        // Método para leer una lista de personajes desde un archivo JSON
        public List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            if (!Existe(nombreArchivo))
            {
                throw new FileNotFoundException($"El archivo {nombreArchivo} no existe o está vacío.");
            }

            string jsonString = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<Personaje>>(jsonString);
        }
        public Personaje LeerJugador(string nombreArchivo)
        {
            if (!Existe(nombreArchivo))
            {
                throw new FileNotFoundException($"El archivo {nombreArchivo} no existe o está vacío.");
            }
            string jsonString = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<Personaje>(jsonString);
        }

        // Método para verificar si un archivo existe y tiene datos
        public bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
    public class HistorialJson
    {
        public void GuardarGanador(Personaje ganador, string informacionPartida, string nombreArchivo)
        {
            List<HistorialPartida> historial = new List<HistorialPartida>();

            if (Existe(nombreArchivo))
            {
                historial = LeerGanadores(nombreArchivo);
            }

            HistorialPartida nuevaEntrada = new HistorialPartida(ganador, informacionPartida, DateTime.Now);

            historial.Add(nuevaEntrada);

            string jsonHistorial = JsonSerializer.Serialize(historial);
            File.WriteAllText(nombreArchivo, jsonHistorial);
        }

        // Método para leer una lista de personajes ganadores desde un archivo JSON
        public List<HistorialPartida> LeerGanadores(string nombreArchivo)
        {
            if (!Existe(nombreArchivo))
            {
                throw new FileNotFoundException($"El archivo {nombreArchivo} no existe o está vacío.");
            }

            string jsonString = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<HistorialPartida>>(jsonString);
        }
        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
    public class HistorialPartida
    {
        private Personaje ganador;
        private string informacionPartida;
        private DateTime fecha;

        public HistorialPartida(Personaje ganador, string informacionPartida, DateTime fecha)
        {
            this.ganador = ganador;
            this.informacionPartida = informacionPartida;
            this.fecha = fecha;
        }

        public Personaje Ganador { get => ganador; }
        public string InformacionPartida { get => informacionPartida; }
        public DateTime Fecha { get => fecha; }
    }
}