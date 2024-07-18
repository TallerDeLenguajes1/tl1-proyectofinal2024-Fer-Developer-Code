using EspacioPersonajes.PersonajesFiles;
namespace DatosYCaracteristicas.PersonajesFiles
{
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
        private int agilidad;    // Rango: 1-5
        private int fuerza;      // Rango: 1-10
        private int nivel;       // Rango: 1-10
        private int defensa;    // Rango: 1-10
        private int salud;       // Valor máximo: 100
        private int suerte;

        public Caracteristicas(int velocidad, int agilidad, int fuerza, int nivel, int defensa, int salud, int suerte)
        {
            this.velocidad = velocidad;
            this.agilidad = agilidad;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.defensa = defensa;
            this.salud = salud;
            this.suerte = suerte;
        }
        public int Velocidad { get => velocidad; }
        public int Agilidad { get => agilidad; }
        public int Fuerza { get => fuerza; }
        public int Nivel { get => nivel; }
        public int Defensa { get => defensa; }
        public int Salud { get => salud; set => salud = value; }
        public int Suerte { get => suerte; }

        public void ReducirSalud(int danio)
        {
            Salud -= danio;
            if (Salud < 0)
            {
                Salud = 0;
            }
        }
    }
}