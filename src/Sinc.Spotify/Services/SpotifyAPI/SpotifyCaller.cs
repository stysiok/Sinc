using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sinc.Spotify.Models;
using Sinc.Spotify.Models.DTOs;

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

        public async Task<SpotifyResponse<T>> GetAsync<T>(string location, bool fullPathProvided = false)
        {
            var token = await _spotifyAuthorization.GetTokenAsync();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(token.TokenType, token.Token);

                var uri = fullPathProvided ? location : $"{_spotifyOptions.ApiUrl}/{location}";
                var response = await client.GetAsync(uri);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<SpotifyResponse<T>>(content);

                return data;
            }
        }
    }
}