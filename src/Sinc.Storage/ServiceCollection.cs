using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Storage;

namespace Sinc.Storage
{
    public static class StorageServices
    {
        public static IServiceCollection UseStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .AddTransient<IStorage, Sinc.Storage.Storage>();

    }
}