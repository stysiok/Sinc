using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sinc.Storage.Models;
using Sinc.Storage.Postgres;

namespace Sinc.Storage.Services.Postgres
{
    public class PostgresStoredPlaylistService : IStoredPlaylistService
    {
        private readonly SincContext _context;
        
        public PostgresStoredPlaylistService(SincContext context)
        {
            _context = context;
        }

        public async Task<StoredPlaylist> GetStoredPlaylists(string name)
            => await _context.Playlists.SingleOrDefaultAsync(p => p.Name == name);
    }
}