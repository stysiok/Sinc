namespace Sinc.Spotify.Models
{
    public class SpotifyAccess 
    {
        public string Token { get; private set; }
        public string TokenType { get; private set; }

        public SpotifyAccess(SpotifyToken spotifyToken)
        {
            Token = spotifyToken.AccessToken;
            TokenType = spotifyToken.TokenType;
        }
    }
}