using EspacioPersonajes;
using DatosYCaracteristicas;
using EspacioApiJsonToCsharp.Helpers;
using EspacioFunciones;
namespace espacioFabricaPersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> ListaPersonajes = new List<Personaje>();
        private Random random = new Random();

        public FabricaDePersonajes()
        {
            NombrePersonajeJson nombrePj = new NombrePersonajeJson();
            RazasPersonaje razaAleatoria = (RazasPersonaje)random.Next(Enum.GetNames(typeof(RazasPersonaje)).Length);
            switch (razaAleatoria)//El switch y otras estructuras solo funcionan una vez dentro del constructor o cualquier estructura que no sea una clase
            {
                case RazasPersonaje.Humano:
                    DateTime fechaNacHumano = crearFechaNac(1961, 2001);
                    int edadHumano = DateTime.Today.Year - fechaNacHumano.Year;
                    var datosHumano = new Datos(RazasPersonaje.Humano, "Jorge", "Perro", fechaNacHumano, edadHumano);
                    var caracteristicasHumano = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeHumano = new Personaje(datosHumano, caracteristicasHumano);
                    ListaPersonajes1.Add(personajeHumano);
                    break;

                case RazasPersonaje.Elfo:
                    DateTime fechaNacElf = crearFechaNac(1961, 2001);
                    int edadElf = DateTime.Today.Year - fechaNacElf.Year;
                    var datosElf = new Datos(RazasPersonaje.Elfo, "Nombre Elf", "Apellido Elf", fechaNacElf, edadElf);
                    var caracteristicasElf = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeElf = new Personaje(datosElf, caracteristicasElf);
                    ListaPersonajes1.Add(personajeElf);
                    break;

                case RazasPersonaje.Enano:
                    DateTime fechaNacEnano = crearFechaNac(1961, 2001);
                    int edadEnano = DateTime.Today.Year - fechaNacEnano.Year;
                    var datosEnano = new Datos(RazasPersonaje.Enano, "Nombre Enano", "Apellido Enano", fechaNacEnano, edadEnano);
                    var caracteristicasEnano = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeEnano = new Personaje(datosEnano, caracteristicasEnano);
                    ListaPersonajes1.Add(personajeEnano);
                    break;

                case RazasPersonaje.Orco:
                    DateTime fechaNacOrco = crearFechaNac(1961, 2001);
                    int edadOrco = DateTime.Today.Year - fechaNacOrco.Year;
                    var datosOrco = new Datos(RazasPersonaje.Orco, "Nombre Orco", "Apellido Orco", fechaNacOrco, edadOrco);
                    var caracteristicasOrco = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeOrco = new Personaje(datosOrco, caracteristicasOrco);
                    ListaPersonajes1.Add(personajeOrco);
                    break;

                case RazasPersonaje.Goblin:
                    DateTime fechaNacGoblin = crearFechaNac(1961, 2001);
                    int edadGoblin = DateTime.Today.Year - fechaNacGoblin.Year;
                    var datosGoblin = new Datos(RazasPersonaje.Goblin, "Nombre Goblin", "Apellido Goblin", fechaNacGoblin, edadGoblin);
                    var caracteristicasGoblin = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeGoblin = new Personaje(datosGoblin, caracteristicasGoblin);
                    ListaPersonajes1.Add(personajeGoblin);
                    break;

                case RazasPersonaje.Centauro:
                    DateTime fechaNacCentauro = crearFechaNac(1961, 2001);
                    int edadCentauro = DateTime.Today.Year - fechaNacCentauro.Year;
                    var datosCentauro = new Datos(RazasPersonaje.Centauro, "Nombre Centauro", "Apellido Centauro", fechaNacCentauro, edadCentauro);
                    var caracteristicasCentauro = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeCentauro = new Personaje(datosCentauro, caracteristicasCentauro);
                    ListaPersonajes1.Add(personajeCentauro);
                    break;

                case RazasPersonaje.Minotauro:
                    DateTime fechaNacMinotauro = crearFechaNac(1961, 2001);
                    int edadMinotauro = DateTime.Today.Year - fechaNacMinotauro.Year;
                    var datosMinotauro = new Datos(RazasPersonaje.Minotauro, "Nombre Minotauro", "Apellido Minotauro", fechaNacMinotauro, edadMinotauro);
                    var caracteristicasMinotauro = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeMinotauro = new Personaje(datosMinotauro, caracteristicasMinotauro);
                    ListaPersonajes1.Add(personajeMinotauro);
                    break;

                case RazasPersonaje.Vampiro:
                    DateTime fechaNacVampiro = crearFechaNac(1961, 2001);
                    int edadVampiro = DateTime.Today.Year - fechaNacVampiro.Year;
                    var datosVampiro = new Datos(RazasPersonaje.Vampiro, "Nombre Vampiro", "Apellido Vampiro", fechaNacVampiro, edadVampiro);
                    var caracteristicasVampiro = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeVampiro = new Personaje(datosVampiro, caracteristicasVampiro);
                    ListaPersonajes1.Add(personajeVampiro);
                    break;

                case RazasPersonaje.Licántropo:
                    DateTime fechaNacLicantropo = crearFechaNac(1961, 2001);
                    int edadLicantropo = DateTime.Today.Year - fechaNacLicantropo.Year;
                    var datosLicantropo = new Datos(RazasPersonaje.Licántropo, "Nombre Licántropo", "Apellido Licántropo", fechaNacLicantropo, edadLicantropo);
                    var caracteristicasLicantropo = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeLicantropo = new Personaje(datosLicantropo, caracteristicasLicantropo);
                    ListaPersonajes1.Add(personajeLicantropo);
                    break;

                case RazasPersonaje.Troll:
                    DateTime fechaNacTroll = crearFechaNac(1961, 2001);
                    int edadTroll = DateTime.Today.Year - fechaNacTroll.Year;
                    var datosTroll = new Datos(RazasPersonaje.Troll, "Nombre Troll", "Apellido Troll", fechaNacTroll, edadTroll);
                    var caracteristicasTroll = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeTroll = new Personaje(datosTroll, caracteristicasTroll);
                    ListaPersonajes1.Add(personajeTroll);
                    break;

                case RazasPersonaje.Gólem:
                    DateTime fechaNacGolem = crearFechaNac(1961, 2001);
                    int edadGolem = DateTime.Today.Year - fechaNacGolem.Year;
                    var datosGolem = new Datos(RazasPersonaje.Gólem, "Nombre Gólem", "Apellido Gólem", fechaNacGolem, edadGolem);
                    var caracteristicasGolem = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeGolem = new Personaje(datosGolem, caracteristicasGolem);
                    ListaPersonajes1.Add(personajeGolem);
                    break;

                case RazasPersonaje.Harpía:
                    DateTime fechaNacHarpia = crearFechaNac(1961, 2001);
                    int edadHarpia = DateTime.Today.Year - fechaNacHarpia.Year;
                    var datosHarpia = new Datos(RazasPersonaje.Harpía, "Nombre Harpía", "Apellido Harpía", fechaNacHarpia, edadHarpia);
                    var caracteristicasHarpia = new Caracteristicas(1, 1, 1, 1, 1, 100);
                    var personajeHarpia = new Personaje(datosHarpia, caracteristicasHarpia);
                    ListaPersonajes1.Add(personajeHarpia);
                    break;
            }



            DateTime crearFechaNac(int anioMin, int AnioMax)
            {
                DateTime minDate = new DateTime(anioMin, 1, 1);
                DateTime maxDate = new DateTime(AnioMax, 12, 31);
                DateTime fechaNac = new DateTime(random.Next(minDate.Year, maxDate.Year), random.Next(1, 13), random.Next(1, 29 + 1));
                return fechaNac;
            }
        }
        public List<Personaje> ListaPersonajes1 { get => ListaPersonajes; }
    }
}