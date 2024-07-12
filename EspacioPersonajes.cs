using DatosYCaracteristicas;
using EspConstantes;
namespace EspacioPersonajes
{
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;
        private int pociones = 3;

        public Personaje(Datos datosPersonaje, Caracteristicas caracteristicasPersonaje)
        {
            this.datos = datosPersonaje;
            this.caracteristicas = caracteristicasPersonaje;
        }

        public Datos DatosPersonaje { get => datos; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicas; }
        public int Pociones { get => pociones; set => pociones = value; }

        public void Atacar(Personaje Defensor)
        {
            Random random = new Random();
            int ataque = CaracteristicasPersonaje.Destreza * CaracteristicasPersonaje.Fuerza * CaracteristicasPersonaje.Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = Defensor.CaracteristicasPersonaje.Armadura * Defensor.CaracteristicasPersonaje.Velocidad;
            int constAjuste = Constantes.ajuste;
            int danioProvocado = ((ataque * efectividad) - defensa) / constAjuste;
            Defensor.CaracteristicasPersonaje.ReducirSalud(danioProvocado);
        }
        public void TomarPocion()
        {
            if (Pociones > 0)
            {
                CaracteristicasPersonaje.Salud += 20; // Recuperar 20 puntos de salud (puedes ajustar este valor)
                Pociones--;
                Console.WriteLine($"{DatosPersonaje.Nombre} ha tomado una poción de vida. Salud: {CaracteristicasPersonaje.Salud}, Pociones restantes: {Pociones}");
            }
            else
            {
                Console.WriteLine($"{DatosPersonaje.Nombre} no tiene más pociones.");
            }
        }
    }
    public enum RazasPersonaje
    { Humano, Elfo, Enano, Orco, Goblin, Centauro, Minotauro, Vampiro, Licántropo, Troll, Gólem, Harpía }
}