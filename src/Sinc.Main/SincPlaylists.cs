using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sinc.Main.Config;
using Sinc.Spotify;

namespace Sinc.Main
{
    public class SincPlaylists
    {
        private ISpotify _spotify { get; set; }
        private SincOptions _sincOptions { get; set; }

        public SincPlaylists(ISpotify spotify, IOptions<SincOptions> sincOptions)
        {
            _spotify = spotify;
            _sincOptions = sincOptions.Value;
        }

        public async Task Run()
        {
            var spotifyData = await _spotify.GetSpotifyPlaylistWithSongs(_sincOptions.PlaylistToSync);

            return;
        }
    }
}