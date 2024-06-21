using System.Text.Json;
using EspacioApiJsonToCsharp.Helpers;
namespace EspacioFunciones.Helpers
{
    public class FuncionesAsync
    {
        public async Task<infoPj> GetNombreAsync()//La funcion no trabajaba por que no debia ser estatica ademas debia estar dentro de una cloase
        {
            string url = "https://api.namefake.com/";
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                infoPj nombrePj = JsonSerializer.Deserialize<infoPj>(responseBody);
                return nombrePj;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas de acceso a la API");
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }
        public async Task Prueba()
        {
            var funcion = new FuncionesAsync();
            var nombre = await funcion.GetNombreAsync();
            Console.WriteLine(nombre.name);
        }
    }
}