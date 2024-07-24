using EspacioPersonajes.PersonajesFiles;
using EspacioMenu;
using System.Text;
using EspacioArteAscii.GUI;

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
        public void MejorarAtributos()
        {
            Console.Clear();
            this.nivel = Math.Min(this.nivel + 1, 10);

            var ascii = new ArteAscii();
            string[] GraficoAscii = new string[] { };
            string[] atributos = { "Velocidad", "Agilidad", "Fuerza", "Defensa", "Salud +25", "Suerte" };
            string titulo = "¿Qué atributo desea mejorar?";

            // Verificar si todos los atributos (excepto salud) están maximizados
            bool todosMaximizados = velocidad >= 10 && agilidad >= 10 && fuerza >= 10 && defensa >= 10 && suerte >= 10;
            bool bandera;
            int opcion;

            MenuGrafico menuAtributos = new MenuGrafico(GraficoAscii, titulo, atributos);

            for (int i = 0; i < atributos.Length; i++)
            {
                if ((atributos[i] == "Velocidad" && this.velocidad >= 10) ||
                    (atributos[i] == "Agilidad" && this.agilidad >= 10) ||
                    (atributos[i] == "Fuerza" && this.fuerza >= 10) ||
                    (atributos[i] == "Defensa" && this.defensa >= 10) ||
                    (atributos[i] == "Suerte" && this.suerte >= 10))
                {
                    atributos[i] = atributos[i] + " (Maximizado)";
                }
            }

            if (todosMaximizados)
            {
                ascii.EscribirCentrado("¡Todos los atributos ya están mejorados al máximo! Añadiendo salud por default");
                this.salud += 25;
                Thread.Sleep(5000);
                return; // Salir de la función si no hay nada más que mejorar
            }

            do
            {
                // Ejecutar el menú y obtener la opción seleccionada
                opcion = menuAtributos.Run();
                bandera = false;//Marca la salida del programa
                // Incrementar el atributo seleccionado
                switch (atributos[opcion])
                {
                    case "Velocidad":
                        if (this.velocidad < 10)
                        {
                            // Incrementar velocidad hasta un máximo de 10
                            this.velocidad = Math.Min(this.velocidad + 3, 10);
                            ascii.EscribirCentrado($"¡Has mejorado tu {atributos[opcion]} en 3 puntos!");
                            bandera = true;
                        }
                        else
                        {
                            ascii.EscribirCentrado("No puedes mejorar más la velocidad.");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "Agilidad":
                        if (this.agilidad < 10)
                        {
                            // Incrementar agilidad hasta un máximo de 10
                            this.agilidad = Math.Min(this.agilidad + 3, 10);
                            ascii.EscribirCentrado($"¡Has mejorado tu {atributos[opcion]} en 3 puntos!");
                            bandera = true;
                        }
                        else
                        {
                            ascii.EscribirCentrado("No puedes mejorar más la agilidad.");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "Fuerza":
                        if (this.fuerza < 10)
                        {
                            // Incrementar fuerza hasta un máximo de 10
                            this.fuerza = Math.Min(this.fuerza + 3, 10);
                            ascii.EscribirCentrado($"¡Has mejorado tu {atributos[opcion]} en 3 puntos!");
                            bandera = true;
                        }
                        else
                        {
                            ascii.EscribirCentrado("No puedes mejorar más la fuerza.");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "Defensa":
                        if (this.defensa < 10)
                        {
                            // Incrementar defensa hasta un máximo de 10
                            this.defensa = Math.Min(this.defensa + 3, 10);
                            ascii.EscribirCentrado($"¡Has mejorado tu {atributos[opcion]} en 3 puntos!");
                            bandera = true;
                        }
                        else
                        {
                            ascii.EscribirCentrado("No puedes mejorar más la defensa.");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "Salud +25"://Acomodar nombre para que se ajuste con la opcion
                        // Incrementar salud sin límite
                        this.salud += 25;
                        bandera = true;
                        break;
                    case "Suerte":
                        if (this.suerte < 10)
                        {
                            // Incrementar suerte hasta un máximo de 10
                            this.suerte = Math.Min(this.suerte + 3, 10);
                            ascii.EscribirCentrado($"¡Has mejorado tu {atributos[opcion]} en 3 puntos!");
                            bandera = true;
                        }
                        else
                        {
                            ascii.EscribirCentrado("No puedes mejorar más la Suerte.");
                            Thread.Sleep(3000);
                        }
                        break;
                }
                // Verificar si todos los atributos (excepto salud) están maximizados después de la mejora
                todosMaximizados = velocidad >= 10 && agilidad >= 10 && fuerza >= 10 && defensa >= 10 && suerte >= 10;

                if (todosMaximizados)
                {
                    ascii.EscribirCentrado("¡Todos los atributos ahora están mejorados al máximo!");
                }
            } while (bandera == false);
        }
    }
}