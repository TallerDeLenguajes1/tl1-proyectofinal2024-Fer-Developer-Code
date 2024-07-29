using DatosYCaracteristicas.PersonajesFiles;
using EspacioArteAscii.GUI;
using EspacioConstantes.Helpers;

namespace EspacioPersonajes.PersonajesFiles
{
    public class Personaje
    {
        ArteAscii ascii = new ArteAscii();
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
            int ataque = Caracteristicas.Agilidad * Caracteristicas.Fuerza * Caracteristicas.Nivel;
            int efectividad = random.Next(15, 101);
            int defensa = Defensor.Caracteristicas.Defensa * Defensor.Caracteristicas.Velocidad;
            int constAjuste = Constantes.Ajuste;
            int danioBase = ((ataque * efectividad) - defensa) / constAjuste;

            // Calcular si es un ataque crítico
            int suerte = Caracteristicas.Suerte;
            int probabilidadCritico = random.Next(1, 101);
            bool esCritico = probabilidadCritico <= suerte;
            int danioProvocado = esCritico ? danioBase * 2 : danioBase;//Operador ternario

            // Asegurarse de que el daño no sea negativo
            danioProvocado = Math.Max(danioProvocado, 0);

            Defensor.Caracteristicas.ReducirSalud(danioProvocado);

            if (esCritico)
            {
                string[] ataqueCritico = ascii.AsciiCritico;
                ascii.CambiarColorTexto("Rojo");
                ascii.CentrarAscii(ataqueCritico);
                ascii.EscribirCentrado($"¡{Datos.Nombre} Ha acertado un ataque crítico!");
                ascii.CambiarColorTexto("Blanco");
            }
        }
        public void TomarPocion()
        {
            if (Pociones > 0)
            {
                Caracteristicas.Salud += 35; // Recuperar 20 puntos de salud (puedes ajustar este valor)
                Pociones--;
            }
            else
            {
                ascii.EscribirCentrado($"{Datos.Nombre} no tiene más pociones.");
            }
        }
    }
    public enum RazasPersonaje
    { Humano, Elfo, Enano, Orco, Goblin, Centauro, Minotauro, Vampiro, Licántropo, Troll, Gólem, Harpía }
}