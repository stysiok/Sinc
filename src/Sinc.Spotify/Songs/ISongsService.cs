using System.Collections.Generic;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Songs
{
    public interface ISongsService 
    {
        IEnumerable<SpotifySong> GetNewSongsOnPlaylist(IEnumerable<SpotifySong> spotifySongs);
    }
}