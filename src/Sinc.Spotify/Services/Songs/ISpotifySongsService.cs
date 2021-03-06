using System.Collections.Generic;
using System.Threading.Tasks;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.Songs
{
    public interface ISpotifySongsService 
    {
        Task<IEnumerable<SpotifySong>> GetSongsOnPlaylist(string songsUrl);
    }
}