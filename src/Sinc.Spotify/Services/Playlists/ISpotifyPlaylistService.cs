using System.Threading.Tasks;

namespace Sinc.Spotify.Services.Playlists
{
    public interface ISpotifyPlaylistService
    {
        Task<SpotifyPlaylist> GetSpotifyPlaylist(string nameOfPlaylist);
    }
}