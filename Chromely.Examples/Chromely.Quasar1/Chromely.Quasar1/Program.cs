using Chromely.Quasar1.Models.Config;
using Chromely.Quasar1.Models.Config.Local;
using Chromely.Quasar1.Providers.Chromely;
using Chromely.CefGlue.Browser;
using Chromely.Core;
using Chromely.Core.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chromely.Quasar1 {

    /// <summary> Main Program. </summary>
    public class Program {

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        [STAThread]
        public static void Main(string[] args) {
            // Get the config settings
            var config = ConfigLoader.GetConfigRoot();
            // Start the web app, ether as a website or as a chromely application
            StartWebApp(args, config);
        }

        /// <summary> Starts the web application. </summary>
        /// <param name="args">   An array of command-line argument strings. </param>
        /// <param name="config"> Configuration settings. </param>
        private static void StartWebApp(string[] args, IConfigurationRoot config) {

            // The services haven't been setup yet so grab the appconfig directly instead.
            var appcfg = AppOptionsHelper.Bind(config.GetSection("AppOptions"));

            if (appcfg.UseChromely) {
                // This is called when we run with Chromely enabled (true by default)
                // Setup the Web Host Builder to listen on a port
                // But only do this when the parent process is launched initially
                // not when Chromely launches itself as a child process
                var proctype = ClientAppUtils.GetProcessType(args);
                if (proctype == ProcessType.Browser) {
                    CreateWebHostBuilder(config, args).UseUrls(appcfg.Urls).Build().Start();
                }
                ChromelyBootstrap(args, appcfg);
            }
            else {
                // This is called when we just run as a website without Chromely
                CreateWebHostBuilder(config, args).UseUrls(appcfg.Urls).Build().Run();
            }
        }

        /// <summary> Creates web host builder. </summary>
        /// <param name="config"> Configuration settings</param>
        /// <param name="args"> An array of command-line argument strings. </param>
        /// <returns> The new web host builder. </returns>
        private static IWebHostBuilder CreateWebHostBuilder(IConfigurationRoot config, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Startup>();

        /// <summary> Bootstrap the Chromely browser. </summary>
        private static void ChromelyBootstrap(string[] args, AppOptions appopts) {
            var config = DefaultConfiguration.CreateForRuntimePlatform();
            config.WindowOptions.Title = appopts.ChromelyFrameTitle;
            config.StartUrl = appopts.Urls.First();
            config.WindowOptions.WindowFrameless = appopts.ChromelyFrameless;

            var dragzones = config.WindowOptions.FramelessOption.DragZones;
            dragzones.Clear();
            dragzones.Add(new DragZoneConfiguration(32, 0, 120, 100));
            //config.WindowOptions.FramelessOption.DblClick = ChromelyWindowService.DoubleClickDrag_Handler;

            config.DebuggingMode = appopts.ChromelyDebuggingMode;

            AppBuilder
                .Create()
                .UseConfiguration<DefaultConfiguration>(config)
                .UseApp<CustomChromelyApp>()
                .Build()
                .Run(args);
        }
    }
}
