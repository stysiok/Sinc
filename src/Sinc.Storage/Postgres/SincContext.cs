using Microsoft.EntityFrameworkCore;
using Sinc.Storage.Models;

namespace Sinc.Storage.Postgres
{
    public class SincContext : DbContext
    {
        public DbSet<StoredPlaylist> Playlists { get; set; }
        public DbSet<StoredSong> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("User ID=postgres;Password=P@ssw0rd;Host=localhost;Port=5432;Database=Sinc;Pooling=true;");
    }
}