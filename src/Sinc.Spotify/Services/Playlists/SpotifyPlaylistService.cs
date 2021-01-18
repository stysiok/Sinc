using System.Linq;
using System.Threading.Tasks;
using Sinc.Spotify.Services.SpotifyAPI;

namespace Sinc.Spotify.Services.Playlists
{
    public class SpotifyPlaylistService : ISpotifyPlaylistService
    {
        private ISpotifyCaller _caller { get; set; }

        public SpotifyPlaylistService(ISpotifyCaller caller)
        {
           _caller = caller;
        }

        public async Task<SpotifyPlaylist> GetSpotifyPlaylist(string nameOfPlaylist)
        {
            var result = await _caller.GetAsync<SpotifyPlaylist>("me/playlists");
            return result.FirstOrDefault(p => p.Name == nameOfPlaylist);
        }
        
    }
}