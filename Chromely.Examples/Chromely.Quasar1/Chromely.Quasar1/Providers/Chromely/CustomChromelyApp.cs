using System;
using Chromely;
using Chromely.Core;

namespace Chromely.Quasar1.Providers.Chromely {

    /// <summary>
    ///     This is a custom setup class for chromely It's job is to make the Chromely App visible
    ///     via the static SingleTonInstance property this is due to Chromley Services / Controllers
    ///     not being visible when using the ASP.Net controllers.
    /// </summary>
    public class CustomChromelyApp : ChromelyBasicApp {

        /// <summary> Only one of these class's should be created by Chromely's AppBuilder. </summary>
        /// <value> The singleton CustomChromelyApp instance. </value>
        public static CustomChromelyApp SingleTonInstance { get; set; }

        /// <summary> Make the window Handle available. </summary>
        /// <value> The window handle. </value>
        public IntPtr WindowHandle => Window?.Handle ?? IntPtr.Zero;


        /// <summary> Configure IoC container contents. </summary>
        /// <param name="container"> . </param>
        public override void Configure(IChromelyContainer container) {
            base.Configure(container);
            // Make the singleton instance visible
            SingleTonInstance = this;
        }
    }
}
