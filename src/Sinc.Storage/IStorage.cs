using System.Threading.Tasks;
using Sinc.Storage.Models;

namespace Sinc.Storage
{
    public interface IStorage
    {
        Task<StoredPlaylist> GetStoredPlaylist(string name);
    }
}