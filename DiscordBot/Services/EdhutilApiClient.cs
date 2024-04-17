using System.Net.Http.Json;

namespace Edhutil.Discord.Services
{
    public class EdhutilApiClient
    {
        private HttpClient _client;

        public EdhutilApiClient(string url)
        {
            _client = new()
            {
                BaseAddress = new Uri(url)
            };
        }

        public EdhutilApiClient(string protocol, string host, string port)
        {
            _client = new()
            {
                BaseAddress = new Uri($"{protocol}://{host}:{port}")
            };
        }

        public async Task<Models.Card> GetRandomCard()
        {
            HttpResponseMessage response = await _client
                .GetAsync("/card/random");
            Models.Card card = await response.Content
                .ReadFromJsonAsync<Models.Card>() ?? Models.Card.Empty;
            return card;
        }

        public async Task<string> GetCardImageUrl(Guid id)
        {
            HttpResponseMessage response = await _client
                .GetAsync($"/card/{id}/image");
            string url = await response.Content
                .ReadAsStringAsync();
            return url;
        }
    }
}

