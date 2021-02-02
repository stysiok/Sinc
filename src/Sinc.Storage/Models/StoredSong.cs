namespace Sinc.Storage.Models
{
    public class StoredSong
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public int StoredPlaylistId { get; set; }
        public StoredPlaylist Playlist { get; set; }
    }
}