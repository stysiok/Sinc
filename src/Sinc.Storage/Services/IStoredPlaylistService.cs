using System.Threading.Tasks;
using Sinc.Storage.Models;

namespace Sinc.Storage.Services
{
    public interface IStoredPlaylistService 
    {
        Task<StoredPlaylist> GetStoredPlaylists(string name);
    }
}