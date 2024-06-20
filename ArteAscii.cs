namespace EspacioArteAscii
{
  public class ArteAscii()
  {
    public void MostrarLogo()
    {
      Console.WriteLine("\tBienvenidos al juego");
      string hechicero = @"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░▒███░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓▓▓▓▓▓▓░░█▓▓██░░▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒░█▓▓▓███░░▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░█▓▓▓▓████▒░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░▒██▓▓▓▓█████▓░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░▓██▓▓▓▓████████░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░▒███▓▓▓▓█████████░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░███▓▓▓▓██████████▓░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░
░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░▒███▓▓▓▓▓▓▓██████████░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░
░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓██▓▓▓▓▓▓▓▓▓▓▓▓▓███████▓░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░
░░░░░▒░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓███▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓████▓░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒░░░░░
░░░░▒▒░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░▒▓██▓▓▓████▓▒▒▒▒▒▒▒▒▒▓█████▓▓▓███▒░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░▒░░░░
░░░░▒░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░▒▓▓▓▓█████▓▒▓▒▒▒▒▓▓▓▒▒▒▒▓█▒██████▓▓▓▓▓░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░▒▒░░░
░░░▓░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░▒▓▓███████▓░▓██▓▓▓▓█▓▓▓▓███▒░████████▓▓▒░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓░░░
░░▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▓▓███████░░██▒▒▓▓█▒▓▓▓▓▒▓█▒░▒███████▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓░░
░▒▓░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░▒▓██████▒░▒▓██▒▓█▓▒▓▓█▒▓██▒░░▓██████▓▒░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░▒▒░
░▓▒░░▒▓▓▓▒▒▓▓▓▒▒░▒▒▓▓▓▓▓░░▓██▓█████░▓▓░██▓▓▒▓█▓▒▓▓▓██░▓▒▒█████▓███▓▓▒░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓░
░▓░░░▓▓▒░▒▒▒░░░██▓░░▓▓▓░▒██████████▒█▓▒█▒░░▒▓██▒░░░▓█░▒█▒█████████████▓░░▒▓▓▓▓▓▓▓▓▓▓▒░░░▓░
▒▒░░░▓▓░▓█▓▓█▒▒█▒▓█▒░▒░░██▓▓▓▓███████▒█░░░▓▒▒▒▒▒▒▓░░▒█░▓████████████████▓░▒▓▓▓▓▓▓▓▓▓▓░░░▒▒
▒▒░░▒▓▓░░█▓▒▒█▓█▓▒▒██▓▓█████████████▓▒░░▒▒░░░░░░░░▒▒░▒▓░▓████████████████▒░▒▒▓▓▓▓▓▓▓▓░░░▒▒
▓▒░░░▒░░░░▓█▓▒▒▓██▒▒▓████████▓██████▒▒░▒▒░░░░░░▒░░░▒▒░▓▓░█████▓▓███████████▓▒░░▒▓▓▓▓▓░░░▒▓
▓▒░░████▓▒░▓█▓▒▒▒▓█▓▒▓██▓▓▓█████████░░░▓░░░░░░░▒░░░░▓░▒█░▓███▓██▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒░▒▓▓▓░░░▒▓
▓▒░░█▓▒▒▒▓▓█████▓▒▒▓▓▒▒███▓▓▓███████▒░▒▒░░░░░░▒▒▒░░░▓▓░█▓▓██▓█▓▓▓▓▓▓▓▓████████▓▓▓▒░▒▓░░░▒▓
▓▒░░░▓██▓▓▒▒▒▒▓██▓▒▒▓▓▒▒▓███▓████████░▒▒░░░░░▒▒▒▒░░░▓▒░█▓▓██▓▓▓▓▓███████▓▓▓████████▒░░░░▒▓
▒▓░░░▒▓██████▓▒▒▒▓▓▓▒▒▒▒▒▓███████████▓░▓░░░░░▒▒▒▒░░▒▒░▓█▓██▓▓▓███████▓▓▓▓█▓▓▓▓▓▓▓▓▓██▒░░▓▒
░░░░▓█▓▓████████▓▒▒▒▒▒▒▒▒▒▒███████████▓▒▒░░░░░▒▒░░░▓░▓███▓▓▓███████▓▓▓▓▓▓██████████▓▓██░░▒
░░░█▓▓█████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▒▒▒▒▒▓███▒▓▒░░░░░░░░▒▒▒███▓▓███████▓▓▓▓▓████▓▓▓████████▓▓█░░
░░▓█▓████▓▒▓▓▓▓█▓▒▒▒▒▒▒▒▓▒▒▒▒▒▓██▓██████░█▒░░░░░▒▒▓▒███▓▓███████▓▓▓▓██▓▓▓▓▓▓▓▓▓███████▓█▓░
░░█▓████▓▓███▓▓███▓▒▒▒▒▒▓█▓▓██████▓▓████▒▓█▒░▒▒▓▓▒▒▒▒▒▒▒▒▒▓▓████▓▓██▓▓▓▓▓▓▓▓▓▓█████████▓█░
░▒█▓███████▓▓▓▓▓████▓▓▓▓███████████▓▓████▒██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓███▓▓▓▓▓▓▓▓▓▓▓▓█▓████████▓▓░
░▓▓███████▓▓▓▓▓▓▓██████████▓████████▓▓███▓█▓▒▒▒▒▓▓▓▒▒▒▓▓▓▓▓▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓████████▓░
░▓▓████████▓▓▓▓▓▓▓▓▓████▓▓▓▓████████▓▓▓███▓▒▒▒▓▓▓▓▒▒▒▒░▒▒▓▓▓▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████▓░
░▒▓█████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████▓▓▓██▓▒░▒▓▓▓▒▒▒▒▒░▒▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████▓░
░░▓█████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████▓▓▓▓▓▒▒▒▓▓▒▒▒▒▒▒▒▒░▒▒▒▓▒▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓██████████▓░
░░▒██████████▓▓▓▓▓▓▓▓▓▓▓▓█████████████▓▓▓▓▓▒▒█▓▒▒▒▒▒▒▒▒░▒▒▓▓▓▓▒▓▓██▓▓▓▓▓▓▓▓▓▓██████████▓▓░
░░░▓████████████████████▓▒▓███████████▓▓▓▓▓▒▒▓█▒▒▒▓▒▒▒▒▒█▒▒▒▒▒▒▒▒███▓▓▓▓▓▓▓████████████▓▒░
░░░░▓███████████████▒▒░░░░████████████▓▓▓▓█▓▒▒▒▓▒▒▒▓▓▓▓▓▓▓▓██▒▒▒▓███▓▓████████████████▓▓░░
░░░░▒▓█████████████░░▓▓▒░█████████████▓▓▓▓█▓▓▒█▓▓▓█▓▓▒▓▓▓▓▓▓▒▒▒▓████▓▒░░█████████████▓▓░░░
░░░░░▒▓██████████▓░░▒▓▒░▓█████████████▓▓▓▓█▓▓▓▓▓▓█▓▓▓█▓▓▓▓▓▓▒▒██████░░▒░░▓█████████▓▓▒░░░░
░░░░░░░▓███████▓░░░▓▓▒░▓█████████████▓▓▓▓▓█▓▓▓▓▓█▓▓█▓▓▓▓███▓▓████████░░▓▒░▒▓▓████▓▒▒░░░░░░
░░░░░░░░░▒▓▓▓▒░░░▒▓▓▒░▓██████████████▓▓▓▓▓█▓▓█▓▓▓▓▓▓▓▓▓███████████████░░▓▓▒░░░▒░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░▒░░███████████████▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓███████████████░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░▒███████████████▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓█████████████▓░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░▒▓██████████▓▓▓▓▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▓█████████▓▒░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓█████▓▓▓▓▓▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▓▓█████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓█████▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
";
      Console.WriteLine($"\t{hechicero}");
    }
  }
}