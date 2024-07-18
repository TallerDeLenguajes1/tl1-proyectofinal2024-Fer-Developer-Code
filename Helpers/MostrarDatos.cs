using EspacioPersonajes.PersonajesFiles;
using EspacioJsonCreacion;
namespace EspacioMostrarDatos.Helpers
{
    public class MostrarDatos
    {
        HistorialJson archivosPjsGanadores = new HistorialJson();
        public void MostrarCaracteristicas(Personaje personaje)
        {
            Console.WriteLine($"Nombre: {personaje.Datos.Nombre}, Apodo: {personaje.Datos.Apodo}");
            Console.WriteLine($"Raza: {personaje.Datos.Raza}, Edad: {personaje.Datos.Edad}");
            Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}, Destreza: {personaje.Caracteristicas.Destreza}");
            Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}, Nivel: {personaje.Caracteristicas.Nivel}");
            Console.WriteLine($"Armadura: {personaje.Caracteristicas.Armadura}, Salud: {personaje.Caracteristicas.Salud}");
            Console.WriteLine();
        }
        public void EscribirHistorialGanadores(string rutaGanadores)
        {
            List<HistorialPartida> ganadores = archivosPjsGanadores.LeerGanadores(rutaGanadores);
            if (ganadores.Count == 0)
            {
                Console.WriteLine("No hay ganadores registrados.");
                return;
            }
            Console.WriteLine("Historial de ganadores:");
            foreach (HistorialPartida ganador in ganadores)
            {
                MostrarCaracteristicas(ganador.Ganador);
                Console.WriteLine($"Duración del torneo: {ganador.InformacionPartida.Duracion} segundos");
                Console.WriteLine($"Cantidad de ataques: {ganador.InformacionPartida.ContadorAtaques}");
                Console.WriteLine($"Hora de la victoria: {ganador.InformacionPartida.Hora.Hour}:{ganador.InformacionPartida.Hora.Minute}");
            }
        }

    }
}