using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public class SpotifyAuthorization : ISpotifyAuthorization
    {
        private SpotifyToken _spotifyToken;
        private readonly string URL = "https://accounts.spotify.com/api/token";
        private readonly SpotifyOptions _spotifyOptions;

        public SpotifyAuthorization(IOptions<SpotifyOptions> spotifyOptions)
        {
            _spotifyOptions = spotifyOptions.Value;
        }

        public async Task<SpotifyAccess> GetTokenAsync()
        {
            if (_spotifyToken != null && _spotifyToken.IsActive) return new SpotifyAccess(_spotifyToken);

            SpotifyToken refreshedToken = null;
            using (var httpClient = new HttpClient())
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), URL))
            {
                var combinedClientIdSecret = $"{_spotifyOptions.ClientId}:{_spotifyOptions.ClientSecret}";
                var base64Secrets = Convert.ToBase64String(Encoding.UTF8.GetBytes(combinedClientIdSecret));
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Secrets);

                var contentList = new List<string>
                {
                    "grant_type=refresh_token",
                    $"refresh_token={_spotifyOptions.DefaultRefreshToken}"
                };
                request.Content = new StringContent(string.Join("&", contentList));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                var response = await httpClient.SendAsync(request);

                var content = await response.Content.ReadAsStringAsync();
                refreshedToken = JsonConvert.DeserializeObject<SpotifyToken>(content);
            }

            _spotifyToken = refreshedToken;
            return new SpotifyAccess(_spotifyToken);
        }
    }
}