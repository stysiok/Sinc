using System.Threading.Tasks;

namespace Sinc.Spotify
{
    public interface ISpotify 
    {
        Task<SpotifyPlaylist> GetSpotifyPlaylistWithSongs(string playlistLabel);
    }
}