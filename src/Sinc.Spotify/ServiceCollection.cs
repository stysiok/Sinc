using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Spotify.Models;
using Sinc.Spotify.Services.Playlists;
using Sinc.Spotify.Services.Songs;
using Sinc.Spotify.Services.SpotifyAPI;

namespace Sinc.Spotify
{
    public static class SpotifyServices
    {
        public static IServiceCollection UseSpotify(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .Configure<SpotifyOptions>(configuration.GetSection("Spotify"))
                .AddTransient<ISpotifyCaller, SpotifyCaller>()
                .AddSingleton<ISpotifyAuthorization, SpotifyAuthorization>()
                .AddTransient<ISpotifyPlaylistService, SpotifyPlaylistService>()
                .AddTransient<ISpotifySongsService, SpotifySongsService>()
                .AddTransient<ISpotify, Spotify>();

    }
}