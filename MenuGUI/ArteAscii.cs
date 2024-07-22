namespace EspacioArteAscii.GUI
{
  public class ArteAscii
  {
    public void CentrarAscii(string[] graficoAscii)
    {
      foreach (var linea in graficoAscii)
      {
        EscribirCentrado(linea);
      }
    }
    public void EscribirCentrado(string texto)
    {
      int posicionX = (Console.WindowWidth - texto.Length) / 2;
      Console.SetCursorPosition(posicionX, Console.CursorTop);
      Console.WriteLine(texto);
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
        case "blanco":
          Console.ForegroundColor = ConsoleColor.White;
          break;
        case "naranja":
          Console.ForegroundColor = ConsoleColor.DarkYellow;
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
        case "blanco":
          Console.BackgroundColor = ConsoleColor.White;
          break;
        case "naranja":
          Console.BackgroundColor = ConsoleColor.DarkYellow;
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
      ConsoleKey KeyPressed;
      do
      {
        Console.WriteLine("Antes de comenzar por favor ponga la terminal en pantalla completa, presione enter para continuar");
        ConsoleKeyInfo tecla = Console.ReadKey(true); // Esperar a que el usuario presione una tecla antes de continuar
        KeyPressed = tecla.Key;
      } while (KeyPressed != ConsoleKey.Enter);
      Console.Clear();
      string[] asciiBienvenida = new string[]{
@"______  _                                   _      _                      _     _                             _ ",
@"| ___ \(_)                                 (_)    | |                    | |   (_)                           | |",
@"| |_/ / _   ___  _ __  __   __  ___  _ __   _   __| |  ___   ___    __ _ | |    _  _   _   ___   __ _   ___  | |",
@"| ___ \| | / _ \| '_ \ \ \ / / / _ \| '_ \ | | / _` | / _ \ / __|  / _` || |   | || | | | / _ \ / _` | / _ \ | |",
@"| |_/ /| ||  __/| | | | \ V / |  __/| | | || || (_| || (_) |\__ \ | (_| || |   | || |_| ||  __/| (_| || (_) ||_|",
@"\____/ |_| \___||_| |_|  \_/   \___||_| |_||_| \__,_| \___/ |___/  \__,_||_|   | | \__,_| \___| \__, | \___/ (_)",
@"                                                                              _/ |               __/ |          ",
@"                                                                             |__/               |___/            "
      };
      string banner = new string('*', Console.WindowWidth);
      CambiarColorTexto("magenta");
      EscribirConAnimacion(banner, 1);
      CentrarAscii(asciiBienvenida);
      EscribirConAnimacion(banner, 1);
      string[] asciiPalabraAventura = new string[]{
@" _______                _                                _                                                                   ",
@"(_______)              (_)                              | |                                         _                        ",
@" _         ___   ____   _  _____  ____   _____  _____   | |  _____    _____  _   _  _____  ____   _| |_  _   _   ____  _____ ",
@"| |       / _ \ |    \ | || ___ ||  _ \ (___  )(____ |  | | (____ |  (____ || | | || ___ ||  _ \ (_   _)| | | | / ___)(____ |",
@"| |_____ | |_| || | | || || ____|| | | | / __/ / ___ |  | | / ___ |  / ___ | \ V / | ____|| | | |  | |_ | |_| || |    / ___ |",
@" \______) \___/ |_|_|_||_||_____)|_| |_|(_____)\_____|   \_)\_____|  \_____|  \_/  |_____)|_| |_|   \__)|____/ |_|    \_____|",
@"                                                                                                                             "
};
      Console.ResetColor();
      CambiarColorTexto("Rojo");
      CentrarAscii(asciiPalabraAventura);
      EscribirConAnimacion(banner, 1);
      Thread.Sleep(233);
      Console.ResetColor();
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
      Console.ResetColor();
    }
    public string[] AsciiGuerreros
    {
      get
      {
        return new string[]
        {
@"                                                           ████████                                 ",
@"                                                         ███████████                                ",
@"                                                       █████████████                                ",
@"                                                        ███████████                                 ",
@"                   ███████                     ███████████████████                                  ",
@"                  ███████████            ███  █████████████████████                                 ",
@"                  ███████████            ██████████████████████████                                 ",
@"██               █████████████               █████████ ████████████                                 ",
@"████              █████████████████      █       ████████████████████                               ",
@" ████              ██████████████████████████      █████████████ █████                              ",
@"  ███               ███████████████████████████       █████████   ██████                            ",
@"   ███             ████████████████████████████      ████████████   █████                           ",
@"    ███            ███████████████   ███████████   █████████████████ █████                          ",
@"     ███           ████████████████  ████████████  ████████████████████████                         ",
@"      ███          █████████████████ ████████████ ████████████████████████████                      ",
@"       ███          █████████████████████████████ ████████████████████   ██████                     ",
@"        ███         ████ ████████████████████████████████████████████      ████████                 ",
@"         ███ █   ███████████████████████████████████████████ ████████            █████ ██           ",
@"         ███████████████████████████████████████████████     █████                  ███████ ██      ",
@"         ███████████  ███████████████████ █████████████     █████                      █████████    ",
@"           ██████   ██████████  ██████████      ██████     █████                          ███████   ",
@"           █████   █████████     ██████████  ███████      ██████                            ████████",
@"             ██   █████████        █████████████████       █████                                    ",
@"                  █████████████      ██████████████         █████                                   ",
@"                   ██████████████      ██████████            █████                                  ",
@"                        █████████        █████████             ██                                   ",
@"                             ████        ███████████                                                ",
@"                             ████        ████████████                                               ",
@"                             ████        ████  ████████                                             ",
@"                                         ████   ███████                                             ",
@"                                          ███    ██████                                             ",
@"                                                  █████                                             ",
@"                                                ███████                                             "
        };
      }
    }
    public string[] AsciiTrofeo
    {
      get
      {
        return new string[]
        {
          @"

                                                  ",
@"              -------------====+++++              ",
@"            -:::::::::::::-----======+            ",
@"      +=====-::::....::::::----======+------      ",
@"     +++   =:::........:::::----======-   ---     ",
@"    +=+   ==--:.........::::----====++==   ---    ",
@"     ===     -:........:::::----====+     ==-     ",
@"      =-==   -:::.....::::::----====+   ++-=      ",
@"        =---- -::::::::::::----====+ =====        ",
@"           ----::::::::::-----=====+---           ",
@"             --=--::--------======+--             ",
@"            --- =---------=======+ ---            ",
@"                #=---===========+                 ",
@"                  +===========++                  ",
@"                    ++======++                    ",
@"                     -----==+                     ",
@"                      ----=+                      ",
@"                      ----=+                      ",
@"                      ----=+                      ",
@"                     -----=++                     ",
@"                  +=-:----===+++                  ",
@"              ######################              ",
@"              ###===------:----==###              ",
@"              ###==-----::----===###              ",
@"              ###------:----=====###              ",
@"              ######################              ",
@"           ############################           ",
@"                                                  "
        };
      }
    }
  }
}