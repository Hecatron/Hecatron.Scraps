using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Configuration;

namespace Chromely.Quasar1.Models.Config.Local {

    /// <summary> Helper class for loading in the application options. </summary>
    public class AppOptionsHelper {

        /// <summary> Binds the settings from a configuration section to an existing instance. </summary>
        /// <param name="section">  The configuration section. </param>
        /// <param name="instance"> The existing instance. </param>
        public static void Bind(IConfigurationSection section, AppOptions instance) {

            string usechromelystr = null;
            foreach (var item in section.GetChildren()) {
                switch (item.Key) {
                    case "Urls":
                        instance.Urls = item.Value.Split(";");
                        break;
                    case "UseChromely":
                        usechromelystr = item.Value;
                        break;
                    case "ChromelyFrameless":
                        instance.ChromelyFrameless = bool.Parse(item.Value);
                        break;
                    case "ChromelyDebuggingMode":
                        instance.ChromelyDebuggingMode = bool.Parse(item.Value);
                        break;
                }
            }

            // If not set in the json file, then check the env variable, then pick a default if all else fails
            if (instance.Urls == null)
                instance.Urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")?.Split(";");
            if (instance.Urls == null)
                instance.Urls = new[] { $"http://localhost:{FreeTcpPort()}" };

            // If not set in the json file, then check the env variable
            if (usechromelystr == null) {
                var envval = Environment.GetEnvironmentVariable("ASPNETCORE_CHROMELY");
                if (envval != null)
                    instance.UseChromely = bool.Parse(envval);
                else
                    instance.UseChromely = true;
            }
            else {
                instance.UseChromely = bool.Parse(usechromelystr);
            }
        }

        /// <summary> Binds the settings from a configuration section to a new instance. </summary>
        /// <param name="section"> The configuration section. </param>
        /// <returns> The AppOptions instance. </returns>
        public static AppOptions Bind(IConfigurationSection section) {
            var instance = new AppOptions();
            Bind(section, instance);
            return instance;
        }

        /// <summary> Find the next free TCP port for dynamic allocation. </summary>
        /// <returns> Free TCP Port. </returns>
        private static int FreeTcpPort() {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            try {
                return ((IPEndPoint)listener.LocalEndpoint).Port;
            }
            finally {
                listener.Stop();
            }
        }
    }
}
