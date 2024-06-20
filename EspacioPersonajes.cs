namespace EspacioPersonajes
{
    public class Personaje
    {
        private Datos datosPersonaje;
        private Caracteristicas caracteristicasPersonaje;

        public Personaje(Datos datosPersonaje, Caracteristicas caracteristicasPersonaje)
        {
            this.datosPersonaje = datosPersonaje;
            this.caracteristicasPersonaje = caracteristicasPersonaje;
        }

        public Datos DatosPersonaje { get => datosPersonaje; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; }

        public void Atacar()
        {
            Random random = new Random();
            int ataque = CaracteristicasPersonaje.Destreza * CaracteristicasPersonaje.Fuerza * CaracteristicasPersonaje.Nivel;
            int efectividad = random.Next(1, 101);

        }
    }

    public class Datos
    {
        private RazasPersonaje raza;
        private string nombre, apodo;
        private DateTime fechaNac;
        private int edad;//Max 300

        public Datos(RazasPersonaje raza, string nombre, string apodo, DateTime fechaNac, int edad)
        {
            this.raza = raza;
            this.nombre = nombre;
            this.apodo = apodo;
            this.fechaNac = fechaNac;
            this.edad = edad;
        }

        public RazasPersonaje Raza { get => raza; }
        public string Nombre { get => nombre; }
        public string Apodo { get => apodo; }
        public DateTime FechaNac { get => fechaNac; }
        public int Edad { get => edad; }
    }
    public class Caracteristicas
    {
        private int velocidad;   // Rango: 1-10
        private int destreza;    // Rango: 1-5
        private int fuerza;      // Rango: 1-10
        private int nivel;       // Rango: 1-10
        private int armadura;    // Rango: 1-10
        private int salud;       // Valor máximo: 100

        public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
        {
            this.velocidad = velocidad;
            this.destreza = destreza;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
            this.salud = salud;
        }

        public int Velocidad { get => velocidad; }
        public int Destreza { get => destreza; }
        public int Fuerza { get => fuerza; }
        public int Nivel { get => nivel; }
        public int Armadura { get => armadura; }
        public int Salud { get => salud; }
    }
    public class PersonajesJson
    {

    }

    public enum RazasPersonaje
    {
        Humano, Elfo, Enano, Orco, Goblin, Centauro, Minotauro, Vampiro, Licántropo, Troll, Gólem, Harpía
    }
}