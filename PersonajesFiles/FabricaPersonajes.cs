using EspacioPersonajes.PersonajesFiles;
using DatosYCaracteristicas.PersonajesFiles;
using EspConstantes.Helpers;
using EspacioFunciones.Helpers;
using EspacioMenu;
using EspacioArteAscii;
using EspacioArteAscii.GUI;

namespace espacioFabricaPersonajes
{
    public class FabricaDePersonajes
    {
        ArteAscii ascii = new ArteAscii();
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
            string[] graficoAscii = ascii.asciiHacha;
            string[] razas = Enum.GetNames(typeof(RazasPersonaje)); // Convertir enum a arreglo de strings
            string titulo = "Elige una raza";
            MenuGrafico menuPersonajes = new MenuGrafico(graficoAscii, titulo, razas);
            int opcion = menuPersonajes.Run();

            RazasPersonaje razaUsuario;//Invoco al enum con las razas de los personajes

            razaUsuario = (RazasPersonaje)(opcion);

            ascii.EscribirCentrado($"Raza seleccionada: {razaUsuario}");
            string linea, apodo, nombre;
            int edad;
            do
            {
                Console.Clear();
                ascii.EscribirCentrado("Raza seleccionada: " + razaUsuario);
                ascii.EscribirCentrado("Nombre: ");
                nombre = Console.ReadLine();
                ascii.EscribirCentrado("Apodo: ");
                apodo = Console.ReadLine();
                ascii.EscribirCentrado("Edad: ");
                linea = Console.ReadLine();

                // Intenta convertir la entrada en un número entero
                if (!int.TryParse(linea, out edad))
                {
                    ascii.EscribirCentrado("Edad no válida. Por favor, introduce una edad válida.");
                    continue; // Vuelve al inicio del bucle
                }

                // Verifica si la edad está dentro del rango permitido
                if (edad <= 18 || edad > Constantes.MaxEdad)
                {
                    ascii.EscribirCentrado("Edad fuera de rango. Por favor, introduce una edad válida.");
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
            int velocidad = 0;
            int destreza = 0;
            int fuerza = 0;
            int nivel = random.Next(1, 11);
            int armadura = 0;
            int salud = Constantes.MaxSalud;
            int suerte = random.Next(1, 11); // Asignar la suerte

            switch (raza)//Use gpt para que randomice datos segun la raza
            {
                case RazasPersonaje.Humano:
                    velocidad = random.Next(5, 8); // Velocidad moderada
                    destreza = random.Next(3, 5); // Destreza alta
                    fuerza = random.Next(3, 6); // Fuerza moderada
                    armadura = random.Next(3, 6); // Armadura moderada
                    break;
                case RazasPersonaje.Elfo:
                    velocidad = random.Next(6, 10); // Velocidad alta
                    destreza = random.Next(4, 5); // Destreza muy alta
                    fuerza = random.Next(2, 5); // Fuerza baja
                    armadura = random.Next(2, 5); // Armadura baja
                    break;
                case RazasPersonaje.Enano:
                    velocidad = random.Next(2, 5); // Velocidad baja
                    destreza = random.Next(2, 4); // Destreza moderada
                    fuerza = random.Next(6, 9); // Fuerza alta
                    armadura = random.Next(6, 10); // Armadura alta
                    break;
                case RazasPersonaje.Orco:
                    velocidad = random.Next(3, 6); // Velocidad baja-moderada
                    destreza = random.Next(2, 4); // Destreza baja-moderada
                    fuerza = random.Next(7, 10); // Fuerza alta
                    armadura = random.Next(5, 8); // Armadura alta
                    break;
                case RazasPersonaje.Goblin:
                    velocidad = random.Next(6, 10); // Velocidad alta
                    destreza = random.Next(3, 5); // Destreza alta
                    fuerza = random.Next(2, 4); // Fuerza baja
                    armadura = random.Next(1, 4); // Armadura baja
                    break;
                case RazasPersonaje.Centauro:
                    velocidad = random.Next(7, 10); // Velocidad muy alta
                    destreza = random.Next(3, 5); // Destreza alta
                    fuerza = random.Next(5, 8); // Fuerza alta
                    armadura = random.Next(4, 6); // Armadura moderada
                    break;
                case RazasPersonaje.Minotauro:
                    velocidad = random.Next(3, 6); // Velocidad moderada
                    destreza = random.Next(2, 4); // Destreza baja-moderada
                    fuerza = random.Next(8, 10); // Fuerza muy alta
                    armadura = random.Next(6, 9); // Armadura alta
                    break;
                case RazasPersonaje.Vampiro:
                    velocidad = random.Next(5, 8); // Velocidad alta
                    destreza = random.Next(4, 5); // Destreza muy alta
                    fuerza = random.Next(5, 7); // Fuerza alta
                    armadura = random.Next(3, 6); // Armadura moderada
                    break;
                case RazasPersonaje.Licántropo:
                    velocidad = random.Next(6, 9); // Velocidad alta
                    destreza = random.Next(3, 5); // Destreza alta
                    fuerza = random.Next(6, 9); // Fuerza muy alta
                    armadura = random.Next(4, 7); // Armadura alta
                    break;
                case RazasPersonaje.Troll:
                    velocidad = random.Next(2, 5); // Velocidad baja
                    destreza = random.Next(1, 3); // Destreza baja
                    fuerza = random.Next(8, 10); // Fuerza muy alta
                    armadura = random.Next(6, 9); // Armadura alta
                    break;
                case RazasPersonaje.Gólem:
                    velocidad = random.Next(1, 3); // Velocidad muy baja
                    destreza = random.Next(1, 2); // Destreza muy baja
                    fuerza = random.Next(9, 10); // Fuerza muy alta
                    armadura = random.Next(8, 10); // Armadura muy alta
                    break;
                case RazasPersonaje.Harpía:
                    velocidad = random.Next(7, 10); // Velocidad muy alta
                    destreza = random.Next(4, 5); // Destreza muy alta
                    fuerza = random.Next(2, 5); // Fuerza baja-moderada
                    armadura = random.Next(2, 5); // Armadura baja-moderada
                    break;
            }

            return new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura, salud, suerte);
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
