using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<T>> GetAsync<T>(string location)
        {
            var token = await _spotifyAuthorization.GetTokenAsync();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(token.TokenType, token.Token);

                var uri = $"{_spotifyOptions.ApiUrl}/{location}";
                var response = await client.GetAsync(uri);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<SpotifyResponse<T>>(content).items;

                return data;
            }
        }
    }
    
    public class SpotifyResponse<T>
    {
        public string href { get; set; } 
        public List<T> items { get; set; } 
        public int limit { get; set; } 
        public bool? next { get; set; } 
        public int offset { get; set; } 
        public bool? previous { get; set; } 
        public int total { get; set; }
    }
}