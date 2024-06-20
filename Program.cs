// See https://aka.ms/new-console-template for more information
using EspacioArteAscii;
using EspacioApiNombres;
using System.Text.Json;
ArteAscii ImgJuego = new ArteAscii();
ImgJuego.MostrarLogo();

NombrePersonaje NombreObtenido = await GetNombreAsync();


static async Task<NombrePersonaje> GetNombreAsync()
{
    string url = "https://api.namefake.com/";
    try
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        NombrePersonaje nombrePersonaje = JsonSerializer.Deserialize<NombrePersonaje>(responseBody);
        return nombrePersonaje;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}