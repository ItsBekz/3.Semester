using mvc.Models;
using Newtonsoft.Json;

namespace mvc
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/");
        }

        public async Task<Pokemon> GetPokemonData(string pokemonName)
        {
            try
            {
                // Send a message to the API
                var response = await _httpClient.GetAsync($"api/pokemon/{pokemonName}");
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the respons content to a pokemon object
                    var content = await response.Content.ReadAsStringAsync();
                    var pokemon = JsonConvert.DeserializeObject<Pokemon>(content);
                    return pokemon;
                }
                return null;
            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }
    }
}
