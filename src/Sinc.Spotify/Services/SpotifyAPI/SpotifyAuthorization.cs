using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public class SpotifyAuthorization : ISpotifyAuthorization
    {
        private SpotifyToken _spotifyToken;
        private readonly string URL = "https://accounts.spotify.com/api/token";
        private readonly SpotifyOptions _spotifyOptions;

        public SpotifyAuthorization(SpotifyOptions spotifyOptions)
        {
            _spotifyOptions = spotifyOptions;
        }

        public async Task<SpotifyAccess> GetTokenAsync()
        {
            if(_spotifyToken != null && _spotifyToken.IsActive) return new SpotifyAccess(_spotifyToken);

            if(_spotifyToken is null) _spotifyToken = new SpotifyToken(_spotifyOptions);
            
            SpotifyToken refreshedToken = null;
            using (var client = new HttpClient())
            {
                var combinedClientIdSecret = $"{_spotifyOptions.ClientId}:{_spotifyOptions.ClientSecret}";
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", 
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(combinedClientIdSecret))
                    );

                var response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                refreshedToken = JsonConvert.DeserializeObject<SpotifyToken>(content);
            }

            _spotifyToken = refreshedToken;
            return new SpotifyAccess(_spotifyToken);
        }
    }
}