using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sinc.Spotify.Models.DTOs
{
    public class Artist
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Album
    {
        public IEnumerable<Artist> artists { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public class Track
    {
        [JsonProperty("track.id")]
        public string id { get; set; }
        [JsonProperty("track.name")]
        public string name { get; set; }
    }
}