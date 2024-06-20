namespace EspacioPersonajes
{
    public class Personaje
    {
        private Datos datosPersonaje = new Datos();
        private Caracteristicas caracteristicasPersonaje = new Caracteristicas();
        public void Atacar()
        {

        }
    }
    public class Datos
    {
        private RazasPersonaje raza;
        private string? nombre, apodo;
        private DateTime fechaNac;
        private int edad;//Max 300
    }
    public class Caracteristicas
    {
        private int velocidad;   // Rango: 1-10
        private int destreza;    // Rango: 1-5
        private int fuerza;      // Rango: 1-10
        private int nivel;       // Rango: 1-10
        private int armadura;    // Rango: 1-10
        private int salud;       // Valor máximo: 100
    }
    public class PersonajesJson
    {

    }
    public enum RazasPersonaje
    {
        Humano,
        Elfo,
        Enano,
        Orco,
        Goblin,
        Centauro,
        Minotauro,
        Vampiro,
        Licántropo,
        Troll,
        Gólem,
        Harpía
    }
}