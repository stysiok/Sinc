using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinc.Spotify.Models;
using Sinc.Spotify.Models.DTOs;
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
        {
            var result = await _caller.GetAsync<SpotifySongDto>(songsUrl, true);
            var songs = result.items.Select(ssdto => new SpotifySong(ssdto)).ToList();
            
            if(string.IsNullOrEmpty(result.next)) 
                return songs;

            foreach(var song in await GetSongsOnPlaylist(result.next))
                songs.Add(song);
            
            return songs;
        }
    }
}