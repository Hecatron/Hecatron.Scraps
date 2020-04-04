using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chromely.Quasar1.Models.Config.Local;

namespace Chromely.Quasar1.Models.Config {

    /// <summary> A configuration loader. </summary>
    public static class ConfigLoader {

#if DEBUG
        private const string _localConfigFile = "appsettings.Development.json";
#else
        private const string _localConfigFile = "appsettings.json";
#endif

        /// <summary> Gets the configuration settings from the json file. </summary>
        /// <returns> The configuration settings. </returns>
        public static IConfigurationRoot GetConfigRoot() {

            // Setup a configuration builder
            var cfgbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // read the configuration settings from the appsettings.json file
                .AddJsonFile(_localConfigFile, true);

            var cfg1 = cfgbuilder.Build();
            return cfg1;
        }

        /// <summary> Sets up the configuration services. </summary>
        /// <param name="services"> The services to add to. </param>
        /// <param name="cfg">      The loaded configuration. </param>
        public static void SetupConfigServices(IServiceCollection services, IConfiguration cfg) {
            // Load in configuration settings for dependency injection
            //services.Configure<LocalDbOptions>(options =>
            //    cfg.GetSection("LocalDbOptions").Bind(options));
            //services.Configure<AutoLoginOptions>(options =>
            //    cfg.GetSection("AutoLoginOptions").Bind(options));
            services.Configure<AppOptions>(options => {
                AppOptionsHelper.Bind(cfg.GetSection("AppOptions"), options);
            });
        }
    }
}
