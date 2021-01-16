using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public class SpotifyCaller : ISpotifyCaller
    {
        private readonly ISpotifyAuthorization _spotifyAuthorization;
        private readonly SpotifyOptions _spotifyOptions;

        public SpotifyCaller(ISpotifyAuthorization spotifyAuthorization, IOptions<SpotifyOptions> spotifyOptions)
        {
            _spotifyAuthorization = spotifyAuthorization;
            _spotifyOptions = spotifyOptions.Value;
        }

        public async Task<T> GetAsync<T>(string location)
        {
            var token = await _spotifyAuthorization.GetTokenAsync();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(token.TokenType, token.Token);

                var uri = $"{_spotifyOptions.ApiUrl}{location}";
                var response = await client.GetAsync(uri);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}