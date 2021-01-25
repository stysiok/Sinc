using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Spotify;

namespace Sinc.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
                
            var serviceProvider = new ServiceCollection()
                .UseSpotify(configuration)
                .UseStorage(configuration)
                .UseSinc(configuration)
                .BuildServiceProvider();

            var spotifyCaller = serviceProvider.GetService<SincPlaylists>();

            spotifyCaller.Run().Wait();
        }
    }
}
