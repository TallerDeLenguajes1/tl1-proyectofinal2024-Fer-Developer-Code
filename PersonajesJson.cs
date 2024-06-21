using System.Text.Json;
namespace EspacioPersonajes
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
        {
            string jsonListaPersonajes = JsonSerializer.Serialize(listaPersonajes);
            File.WriteAllText(nombreArchivo, jsonListaPersonajes);
        }
        // Método para leer una lista de personajes desde un archivo JSON
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            if (!Existe(nombreArchivo))
            {
                throw new FileNotFoundException($"El archivo {nombreArchivo} no existe o está vacío.");
            }

            string jsonString = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<Personaje>>(jsonString);
        }

        // Método para verificar si un archivo existe y tiene datos
        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
}