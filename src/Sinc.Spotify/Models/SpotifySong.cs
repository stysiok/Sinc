using Newtonsoft.Json;

namespace Sinc.Spotify.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class SpotifySong
    {
        [JsonProperty()]
        public string Artist { get; set; }

        public string Title { get; set; }
    }
}