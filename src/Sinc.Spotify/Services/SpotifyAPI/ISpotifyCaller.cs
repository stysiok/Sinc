using System.Collections.Generic;
using System.Threading.Tasks;
using Sinc.Spotify.Models.DTOs;

namespace Sinc.Spotify.Services.SpotifyAPI
{
    public interface ISpotifyCaller 
    {
        Task<SpotifyResponse<T>> GetAsync<T>(string location, bool fullLocationProvided = false);
    }
}