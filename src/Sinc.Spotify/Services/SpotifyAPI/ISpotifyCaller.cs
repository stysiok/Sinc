using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public interface ISpotifyCaller 
    {
        Task<IEnumerable<T>> GetAsync<T>(string location);
    }
}