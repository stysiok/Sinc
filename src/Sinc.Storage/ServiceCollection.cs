using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Storage.Postgres;
using Sinc.Storage.Services;
using Sinc.Storage.Services.Postgres;

namespace Sinc.Storage
{
    public static class StorageServices
    {
        public static IServiceCollection UseStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .AddDbContext<SincContext>()
                .AddTransient<IStoredPlaylistService, PostgresStoredPlaylistService>()
                .AddTransient<IStorage, Sinc.Storage.Storage>();

    }
}