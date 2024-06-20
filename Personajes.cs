namespace espacioPersonajes
{
    public class Personaje
    {
        private Datos datosPersonaje = new Datos();
        private Caracteristicas caracteristicasPersonaje = new Caracteristicas();

        public Datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }
    }
    public class Datos
    {
        RazaPersonaje raza;
        string? nombre, apodo;
        DateTime fechaNac;
        int edad;//Max 300
    }
    public class Caracteristicas
    {
        int velocidad, destreza, fuerza, nivel, armadura, salud; // 1-10, 1-5, 1-10,1-10, 1-10, 100 respectivamente
    }

    public enum RazaPersonaje
    {
        Sanguinario, Humano, Necrofago, Legionario, Supermutante
    }
}