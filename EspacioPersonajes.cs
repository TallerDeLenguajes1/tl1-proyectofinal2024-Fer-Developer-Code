using DatosYCaracteristicas;
using EspConstantes;
namespace EspacioPersonajes
{
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Personaje(Datos datosPersonaje, Caracteristicas caracteristicasPersonaje)
        {
            this.datos = datosPersonaje;
            this.caracteristicas = caracteristicasPersonaje;
        }

        public Datos DatosPersonaje { get => datos; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicas; }

        public void Atacar(Personaje Defensor)
        {
            Random random = new Random();
            int ataque = CaracteristicasPersonaje.Destreza * CaracteristicasPersonaje.Fuerza * CaracteristicasPersonaje.Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = Defensor.CaracteristicasPersonaje.Armadura * Defensor.CaracteristicasPersonaje.Velocidad;
            int constAjuste = Constantes.ajuste;
            int danioProvocado = ((ataque * efectividad) - defensa) / constAjuste;
            Defensor.CaracteristicasPersonaje.Salud = Defensor.CaracteristicasPersonaje.Salud - danioProvocado;
        }
    }
    public enum RazasPersonaje
    { Humano, Elfo, Enano, Orco, Goblin, Centauro, Minotauro, Vampiro, Licántropo, Troll, Gólem, Harpía }
}