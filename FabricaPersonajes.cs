using EspacioPersonajes.PersonajesFiles;
using DatosYCaracteristicas.PersonajesFiles;
using EspConstantes.Helpers;
using EspacioFunciones.Helpers;

namespace espacioFabricaPersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> listaPersonajes = new List<Personaje>();
        private Personaje pj;//Personaje propio del jugador
        private Random random = new Random();
        private FuncionesAsync funcionesAsync = new FuncionesAsync();//LLama a la API de nombres
        public List<Personaje> ListaPersonajes { get => listaPersonajes; }
        public Personaje Pj { get => pj; }//Atributo publico

        public async Task CrearPersonajes()//Crea personajes al azar
        {
            int maxEnemigos = Constantes.MaxEnemigos;
            // Creación de personajes aleatorios
            for (int i = 0; i < maxEnemigos; i++)
            {
                EspacioApiJsonToCsharp.Helpers.infoPj informacionEnemigo = await funcionesAsync.GetNombreAsync();//informacion sobre nombre y apodo para el enemigo creado al azar
                string nombreEnemigo = informacionEnemigo.name;
                string apodoEnemigo = informacionEnemigo.username;
                CrearPersonajeAleatorio(nombreEnemigo, apodoEnemigo);//LLama a la funcuon que crea un personaje al azar y le asigna el nombre y apodos generados en informacion enemigo
            }
        }
        public void CrearPersonajeUsuario()//Genera un personaje propio para le usuario
        {
            Console.WriteLine("Crea tu personaje:");
            Console.Write("Elige tu raza:\n");
            int i = 1;
            foreach (object raza in Enum.GetValues(typeof(RazasPersonaje)))
            {
                Console.WriteLine($"\t{i}. {raza}");
                i++;
            }

            RazasPersonaje razaUsuario;//Invoco al enum con las razas de los personajes
            while (true)
            {
                Console.Write("Elige la posición o el nombre de la raza: ");
                string input = Console.ReadLine();

                // Intentar parsear como número de opción
                if (int.TryParse(input, out int opcion) && opcion >= 1 && opcion <= Enum.GetValues(typeof(RazasPersonaje)).Length)
                {
                    razaUsuario = (RazasPersonaje)(opcion - 1);
                    break; // Salir del bucle si el parseo fue exitoso
                }

                // Intentar parsear como nombre del enum 
                else if (Enum.TryParse<RazasPersonaje>(input, true, out razaUsuario))
                {
                    break; // Salir del bucle si el parseo fue exitoso
                }
                Console.WriteLine("Raza no válida. Por favor, elige una raza válida.");
            }

            Console.WriteLine($"Raza seleccionada: {razaUsuario}");
            string linea, apodo, nombre;
            int edad;
            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Apodo: ");
                apodo = Console.ReadLine();
                Console.Write("Edad: ");
                linea = Console.ReadLine();

                // Intenta convertir la entrada en un número entero
                if (!int.TryParse(linea, out edad))
                {
                    Console.WriteLine("Edad no válida. Por favor, introduce una edad válida.");
                    continue; // Vuelve al inicio del bucle
                }

                // Verifica si la edad está dentro del rango permitido
                if (edad <= 18 || edad > Constantes.MaxEdad)
                {
                    Console.WriteLine("Edad fuera de rango. Por favor, introduce una edad válida.");
                    continue; // Vuelve al inicio del bucle
                }
                break;

            } while (true); // Bucle infinito, se sale con "break"


            DateTime fechaNac = DateTime.Today.AddYears(-edad);
            Datos datosUsuario = new Datos(razaUsuario, nombre, apodo, fechaNac, edad);
            Caracteristicas caracteristicasUsuario = AsignarCaracteristicas(razaUsuario);
            Personaje personajeUsuario = new Personaje(datosUsuario, caracteristicasUsuario);
            pj = personajeUsuario;
        }

        private void CrearPersonajeAleatorio(string nombrePj, string apodoPj)
        {
            RazasPersonaje razaAleatoria = (RazasPersonaje)random.Next(Enum.GetNames(typeof(RazasPersonaje)).Length);
            DateTime fechaNac = CrearFechaNac(razaAleatoria, out int edad);
            Datos datosAleatorios = new Datos(razaAleatoria, nombrePj, apodoPj, fechaNac, edad);

            Caracteristicas caracteristicasAleatorias = AsignarCaracteristicas(razaAleatoria);
            Personaje personajeAleatorio = new Personaje(datosAleatorios, caracteristicasAleatorias);
            listaPersonajes.Add(personajeAleatorio);
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
