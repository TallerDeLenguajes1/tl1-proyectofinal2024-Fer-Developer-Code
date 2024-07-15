using System.Text.Json;
using EspacioPersonajes;
namespace EspacioJsonCreacion//Averiguar porque git no me deja subir la carpeta json
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
        public void GuardarGanador(Personaje ganador, DetallesPartida informacionPartida, string nombreArchivo)
        {
            List<HistorialPartida> listaGanadores = new List<HistorialPartida>();
            if (Existe(nombreArchivo))
            {
                string jsonExistente = File.ReadAllText(nombreArchivo);
                listaGanadores = JsonSerializer.Deserialize<List<HistorialPartida>>(jsonExistente);
            }

            HistorialPartida nuevaEntrada = new HistorialPartida(ganador, informacionPartida, DateTime.Now);

            listaGanadores.Add(nuevaEntrada);

            try
            {
                string jsonNuevo = JsonSerializer.Serialize(listaGanadores);
                File.WriteAllText(nombreArchivo, jsonNuevo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al serializar y guardar el archivo JSON: {ex.Message}");
            }
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
        public bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }

    public class HistorialPartida
    {
        private Personaje ganador;
        private DetallesPartida informacionPartida;
        private DateTime fecha;

        public HistorialPartida(Personaje ganador, DetallesPartida informacionPartida, DateTime fecha)
        {
            this.ganador = ganador;
            this.informacionPartida = informacionPartida;
            this.fecha = fecha;
        }//Ya empezó a funcionar, estaba mal instanciado el constructor
        public Personaje Ganador { get => ganador; }
        public DetallesPartida InformacionPartida { get => informacionPartida; }
        public DateTime Fecha { get => fecha; }
    }
    public class DetallesPartida
    {
        private int duracion;
        private DateTime hora;

        public DetallesPartida(int duracion)
        {
            this.duracion = duracion;
            this.hora = DateTime.Now;
        }
        public int Duracion { get => duracion; }
        public DateTime Hora { get => hora; }
    }
}