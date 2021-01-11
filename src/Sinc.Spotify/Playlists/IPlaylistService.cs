using Sinc.Spotify.Models;

namespace Sinc.Spotify.Playlists
{
    public interface IPlaylistService
    {
        SpotifyPlaylist GetSpotifyPlaylist(string nameOfPlaylist);
    }
}