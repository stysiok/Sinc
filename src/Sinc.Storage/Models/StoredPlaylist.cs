using System.Collections.Generic;

namespace Sinc.Storage.Models
{
    public class StoredPlaylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpotifyId { get; set; }
        public IEnumerable<StoredSong> Songs { get; set; }
    }
}