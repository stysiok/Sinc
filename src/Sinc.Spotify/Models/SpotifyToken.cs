using System;
using Newtonsoft.Json;

namespace Sinc.Spotify.Models
{
    public class SpotifyToken
    {
        public string AccessToken { get; private set; }
        public string TokenType { get; private set; }
        public int ExpiresIn { get; private set; }
        public string RefreshToken { get; private set; }
        public string Scope { get; private set; }
        public DateTime ValidUntil { get; private set; }
        public bool IsActive => DateTime.Now.AddMinutes(-1) < ValidUntil;

        [JsonConstructor]
        public SpotifyToken(string access_token, string token_type, int expires_in, string refresh_token, string scope)
        {
            AccessToken = access_token;
            TokenType = token_type;
            ExpiresIn = expires_in;
            RefreshToken = refresh_token;
            Scope = scope;
            ValidUntil = DateTime.Now.AddSeconds(ExpiresIn);
        }

        public SpotifyToken(SpotifyOptions spotifyOptions)
        {

            AccessToken = spotifyOptions.DefaultAccessToken;
            TokenType = "Bearer";
            ExpiresIn = 3600;
            RefreshToken = spotifyOptions.DefaultRefreshToken;
            Scope = spotifyOptions.DefaultScope;
            ValidUntil = DateTime.Now.AddSeconds(ExpiresIn);
        }

    }
}