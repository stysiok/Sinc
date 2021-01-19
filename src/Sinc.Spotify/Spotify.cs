using System.Threading.Tasks;
using Sinc.Spotify.Services.Playlists;
using Sinc.Spotify.Services.Songs;

namespace Sinc.Spotify
{
    public class Spotify : ISpotify
    {
        private ISpotifyPlaylistService _spotifyPlaylistService { get; set; }
        private ISpotifySongsService _spotifySongsService { get; set; }

        public Spotify(ISpotifyPlaylistService spotifyPlaylistService, ISpotifySongsService spotifySongsService)
        {
            _spotifyPlaylistService = spotifyPlaylistService;
            _spotifySongsService = spotifySongsService;
        }

        public async Task<SpotifyPlaylist> GetSpotifyPlaylistWithSongs(string playlistLabel)
        {
            var playlist = await _spotifyPlaylistService.GetSpotifyPlaylist(playlistLabel);
            var songs = await _spotifySongsService.GetSongsOnPlaylist(playlist.TracksURL);

            playlist.Songs = songs;

            return playlist;
        }
    }
}