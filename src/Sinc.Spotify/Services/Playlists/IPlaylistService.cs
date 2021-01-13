using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.Playlists
{
    public interface IPlaylistService
    {
        SpotifyPlaylist GetSpotifyPlaylist(string nameOfPlaylist);
    }
}