using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sinc.Main.Config;
using Sinc.Spotify;
using Sinc.Storage;

namespace Sinc.Main
{
    public class SincPlaylists
    {
        private IStorage _storage { get; set; }
        private ISpotify _spotify { get; set; }
        private SincOptions _sincOptions { get; set; }

        public SincPlaylists(ISpotify spotify, IStorage storage, IOptions<SincOptions> sincOptions)
        {
            _spotify = spotify;
            _storage = storage;
            _sincOptions = sincOptions.Value;
        }

        public async Task Run()
        {
            var spotifyData = await _spotify.GetSpotifyPlaylistWithSongs(_sincOptions.PlaylistToSync);
            var storage = _storage.GetStoredPlaylist(_sincOptions.PlaylistToSync);
            return;
        }
    }
}