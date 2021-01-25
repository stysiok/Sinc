using Sinc.Storage.Models;

namespace Sinc.Storage
{
    public interface IStorage
    {
        StoredPlaylist GetStoredPlaylist(string name);
    }
}