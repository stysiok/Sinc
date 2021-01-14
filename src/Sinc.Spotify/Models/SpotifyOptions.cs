namespace Sinc.Spotify.Models
{
    public class SpotifyOptions
    {
        public string ApiUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string DefaultRefreshToken { get; set; }
        public string DefaultAccessToken { get; set; }
        public string DefaultScope { get; set; }
    }
}