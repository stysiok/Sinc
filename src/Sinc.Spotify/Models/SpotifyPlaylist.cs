using Newtonsoft.Json;

namespace Sinc.Spotify
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class SpotifyPlaylist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string SpotifyId { get; set; }
        [JsonProperty("tracks.href")]
        public string TracksURL { get; set; }
    }
}