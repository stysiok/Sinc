using System.Linq;
using Newtonsoft.Json;
using Sinc.Spotify.Models.DTOs;

namespace Sinc.Spotify.Models
{
    public class SpotifySong
    {
        public string SpotifyId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }

        public SpotifySong(SpotifySongDto track)
        {
            SpotifyId = track.id;
            Artist = track.artists.First().name;
            Title = track.name;
        }
    }
}