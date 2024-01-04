using System.Text;

namespace PruebaProgreso2.Utility
{
    public class HttpClient
    {
        // Metodo para consumir api de tipo post en donde se envi un string con un json y recibe un json
        public static async Task<string> Post(string url, string json)
        {
            var httpClient = new System.Net.Http.HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
