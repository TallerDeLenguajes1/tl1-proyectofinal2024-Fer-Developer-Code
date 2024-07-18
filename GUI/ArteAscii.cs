namespace EspacioArteAscii.GUI
{
  public class ArteAscii
  {
    ConsoleColor colorOriginalTexto = Console.ForegroundColor;
    ConsoleColor colorOriginalFondo = Console.BackgroundColor;
    public void ColorOriginal()
    {
      Console.ForegroundColor = colorOriginalTexto;
      Console.BackgroundColor = colorOriginalFondo;
    }
    public void limpiar()
    {
      Console.Clear();
    }
    public void CambiarColorTexto(string color)
    {
      switch (color.ToLower())
      {
        case "azul":
          Console.BackgroundColor = ConsoleColor.Blue;
          break;
        case "rojo":
          Console.BackgroundColor = ConsoleColor.Red;
          break;
        case "amarillo":
          Console.BackgroundColor = ConsoleColor.Yellow;
          break;
        case "verde":
          Console.BackgroundColor = ConsoleColor.Green;
          break;
        case "magenta":
          Console.BackgroundColor = ConsoleColor.Magenta;
          break;
        case "cyan":
          Console.BackgroundColor = ConsoleColor.Cyan;
          break;
        case "gris":
          Console.BackgroundColor = ConsoleColor.Gray;
          break;
        case "negro":
          Console.BackgroundColor = ConsoleColor.Black;
          break;
        default:
          Console.WriteLine("Color inválido.");
          break;
      }
    }
    public void CambiarColorFondo(string color)
    {
      switch (color.ToLower())
      {
        case "azul":
          Console.ForegroundColor = ConsoleColor.Blue;
          break;
        case "rojo":
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case "amarillo":
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case "verde":
          Console.ForegroundColor = ConsoleColor.Green;
          break;
        case "magenta":
          Console.ForegroundColor = ConsoleColor.Magenta;
          break;
        case "cyan":
          Console.ForegroundColor = ConsoleColor.Cyan;
          break;
        case "gris":
          Console.ForegroundColor = ConsoleColor.Gray;
          break;
        case "negro":
          Console.ForegroundColor = ConsoleColor.Black;
          break;
        default:
          Console.WriteLine("Color inválido.");
          break;
      }
    }
    public void EscribirConAnimacion(string texto, int delay)
    {
      foreach (char letra in texto)
      {
        Console.Write(letra);
        Thread.Sleep(delay); // Pausa entre cada letra
      }
      Console.WriteLine(); // Para asegurar que la próxima línea empiece en una nueva línea
    }
    public void MostrarLogo()

    {
      string asciiBienvenida = @"
 ______      _                                                  _          __                              __          _                                      
|_   _ \    (_)                                                (_)        |  ]                            [  |        (_)                                     
  | |_) |   __    .---.   _ .--.    _   __   .---.   _ .--.    __     .--.| |    .--.    .--.      ,--.    | |        __   __   _    .---.    .--./)   .--.   
  |  __'.  [  |  / /__\\ [ `.-. |  [ \ [  ] / /__\\ [ `.-. |  [  |  / /'`\' |  / .'`\ \ ( (`\]    `'_\ :   | |       [  | [  | | |  / /__\\  / /'`\; / .'`\ \ 
 _| |__) |  | |  | \__.,  | | | |   \ \/ /  | \__.,  | | | |   | |  | \__/  |  | \__. |  `'.'.    // | |,  | |     _  | |  | \_/ |, | \__.,  \ \._// | \__. | 
|_______/  [___]  '.__.' [___||__]   \__/    '.__.' [___||__] [___]  '.__.;__]  '.__.'  [\__) )   \'-;__/ [___]   [ \_| |  '.__.'_/  '.__.'  .',__`   '.__.'  
                                                                                                                   \____/                   ( ( __))          
                                                                                                                   ";
      string banner = @"*************************************************************************************************************************************************************";
      CambiarColorFondo("magenta");
      EscribirConAnimacion(banner, 1);
      Console.WriteLine(asciiBienvenida);
      EscribirConAnimacion(banner, 1);
      string asciiHechicero = @"
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒███░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▓▓▓▒░░███▓██▒░░▒▓▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓██▓▓███▒░░▓▓▓▓▓▓▓▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▒██▓▓▓████▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▒██▓▓▓▓█████▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▒██▓▓▓▓▓██████▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▒██▓▓▓▓▓▓███████▓░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓██▓▓▓▓▓▓▓█████████░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░███▓▓▓▓▓▓▓▓██████████▓░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▒████▓▓▓▓▓▓▓████████████▓░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒████▓▓▓▓██████████████████░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒█████▓███▓▓▓▓███████████████░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░██████▓▓▓▓▓▓▓████████████████▓░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓████▓▓▓▓▓█████████████████████░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░▓████▓▓▓▓▓▓▓▓▓▓▓█████████████████▒░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░▒░░░░░░░░░░░░░░
░░░░░░░░░░░░░▒░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░█████▓▓▓▓▓▓▓▓▓▓▓▓▓██████████████████▒░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░▒░░░░░░░░░░░░░
░░░░░░░░░░░░▒░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░▒░░░░░░░░░░░░
░░░░░░░░░░░▓░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▒█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▓▓▓▓▓▓▓█████████████▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░▒▒░░░░░░░░░░
░░░░░░░░░▒▓░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓█████▓▓▓▓▓▓▓▓▓▓████▓▓▒▒▒▓▓▓████▓▓▓▓▓▓▓█████████▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░▒▒░░░░░░░░░
░░░░░░░░▒▓░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓█████▓▓▓▓▓▓█████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████▓▓▓▓▓▓▓██████▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░▓▒░░░░░░░░
░░░░░░░░▓░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▒▓███▓▓▓▓▓█████████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓████████▓▓▓▓▓▓████▓▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░▓▒░░░░░░░
░░░░░░░▓▒░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓██▓▓▓▓▓█████████▓▒█▓▒▒▓▓█▓▓▓▓▒▒▒▓▓▓▓▓▒▒▓██▒▓█████████▓▓▓▓▓███▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░▓▒░░░░░░
░░░░░░▓▒░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓█▓▓▓▓████████████▒░▓▓▓▓▓▒░░░▒▒███▒▒░░░▒▓▓▓▓█▓░▓████████████▓▓▓▓██░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▓░░░░░░
░░░░░▓▓░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒█▓▓▓█████████████▒░▒▓████▓▓█▓▓▓█▓█▓▓▓██▓█████▓▒░▒██████████████▓▓█▓░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▓▓░░░░░
░░░░▒▓▒░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░█▓▓█████████████▒░░░███▓▓█▓▒▓██▓▓▓██▓▒▓█▓▓███▓░░░▓█████████████▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▓▒░░░░
░░░░▓▓░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░▓▓▓█████████████░░░▒██▓▒▒▒▒▒▒▓█▒▒▒█▓▒▓▓█▓▒▒███░░░░█████████████▓▓█░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▓▒░░░
░░░▓▓░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░█▓▓███████████▒░░░█▓██▓▒▒▒▓██▓▒▒▓█▓██▒▒▒▓███▓▓░░░▒████████████▓▓▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▓▓░░░
░░░▓▒░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░▓▓███████████░░░▓▒▒███▓▒▓██▓▓▒▒▓▒▓█▓█▒▒████░▓▓░░░███████████▓▓▒░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░▒▓▒░░
░░▓▓░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓░░░▒▓███▓█████████▓░░▓█░░███▒▓▓█▓▓█████▓▓▓█▓▓▓███░░▓▓░░▓█████████▓█████▓▓▒░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▓▓░░
░░▓▓░░░░░▓▓▓▓▓▒▒░░░░▒▒▓▓░░░░░░░░▒▓▓▓▓▓▓▓▒░░▒███████▓████████░░███░▒████▓▒░░░░▒██░░░░░▒▓████░░░██░▒████████▓███████████▓▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▓▒░
░▒▓▒░░░░▒▓▓▓▓░░░▒▒▒▒░░░░░▒█████░░░▒▓▓▓▓▒░░▓█████████████████░███▓░▓██▒░░░░░░▒████▒░░░░░░▓██▓░░▓█▓▒███████▓████████████████▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░▒▓▒░
░▓▓░░░░░▒▓▓▓░░░██████▒░░░███▓▓██▒░░▒▓▓▓░░▒█████▓▓▓██████████▒███▒▒██░░░░░▒▓██▓▓▓▓██▓▒░░░░░▓█▒░░██▓██████████████████████████░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░▓▓░
░▓▓░░░░░▓▓▓▓░░▒██▓▒▓███░░▒█▓▒▒▒██▓░░▒▒░░░████▓▓▓▓▓▓█████████████░█▓░░░░░▓█▒░▒▒▒▒▒░░░▓█▒░░░░▓█░░▒█████████████████████████████▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▓▓░
▒▓▓░░░░░▓▓▓▓▒░░██▓▒▒▒▓██▓▒▓█▒▒▒▒███▒░░▒▓████▓▓█████████████████▒░█░░░░▒▓▒░░░░░░░░░░░░░▓█░░░░██░░▒█████████████████████████████░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▓▒
▒▓▒░░░░░▒▓▓▓▓░░▒██▓▒▒▒▒▓█████▓▒▒▒▓██████████████▓▓█████████████░▒▒░░░▒▒░░░░░░░░░░░░░░░░▒█▒░░▒██░░▓███████████▓▓▓▓█████████████▓░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▓▒
▓▓▒░░░░░░░░░░▒░░▒██▓▓▒▒▒▒▓████▓▒▒▒▓███████████████▓▓██████████▒░▒░░░▒▒░░░░░░░░░░░▒░░░░░░░█░░░▓█▓░░█████████▓▓▓███████████████████▓▒░░░░▒▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▓▓
▓▓▒░░░░▒██▓▒░░░░░░▒██▓▒▒▒▒▒▒▓███▒▒▒▒████▓▓▓▓▓██████▓▓█████████▒░▒░░▒▓░░░░░░░░░░░░▒▒░░░░░░▒▓░░▓▒█▒░▓███████▓▓▓█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████▓░░░▒▓▓▓▓▓▓▓▓▒░░░░░▒▓▓
▓▓▒░░░▒███████▓▒▒░░░███▓▒▒▒▒▒▒▓██▓▓▒▒▓███▓▓▓▓▓▓█████▓█████████▒░░░░█░░░░░░░░░░░░░▒▒░░░░░░░▓▒░▓░██░▒██████▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▒░░░▒▓▓▓▓▓▒░░░░░▒▓▓
▓▓▒░░░▓██▒▒▒▒▓▓█████▓████▓▓▒▒▒▒▒██▓▒▒▒▒████▓▓▓▓▓▓█████████████▒░░░▒█░░░░░░░░░░░░▒▒▒░░░░░░░▓▓▒▒░██▒░█████▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▒░░░▓▓▓▓▒░░░░░▒▓▓
▓▓▓░░░░███▒▒▒▒▒▒▒▒▓▓▓███████▒▒▒▒▒▓█▓▒▒▒▒▓█████▓▓▓██████████████░░░▒▓░░░░░░░░░░░▒▒▒▒░░░░░░░▒█▓░░██▒░█████▓██▓▓▓▓▓▓▓▓▓▓▓▓█████████████████▓▓▓▓▒░░░▒▓░░░░░░▒▓▓
▒▓▓░░░░░▓███▓▓▓▒▒▒▒▒▒▒▒▒▓████▓▒▒▒▒▓█▓▒▒▒▒▓██████▓▓█████████████▒░░▒█░░░░░░░░░░▒▒▒▒▒░░░░░░░▓█░░░██▓░████▓█▓▓▓▓▓▓▓▓▓█████████████▓▓▓▓███████████▓░░░░░░░░░▒▓▓
▒▓▓░░░░░░░▒▓████▓▓▒▒▒▒▓▒▒▒▒▓██▓▒▒▒▒▒██▓▒▒▒▒█████████████████████░░░█░░░░░░░░░░▒▒▒▒▒░░░░░░▒█▒░░▓██▒▒███▓▓▓▓▓▓▓▓████████████▓▓▓▓▓▓█████████████████▒░░░░░░▓▓▒
░▓▓░░░░░░░▒▓██████████▓▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒▒▒▒▒████████████████████▓░░█▒░░░░░░░░░▒▒▒▒▒░░░░░░▓▒░░▒███▒███▓▓▓▓▓▓▓███████████▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓█████▓░░░░░▓▓▒
░▓▓░░░░░▒███▓▓███████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓███████████████████▓░▒█░░░░░░░░░░▒▒▒▒░░░░░▒▓░░░████▓██▓▓▓▓▓███████████▓▓▓▓▓▓▓▓▓▓▓▓▓████████████▓▓▓▓███▒░░░▓▓░
░▒░░░░░███▓▓▓▓██████████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███████████████████▓░▓▓░░░░░░░░░▒▒▒░░░░░▒█░░░███████▓▓▓▓████████████▓▓▓▓▓▓▓▓▓████████████████████▓▓▓██▓░░░▓░
░░░░░░██▓▓▓▓████████▓▓▓▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▒▒▒▒▒▒██████▒░█▒░░░░░░░░░▒▒░░░░░▓▓░░▓█████▓▓▓▓▓███████████▓▓▓▓▓▓▓▓▓████████████████████████▓▓██▓░░░░
░░░░░▓█▓▓▓████████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒███████░▒█▓░░░░░░░░░░░░░░░▓░░▓█████▓▓▓▓████████████▓▓▓▓▓▓▓███████▓▓▓▓▓▓▓▓█████████████▓▓██▓░░░
░░░░▒██▓▓███████▓▒▒▒▒▓█▓▓▓██▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▓▓█████████████▓░▓█▓░░░░░░░░░░▒░░▒▓░▒█████▓▓▓▓████████████▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████▓▓██▒░░
░░░░██▓▓█████▓▓▒▒▒▓█████▓████▓▒▒▒▒▒▒▒▒▒▒▒▒█▓▒▒▒▒▒▒▓▓█████▓▓▓█████████░▒██▓░░░▒░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████▓▓▓▓▓███▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▓█████████████▓▓██░░
░░░▓█▓▓██████▓▓▓▓███▓█▓▓▓▓█████▓▒▒▒▒▒▒▒▒▒▒▓██▓▓▓▓█████████▓▓▓▓███████▓░▓██▓░░░▒▒▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓███████▓▓▓▓███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████████▓▓▓█░░
░░░██▓▓████████████▓▓█▓▓▓▓███████▓▒▒▒▒▒▒▒▒█████████████████▓▓▓▓███████░▓███▓░▓▓▓▓▒▒▒▒▒▒▒▒▒░▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓███▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓███████████████▓▓█▒░
░░░██▓████████▓███▓▓▓█▓▓▓▓▓▓████████▓▓▓▓▓████████▓██████████▓▓▓▓██████▒▓████▓▓▓▒▒▒▒▒▒▒▒▓▒▒▒▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓██▓███▓██████████▓▓█▒░
░░▒█▓▓████████▓██▓▓▓▓█▓▓▓▓▓▓▓██████████████████▓▓████████████▓▓▓▓█████▓████▓▓▒▒▒▒░▒▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓██▓██▓███████████▓▓▓░
░░▒█▓▓███████████▓█▓▓█▓▓▓▓▓▓▓▓█▓█████████████▓▓▓▓█████████████▓▓▓▓████████▓▓▒▒▒░▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓█▓███████████▓▓▓░
░░▒█▓████████████▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▓▓▓▓▓██████████████▓▓▓▓▓██████▓▓▒▒▒░▒▓▓▓▓▓▓▓▒▒▒▒▒▒░░▒▒▒▓▓▓▓▓▓▓▒▒▒▒▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓█████████████▓▓▓░
░░▒█▓██████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████▓▓▓▓▓████▓▓▒▒▒░▒▓▓▓▓▓▓▓▒▒▒▒░░░▒░░░▒▒▒▒▓▓▓▓▓▒▒▒▒▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████▓▓▓░
░░░█▓███████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████████▓▓▓▓▓███▓▒▒▒░░▒▓▓▓▓▓▓▒▒▒▒▒▒▒░░░▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████▓▓▒░
░░░█▓█████████████▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████████████▓▓▓▓▓▓██▓▒▒▒░▒█▓▓▓▒▓▒▒▒▒▒▒▒▒▒▒░░▒▒▒░▒▓▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████▓▓▒░
░░░▒▓▓█████████████▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████████████▓▓▓▓▓▓██▓▒▒▒░▓█▓▓▓▒▓▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▓▓▒▒▓▓▓▒▒▒▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████████▓▓░░
░░░░█▓███████████████▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████████████████▓▓▓▓▓▓█▓▒▒▒▒██▓▓▒▒▓▓▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▓███▓▓▓▓▓█████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████▓▓▓░░
░░░░▒▓████████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓███████████████████▓▓▓▓▓▓█▓▒▒▒░▓█▓▓░░▒▓▓▒▒▒▒▒▒▒▒▒░▒▓▓██▓▒▒▒▒▒▒▒▒▒▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████████████▓▓▒░░
░░░░░▓▓████████████████████████████████████▓░▒███████████████████▓▒▓▓▓▓▓▓▓▒▒▒▒█▓█▒░░▒▓▓▓▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████████▓▓█░░░
░░░░░░▓▓██████████████████████████████▓▓▒░░░░████████████████████▓▒▓▓▓▓▓█▓▓▒▒▒▒▓█▓▒░░▒▒▒▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▒▒▒▒▒▓██▓██▓▓▓▓▓▓▓▓████████████████████████▓▓▒░░░
░░░░░░░▓██████████████████████████▓░░░░░░░░░▓████████████████████▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▓▓▓▒▒░▒▓████▓▓▓▓▓▓▓▓██▓▓▒▒▒▒▒▒██████▓▓▓▓███████████████████████████▓▓▓░░░░
░░░░░░░▒▓████████████████████████▒░░░▒▒▓▒░░▒█████████████████████▓▓▓▓▓▓▓▓██▓▓▒▒▒██▓▓▓███▓▒▒▒▒▓██▓▓████▓▓▒▓▒▒▒▓███████▓▓█▓▒░▒███████████████████████▓▓▓░░░░░
░░░░░░░░▒▓▓█████████████████████▒░░░▓▓▓▓░░░██████████████████████▓▓▓▓▓▓▓▓██▓▓▓▓▓█▓▓▓▒▒▓███▓▓▒▒▓▓▒▒▓▓▓▒▒▒▒▒▒▒▓████████▓▒░░░░░▒████████████████████▓▓▓▓░░░░░░
░░░░░░░░░▒█▓▓█████████████████▓░░░░▓▓▓▓░░░███████████████████████▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓██▒▒▒▓▓███▓▓▒▒▒▒▒▒▒▒▒▒▒██████████░░░▒▓▒░░▒▓▓████████████████▓▓█▒░░░░░░░
░░░░░░░░░░░██▓▓█████████████▓▒░░░░▓▓▓▓░░░████████████████████████▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓███▓▒▒▒▓▓███████▓▓▒▒███████████▓░░░▒▓▒░░░▓▓▓███████████▓▓▓▓▓░░░░░░░░░
░░░░░░░░░░░░▒███▓▓▓▓▓▓▓▓▓▓▓▒░░░░▒▓▓▓▓░░░████████████████████████▓▓▓▓▓▓▓▓▓█▓▓▓▓█▓▓▓▓██▓▓▓███▓▒▒▒▒▓▓▓▓▓▓▓▓██████████████▓░░░▒▓▓░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░░░░░░░
░░░░░░░░░░░░░░▒█████████▓▒░░░░▒▓▓▓▓▓░░░█████████████████████████▓▓▓▓▓▓▓▓▓█▓▓▓▓█▓▓▓▓██▓▓▓▓▓▓▓███████████████████████████▓░░░▒▓▓▒░░░░▒▓▓▓▓▓▓▓▒░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░▒▓▓▓▓▒░░▒█████████████████████████▓▓▓▓▓▓▓▓▓█▓▓▓▓██▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓█████████████████████████▓░░░▒▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▒░░▒██████████████████████████▓▓▓▓▓▓▓▓▓█▓▓▓▓██▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓██████████████████████████░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓██████████████████████████▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓███████████████████████████▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█████████████████████████▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓███▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓████████████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓██████████████████████▓▓▓▓▓▓▓▓▓█▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓█████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓█████████████▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████████▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒█████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓███▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▓▓▓▓▓█████████▓▓▓▓▓▓▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
";
      string asciiPalabraAventura = @" 
                           _______                _                                _                                                                   
                          (_______)              (_)                              | |                                         _                        
                          _         ___   ____   _  _____  ____   _____  _____    | |  _____    _____  _   _  _____  ____   _| |_  _   _   ____  _____ 
                          | |       / _ \ |    \ | || ___ ||  _ \ (___  )(____ |  | | (____ |  (____ || | | || ___ ||  _ \ (_   _)| | | | / ___)(____ |
                          | |_____ | |_| || | | || || ____|| | | | / __/ / ___ |  | | / ___ |  / ___ | \ V / | ____|| | | |  | |_ | |_| || |    / ___ |
                           \______) \___/ |_|_|_||_||_____)|_| |_|(_____)\_____|   \_)\_____|  \_____|  \_/  |_____)|_| |_|   \__)|____/ |_|    \_____|                                                                                                                          
