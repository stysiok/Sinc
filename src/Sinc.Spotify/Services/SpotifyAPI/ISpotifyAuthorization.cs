using System.Threading.Tasks;
using Sinc.Spotify.Models;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public interface ISpotifyAuthorization
    {
        Task<SpotifyAccess> GetTokenAsync();
    }
}