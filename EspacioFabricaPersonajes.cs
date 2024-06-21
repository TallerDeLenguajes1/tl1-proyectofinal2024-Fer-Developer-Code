using EspacioPersonajes;
using DatosYCaracteristicas;
using EspacioApiJsonToCsharp.Helpers;
using EspConstantes;

namespace espacioFabricaPersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        private Random random = new Random();
        public List<Personaje> ListaPersonajes1 { get => ListaPersonajes; }

        public FabricaDePersonajes()
        {
            // Creación del personaje del usuario
            CrearPersonajeUsuario();
            int maxEnemigos = Constantes.MaxEnemigos;
            // Creación de personajes aleatorios
            for (int i = 0; i < maxEnemigos; i++)
            {
                CrearPersonajeAleatorio();
            }
        }

        private void CrearPersonajeUsuario()
        {
            Console.WriteLine("Crea tu personaje:");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apodo: ");
            string apodo = Console.ReadLine();
            Console.Write("Raza (Humano, Elfo, Enano, Orco): ");
            RazasPersonaje razaUsuario;
            while (!Enum.TryParse(Console.ReadLine(), out razaUsuario))
            {
                Console.Write("Raza no válida. Por favor, elige una raza válida: ");
            }
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            DateTime fechaNac = DateTime.Today.AddYears(-edad);
            var datosUsuario = new Datos(razaUsuario, nombre, apodo, fechaNac, edad);

            var caracteristicasUsuario = AsignarCaracteristicas(razaUsuario);
            var personajeUsuario = new Personaje(datosUsuario, caracteristicasUsuario);
            ListaPersonajes.Add(personajeUsuario);
        }

        private void CrearPersonajeAleatorio()
        {
            NombrePersonajeJson nombrePj = new NombrePersonajeJson();
            RazasPersonaje razaAleatoria = (RazasPersonaje)random.Next(Enum.GetNames(typeof(RazasPersonaje)).Length);
            DateTime fechaNac = CrearFechaNac(razaAleatoria, out int edad);
            var datosAleatorios = new Datos(razaAleatoria, "Nombre", "Apodo", fechaNac, edad);

            var caracteristicasAleatorias = AsignarCaracteristicas(razaAleatoria);
            var personajeAleatorio = new Personaje(datosAleatorios, caracteristicasAleatorias);
            ListaPersonajes.Add(personajeAleatorio);
        }

        private Caracteristicas AsignarCaracteristicas(RazasPersonaje raza)
        {
            int velocidad = random.Next(1, 11);
            int destreza = random.Next(1, 6);
            int fuerza = random.Next(1, 11);
            int nivel = random.Next(1, 11);
            int armadura = random.Next(1, 11);
            int salud = Constantes.MaxSalud;

            switch (raza)
            {
                case RazasPersonaje.Humano:
                    fuerza = random.Next(1, 8); // Ejemplo: Fuerza de un humano es de 1 a 7
                    break;
                case RazasPersonaje.Elfo:
                    fuerza = random.Next(1, 6); // Ejemplo: Fuerza de un elfo es de 1 a 5
                    break;
                case RazasPersonaje.Enano:
                    fuerza = random.Next(4, 10); // Ejemplo: Fuerza de un enano es de 4 a 9
                    armadura = random.Next(5, 11); // Ejemplo: Armadura de un enano es de 5 a 10
                    break;
                case RazasPersonaje.Orco:
                    fuerza = random.Next(7, 11); // Ejemplo: Fuerza de un orco es de 7 a 10
                    velocidad = random.Next(1, 6); // Ejemplo: Velocidad de un orco es de 1 a 5
                    break;
                    // Agrega más casos según la raza si es necesario
            }

            return new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura, salud);
        }

        private DateTime CrearFechaNac(RazasPersonaje raza, out int edad)
        {
            int anioMin, anioMax;
            switch (raza)
            {
                case RazasPersonaje.Humano:
                    anioMin = DateTime.Today.Year - 65; // Maxima edad 65
                    anioMax = DateTime.Today.Year - 18; // Minima edad 18
                    break;
                case RazasPersonaje.Elfo:
                    anioMin = DateTime.Today.Year - Constantes.MaxEdad; // Maxima edad 300
                    anioMax = DateTime.Today.Year - 100; // Minima edad 100
                    break;
                case RazasPersonaje.Enano:
                    anioMin = DateTime.Today.Year - 150; // Maxima edad 150
                    anioMax = DateTime.Today.Year - 50; // Minima edad 50
                    break;
                case RazasPersonaje.Orco:
                    anioMin = DateTime.Today.Year - 50; // Maxima edad 50
                    anioMax = DateTime.Today.Year - 10; // Minima edad 10
                    break;
                // Agrega más rangos de edad según la raza
                default:
                    anioMin = DateTime.Today.Year - 100;
                    anioMax = DateTime.Today.Year - 1;
                    break;
            }

            DateTime fechaNac = new DateTime(random.Next(anioMin, anioMax + 1), random.Next(1, 13), random.Next(1, 29));
            edad = DateTime.Today.Year - fechaNac.Year;
            return fechaNac;
        }
    }
}
