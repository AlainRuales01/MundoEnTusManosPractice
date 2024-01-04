using Data.Models;

namespace PruebaProgreso2.BO
{
    public class MundoEnTusManosBO
    {
        public async Task<Georreferenciacion?> GetUsuarioGeorreferenciacion(string userName)
        {

            using (var db = new MundoEnTusManosDbContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.UserName == userName);
                if (usuario == null)
                {
                    throw new Exception("No existe el usuario especificado");
                }

                var geeorreferencia = db.Georreferenciacions.FirstOrDefault(g => g.NombreCiudad == usuario.Ciudad);

                if (geeorreferencia != null)
                {
                    return geeorreferencia!;
                }


                string cityName = usuario.Ciudad;
                string apiKey = "529102000323188945962x125360";
                string apiUrl = $"https://geocode.xyz/{Uri.EscapeDataString(cityName)}?json=1&auth={apiKey}";

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            var georreferencia = new Georreferenciacion
                            {
                                NombreCiudad = cityName,
                                GeorreferenciaJson = jsonResponse
                            };
                            db.Georreferenciacions.Add(georreferencia);
                            db.SaveChanges();
                            return georreferencia;
                        }
                        else
                        {
                            Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return null;
        }
    }
}
