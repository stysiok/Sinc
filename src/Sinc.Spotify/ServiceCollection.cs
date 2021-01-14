using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Spotify.Models;

namespace Sinc.Spotify
{
    public static class SpotifyServices
    {
        public static IServiceCollection UseSpotify(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .Configure<SpotifyOptions>(configuration.GetSection("Spotify"));

    }
}