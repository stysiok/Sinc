using System.Collections.Generic;
using System.Threading.Tasks;
using Sinc.Spotify.Models;
using Sinc.Spotify.Services.SpotifyAPI;

namespace Sinc.Spotify.Services.Songs
{
    public class SpotifySongsService : ISpotifySongsService
    {
        private ISpotifyCaller _caller { get; set; }

        public SpotifySongsService(ISpotifyCaller caller)
        {
            _caller = caller;
        }
        public async Task<IEnumerable<SpotifySong>> GetSongsOnPlaylist(string songsUrl) 
            => await _caller.GetAsync<SpotifySong>(songsUrl, true);
    }
}