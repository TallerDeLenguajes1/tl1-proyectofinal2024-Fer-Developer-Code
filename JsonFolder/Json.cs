using System.Text.Json;
using EspacioPersonajes.PersonajesFiles;
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
    public class HistorialGanadoresJson
    {
        List<HistorialPartida> listaGanadores = new List<HistorialPartida>();//Lo moví 2 lineas mas arriba desde la 49 para ver si sigue funcionando
        public void GuardarGanador(Personaje ganador, DetallesPartida informacionPartida, string nombreArchivo)
        {
            if (Existe(nombreArchivo))
            {
                string jsonExistente = File.ReadAllText(nombreArchivo);
                listaGanadores = JsonSerializer.Deserialize<List<HistorialPartida>>(jsonExistente);
            }

            DetallesPartida detallesConFecha = new DetallesPartida(informacionPartida.Duracion, informacionPartida.ContadorAtaques, DateTime.Now);
            HistorialPartida nuevaEntrada = new HistorialPartida(ganador, informacionPartida);

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
            try
            {
                string jsonString = File.ReadAllText(nombreArchivo);
                return JsonSerializer.Deserialize<List<HistorialPartida>>(jsonString);
            }
            catch (Exception)
            {
                return new List<HistorialPartida>(); // Retornar lista vacía en caso de excepción
            }
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

        public HistorialPartida(Personaje ganador, DetallesPartida informacionPartida)
        {
            this.ganador = ganador;
            this.informacionPartida = informacionPartida;
        }//Ya empezó a funcionar, estaba mal instanciado el constructor
        public Personaje Ganador { get => ganador; }
        public DetallesPartida InformacionPartida { get => informacionPartida; }
    }
    public class DetallesPartida
    {
        private int duracion;
        private int contadorAtaques;
        private DateTime fecha;

        public DetallesPartida(int duracion, int contadorAtaques, DateTime fecha)
        {
            this.duracion = duracion;
            this.contadorAtaques = contadorAtaques;
            this.fecha = fecha;
        }
        public int Duracion { get => duracion; }
        public int ContadorAtaques { get => contadorAtaques; }
        public DateTime Fecha { get => fecha; }
    }
}