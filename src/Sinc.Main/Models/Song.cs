using System;

namespace Sinc.Main.Models
{
    public class Song
    {
        public int StorageId { get; set; }
        public string SpotifyId { get; set; }
        public string AppleId { get; set; }
        public string YouTubeId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
    }
}