using System.Collections.Generic;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.Songs
{
    public interface ISongsService 
    {
        IEnumerable<SpotifySong> GetNewSongsOnPlaylist(IEnumerable<SpotifySong> spotifySongs);
    }
}