";
      Console.WriteLine($"\t{asciiHechicero}");
      ColorOriginal();
      EscribirConAnimacion(asciiPalabraAventura, 1);
      EscribirConAnimacion(banner, 1);
    }
    public void MostrarTrono()
    {
      string asciiTrono = @"                                                                                                        
                                                                                                  
                                            .:                                                    
                                   .#.      #@.      *@       :.                                  
                                   -@@.    .@@@     -@@=     =@%                                  
                           +#.     =@@#     @@@:    #@@=    .@@@                                  
                           *@@-    .@@@:    @@@=    @@@=    +@@#      =@@                         
                           -@@@.    #@@+    @@@#   .@@@:    %@@=     =@@%                         
                   =#-      +@@+    :%@@    *@@%   -@@@:   :@@@.    .@@@:     .                   
                   -@@%.    .-+#:    *@@-   +@@@   =@@@    +@@%     %@@=    .*@.                  
                    *@@%.    :#*#    ##@+   -@@% . +@%%    %@@-    =@%%    =@%%                   
             -:      *#%%    .@*@+   -+*@:   %#@+@##@#%+%..@%@    .@##:   +@%..                   
             =%@+.    -+#%.   =@+#.   ++*#=%=#*@@@@@#+@@@%*@@+ +. #@--   =@#.    -#@.             
              +@@@-     .#%. : +#**.@**#+#%@#*-%@@@@#%@@@@#@@*@@==@-+ . -@* .  .#@@%              
               +@@@+    ..=#-@*:*-#%@@@#++#@@#.%@@@@=%@@@:#@@@@@+%* -#@:@# .  :@@@#               
                =%@@%.:--+ -@@@@*==%@@@*=:#@@+-%@@#%+@@@@=@+@@@@*= #@%%@% =*:-@@@#                
                 :%@@@=**@*:%@@@@#:*@@@@+-@@@**@@#%#=%@@*+@%@@@@* +@@@@@-%@@#@@@*                 
           -=-.   :%@@@%-+%@#%@#%@*-%@%@@#%%#%*@@%@@#@@#+#%@@@@@%*@@%%@*@@%@@%*+-+ :*#+           
            *#%%+:%@@@@@#..%@%#**@%@@@%@@##@*%+@%@@+##@=%@%@%%%+@@@%%@@@@@@@%%@@@@%@#*            
             =##*@@@@@@@%%- *%%#*#@%@@#*@%%@+*-#%%@#@@%==@@%%@@@@@@*%@@@@@@@@@@%@@%*:             
               -*%%@@@@@@%@@::#%#%#%*@+#@@#@%--@+%@@@**++@@@@@%@@@%#@@@@%@@@@##@@%=               
              .=--#@@@%%%%@%#::%@%%*+%@%*@@@@#*+=@@@@#*%*+@%@@%@@@%%@@@#@@@#*%@@@=                
               *@@@%@+%*##%%@%#**+*+*@@%+@@*##**#@@@%%**@##@@%%@@%@@#%*@@%*%@@@*#%%+              
                -%@@@@*#+*%%%*#%#=---#@#==@* .-#*%@@##*+##@@@@@@%%@@%=-=*%@@@%#%%#*               
                  -%@@@%@*-+%%+#+.-= :%@*-@#  . =#@%#+::%-:+-*@%%%@*  :*@@@%*%%%*:                
                    :*@@%@@=+@++%%#%+-+@@++%=.-:-%@@#+-+-::++#@%%#+:. =%%#%++**. :                
                 .#++=-+%%%--*+*##@%%%#*%%%#*##*+%@@@%#%#%#%##**%%@*=-*%#**#%##%@%                
                  -@@@%#%%#@@: -%#@@@%@@@@*==@##%@@%#%%%%#%##%%@%@%=+=#+:=@%%@@@#                 
                   .#@@@#%#@%%*-:%@@@@@@@@@*=@%@@#*=..%@%++++##@@@##+-=%%+%@#@@=                  
                 %*-.-@@@@%#%+#*%#%%%#*@@@@@*#*%@*=. .@%::-:+@@@@%==+#@@@%%+%#:=                  
                 .%@%*+@@@@@#*@@#%#%@=.=@@@%@@@##**:+=@@##%#@@@@##*@@@@#%@%#*%#*                  
                   =@@%@@@@@@#*%@%*#*@@%@@@@@#%%@*@+:+##@@@@@%*@%#%#%%%@@@%%@@*                   
                     *@@@@@@@@@%#@#*+%@@@@@@%*:%@+%. *%*=#%@@@##%@%#@@@%%%@@@=                    
                      :%@@@@@%@@@%: .#@@#%%%%@#+@##=#@%#%*%%@@@%%%*%@%**%@@#.                     
                        +@##%%@@@@@-.:##*+%@@@@%%@*#@@@@%@%@%#@#@@%@@@%**#=                       
                         :%%%@%*#@@@+:.:*+%#@@@@%%%@@@@@@@%*%@*%@+%@@@@*#.                        
                       .=+#######=+%@%+-:+@@@@@@@@@@@@@@@##@@@@%%@@@@@@#+:                        
                        %@@@%%#+#*--@@@%*+:#%%@@@@@@@@@#**%@@@@@@@@@@@@%%=:-.  ..                 
                    ****@%#%@###@@#=##@@@+= -#@%@@@@@#*%%@@@@@@@@@@@@@@@@@@%%%+@#-                
                    ##%-*#  :*+%@%+@+.-*@@@**%+=*@@@%@@@@%%%#%@@@@@@@@@#+#@=.+=+@#.               
                    .=*. =-. .#@%%#%@@*+#*@@@@#=*@@@@@@@@%%%%@@@@@@@@@@#..+  ::-%                 
                      #@@%%-:-#@%@@=#*##*-%%@@%**@@@%@%@@+#@@@@@@@@@@@@@%%@=:#-%-                 
                     :@@@@@#+:+%%@@#*++=*%+*#+*@#@@@%*--%%@@@@+#@@@@@@@@#-:=+*#%                  
                     =@@@@@@@*+#%@@@@@@@@@@@@@@@@@@@@@%%@@@@@@@@@@@@@@@##@#*-..=                  
                     *@@@%+@%%%@@@%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#+:*+-***=                 
                     :*@@@#*@@@#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%=:*#%%.                
                      %@@@%*@@%*@%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*=-.=%*:+@#+                 
                    .:#%+*@@%%#:*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=-==+-==+@.                  
                    =#..*%:+#@*+.-#@@@@%%%%%@@%%@@@@#%%@#%%%*#%%##*%*.+%*##+ *++                  
                    :@%: #%*-*@%+=****+=:.  -   -*:+.+#+-+%=-###+++***@@@@@% -%%                  
                     #%%: *@@=*%*%@%@%*@#=:=%+-.#%:*##*#+=@=@@%%%**%%@@@@@@@+=#@:+=               
                     @%#%: +@%@@@@@%%@%%@+=%@=:+@@*%%@@@@@@%@@@%@@@@@@@@@@@@-**@%@%.              
                    -@@%@%: =@@@@@@@@%%=#@@%@@#%@@@#%@%@@%@@@@@@@@@@@@@@@@@%---#@@@:              
                   =+@@+@@%: -@@##*%%@@%-+%%%@**@@@%@@@@@@@%@@@@@@%@@@@@@@@*=.: *%=               
                  -+*@#=*@@@- -@*#*#+#@@@=+@*=*%*@@@%+*%%@%@@@@@@%@@@@@@@@@@%=..+*                
                 .@@@%*++%@@@- +=++#::%@@@**@@@@##%@@@%###%@@@@#@@@@@%**@@@@@#-:.%.               
                  =@@%#+-.:@@@=+::=%*+*#%@@@@@@@#+=*#%@@@@@%+*%#%@@@@%##@@@@@#+  =-               
                   %%#+-.. #@@@%===@%@@@@@@%@#*%@@*%@@%%*%@@@@*#@@@@@@*#@@@@@%*- :*               
                  +%#**--=-=%@@%*=-##@%@@@@@%#**%@@@@@@%%@#%@@%@@@@@%##@@@@@@%%=. =-              
                 .@#+++#= .=.*@%--:--+*+*+*##%@@@@@@@@@@@##+==-+#%@@%##@@@@@*.@:-: +              
                 %#+=----=:--:*=.:.==-=+++*%@@%*=+@@@%@@@@@%#*++==%@@@%@@@@@%+=-.:-:+             
                *#-:::-+*-.:+=%=-=.-+=--*%@@@@@****@@@@@@@@@@%##%#@@@@@*@@@@%#+%-:+:--            
               =#*=:==+*@*: .:=+++===*%@%#%@@@@@%#%**%@@@%@@@@@@@@@@@@@-=+%@@@+@#:*=:=.           
              .%#=--:===*@+-.-*=+%%@@#+:*%@#@@@@@#**=#%@@%@@@@@@@@@@@@@*#%%@@#@@%*-.:-:           
             :*@+=--:==--=+=:-#*#@##%%--=#%*%#**%@*--:%@@#@@@@@%+#%@@@@@@@@@@-#@#@#:..-.          
            *%#==--=-==--==+=-==#%*@@@*..=+=====#@@#+*+*@+@%#%@#@@@@@@@@@@@@@#+**@@* .=--         
           =#@#=::.-=---+#%@@*:::*=*%#*+*:-%@@#@#%%@%=*+%#**@*%@@@@@@@@@@@@@@@@%%*+##==-::+-      
          .#@#=. ++--++#*=*@@%==-===+=**--::---:..  ..:::...::====-+*#%@@@@@@@@@@%##+==--.:::     
           *#*...-=##+#*##*#*=::.                                       -+*##@@@@@#%%%@+.-.:-     
          -**#*+==*%#+*=-.                                                     .-=*@@##@==- .     
          =+==+*+:.                                                                 .=+*%%#-      
          .-::                                                                          -=-.      
                                                                                                  
";
      CambiarColorFondo("Negro");
      CambiarColorTexto("Gris");
      Console.WriteLine(asciiTrono);
      ColorOriginal();
    }
  }
}