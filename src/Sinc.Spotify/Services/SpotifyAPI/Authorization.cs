using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public class SpotifyAuthorization : ISpotifyAuthorization
    {
        private SpotifyToken _token;
        public string GetToken()
        {
            if(_token != null && _token.IsActive) return _token.AccessToken;

            //refresh token
            // _token = refreshedToken;
            return _token.AccessToken;
        }
    }
}