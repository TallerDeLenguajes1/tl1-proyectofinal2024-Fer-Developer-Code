using espacioPersonajes;
namespace espacioFabrica
{
    public class FabricaDePersonajes
    {
        private Personajes personaje = new Personajes();

        public Personajes Personaje { get => personaje; set => personaje = value; }
    }
}