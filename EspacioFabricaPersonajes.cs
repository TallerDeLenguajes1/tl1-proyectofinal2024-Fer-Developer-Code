using EspacioPersonajes;
namespace espacioFabricaPersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        private Random random = new Random();

        public FabricaDePersonajes()
        {
            RazasPersonaje razaAleatoria = (RazasPersonaje)random.Next(Enum.GetNames(typeof(RazasPersonaje)).Length);
            switch (razaAleatoria)//El switch y otras estructuras solo funcionan una vez dentro del constructor o cualquier estructura que no sea una clase
            {
                case RazasPersonaje.Humano:

                    break;
                case RazasPersonaje.Elfo:

                    break;
                case RazasPersonaje.Enano:

                    break;
                case RazasPersonaje.Orco:

                    break;
                case RazasPersonaje.Troll:

                    break;
                case RazasPersonaje.Goblin:
                break;
            }
        }
    }
}