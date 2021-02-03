using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sinc.Spotify.Models.DTOs
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class SpotifySongDto
    {
        [JsonProperty("track.id")]
        public string id { get; set; }
        [JsonProperty("track.name")]
        public string name { get; set; }
        [JsonProperty("track.artists")]
        public IEnumerable<Artist> artists { get; set; }
    }
    
    [JsonConverter(typeof(JsonPathConverter))]
    public class Artist
    {
        [JsonProperty("name")]
        public string name { get; set; }
    }
}