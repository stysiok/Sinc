using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Main.Config;

namespace Sinc.Main
{
    public static class MainServices
    {
        public static IServiceCollection UseSinc(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .Configure<SincOptions>(configuration.GetSection("Sinc"))
                .AddTransient<SincPlaylists>();

    }
}