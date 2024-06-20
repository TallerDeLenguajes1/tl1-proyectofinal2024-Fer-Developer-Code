// See https://aka.ms/new-console-template for more information
using EspacioArteAscii;
using EspacioApiJsonToCsharp;
using EspacioFunciones.Helpers;
ArteAscii ImgJuego = new ArteAscii();
ImgJuego.MostrarLogo();

var funcionesAsync  = new FuncionesAsync();
var NombrePj = await funcionesAsync.GetNombreAsync();

Console.WriteLine(NombrePj.name);