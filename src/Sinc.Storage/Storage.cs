using System.Threading.Tasks;
using Sinc.Storage.Models;
using Sinc.Storage.Services;

namespace Sinc.Storage
{
    public class Storage : IStorage
    {
        private readonly IStoredPlaylistService _storedPlaylistService;
        
        public Storage(IStoredPlaylistService storedPlaylistService)
        {
            _storedPlaylistService = storedPlaylistService;
        }

        public async Task<StoredPlaylist> GetStoredPlaylist(string name)
            => await _storedPlaylistService.GetStoredPlaylists(name);
    }
}