using System.Threading.Tasks;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public interface ISpotifyCaller 
    {
        Task<T> GetAsync<T>(string location);
    }
}