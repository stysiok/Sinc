using System.Linq;
using Newtonsoft.Json;
using Sinc.Spotify.Models.DTOs;

namespace Sinc.Spotify.Models
{
    public class Song
    {
        public string Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }

        public Song(SpotifySongDto track)
        {
            Id = track.id;
            Artist = track.artists.First().name;
            Title = track.name;
        }
    }
}