using EspacioPersonajes;
using EspacioApiJsonToCsharp.Helpers;
using DatosYCaracteristicas;
using EspacioFunciones.Helpers;
namespace espacioFabricaPersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        private Random random = new Random();
    
        public FabricaDePersonajes()
        {
            var funcionesAsync = new FuncionesAsync();
            //var NombrePj = await funcionesAsync.GetNombreAsync();
            RazasPersonaje razaAleatoria = (RazasPersonaje)random.Next(Enum.GetNames(typeof(RazasPersonaje)).Length);
            switch (razaAleatoria)//El switch y otras estructuras solo funcionan una vez dentro del constructor o cualquier estructura que no sea una clase
            {
                case RazasPersonaje.Humano:
                    DateTime fecha = DateTime.Now;
                    //int edad = DateTime.Now - fecha.Year;
                    //var DatosHumano = new Datos(RazasPersonaje.Humano, NombrePj.name, NombrePj.maiden_name, fecha, edad);
                    var caracteristicasPersonaje = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    //var PersonajeHumano = new Personaje(DatosHumano, caracteristicasPersonaje);
                    //ListaPersonajes.Add(PersonajeHumano);
                    break;
                case RazasPersonaje.Elfo:

                    break;
                case RazasPersonaje.Enano:

                    break;
                case RazasPersonaje.Orco:

                    break;
                case RazasPersonaje.Goblin:
                    break;
                case RazasPersonaje.Centauro:
                    break;
                case RazasPersonaje.Minotauro:
                    break;
                case RazasPersonaje.Vampiro:
                    break;
                case RazasPersonaje.Licántropo:
                    break;
                case RazasPersonaje.Troll:
                    break;
                case RazasPersonaje.Gólem:
                    break;
                case RazasPersonaje.Harpía:
                    break;
            }
        }
    }
}