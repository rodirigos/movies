using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieProject.DTO;
using MovieProject.Model;
using MovieProject.Services;
using MovieProject.Util;
using MovieProject.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;

namespace MovieProject
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static void Init()
        {   
            var configFile = ExtractResource("MovieProject.appsettings.json", FileSystem.AppDataDirectory);

            var host = new HostBuilder()
                        .ConfigureHostConfiguration(c =>
                        {
                            c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                            c.AddJsonFile(configFile);
                        })
                        .ConfigureServices((c, x) =>
                        {
                            ConfigureServices(c, x);
                        })
                        .ConfigureLogging(l => l.AddConsole(o =>
                        {
                            o.DisableColors = true;
                        }))
                        .Build();
            ServiceProvider = host.Services;

        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<IMovieService, MovieService>();
            services.AddTransient<UpcomingMovieViewModel>();

            var configuration = new MapperConfiguration(mp=>
            {
                mp.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        static string ExtractResource(string filename, string location)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var resFileStream = assembly.GetManifestResourceStream(filename))
            {
                if (resFileStream != null)
                {
                    var full = Path.Combine(location, filename);
                    using (var stream = File.Create(full))
                    {
                        resFileStream.CopyTo(stream);
                    }
                }
                return Path.Combine(location, filename);
            }
        }



    }
}
