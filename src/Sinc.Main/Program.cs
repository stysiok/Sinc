﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinc.Spotify;
using Sinc.Spotify.Services.SpotifyAPI;

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
                .BuildServiceProvider();

            var spotifyCaller = serviceProvider.GetService<ISpotifyCaller>();

            string data = spotifyCaller.GetAsync<string>("me/playlists").Result;
        }
    }
}
