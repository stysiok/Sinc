using System;

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

        public SpotifyToken(string accessToken, string tokenType, int expiresIn, string refreshToken, string scope)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            RefreshToken = refreshToken;
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