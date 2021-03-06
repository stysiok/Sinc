using System.Collections.Generic;

namespace Sinc.Spotify.Models.DTOs
{
    public class SpotifyResponse<T>
    {
        public string href { get; set; } 
        public IList<T> items { get; set; } 
        public int limit { get; set; } 
        public string next { get; set; } 
        public int offset { get; set; } 
        public string previous { get; set; } 
        public int total { get; set; }
    }
}