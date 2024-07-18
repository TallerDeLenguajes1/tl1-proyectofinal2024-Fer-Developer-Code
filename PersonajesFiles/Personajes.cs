using DatosYCaracteristicas.PersonajesFiles;
using EspConstantes.Helpers;
namespace EspacioPersonajes.PersonajesFiles
{
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;
        private int pociones = 3;
        private int contadorAtaques = 0;

        public Personaje(Datos datos, Caracteristicas caracteristicas)
        {
            this.datos = datos;
            this.caracteristicas = caracteristicas;
        }

        public Datos Datos { get => datos; }
        public Caracteristicas Caracteristicas { get => caracteristicas; }//Empezó a funcionar el programa cuando cambié el nombre de DatosPersonajes CaracteristicasPersonajes a solo Datos y Caracteristicas
        public int Pociones { get => pociones; set => pociones = value; }
        public int ContadorAtaques { get => contadorAtaques; }

        public void Atacar(Personaje Defensor)
        {
            Random random = new Random();
            contadorAtaques++;
            int ataque = Caracteristicas.Destreza * Caracteristicas.Fuerza * Caracteristicas.Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = Defensor.Caracteristicas.Armadura * Defensor.Caracteristicas.Velocidad;
            int constAjuste = Constantes.ajuste;
            int danioProvocado = ((ataque * efectividad) - defensa) / constAjuste;
            Defensor.Caracteristicas.ReducirSalud(danioProvocado);
        }
        public void TomarPocion()
        {
            if (Pociones > 0)
            {
                Caracteristicas.Salud += 35; // Recuperar 20 puntos de salud (puedes ajustar este valor)
                Pociones--;
                Console.WriteLine($"{Datos.Nombre} ha tomado una poción de vida. Salud: {Caracteristicas.Salud}, Pociones restantes: {Pociones}");
            }
            else
            {
                Console.WriteLine($"{Datos.Nombre} no tiene más pociones.");
            }
        }
    }
    public enum RazasPersonaje
    { Humano, Elfo, Enano, Orco, Goblin, Centauro, Minotauro, Vampiro, Licántropo, Troll, Gólem, Harpía }
}