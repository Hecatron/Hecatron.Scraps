using Chromely.Core.Host;

namespace Chromely.Quasar1.Providers.Chromely {

    /// <summary> A service for actioning window changes. </summary>
    public class ChromelyWindowService : IChromelyWindowService {

        /// <summary> Closes the main window.  </summary>
        public void Close() {
            var app = CustomChromelyApp.SingleTonInstance;
            app?.Window.Close();
        }

        /// <summary> Maximizes the window. </summary>
        /// <returns> True if it succeeds. </returns>
        public bool Maximize() {
            var app = CustomChromelyApp.SingleTonInstance;
            if (app != null)
                return app.Window.NativeHost.SetWindowState(WindowState.Maximize);
            return false;
        }

        /// <summary> Minimizes the window.  </summary>
        /// <returns> True if it succeeds. </returns>
        public bool Minimize() {
            var app = CustomChromelyApp.SingleTonInstance;
            if (app != null)
                return app.Window.NativeHost.SetWindowState(WindowState.Minimize);
            return false;
        }

        /// <summary> Restores the window.  </summary>
        /// <returns> True if succeeds. </returns>
        public bool Restore() {
            var app = CustomChromelyApp.SingleTonInstance;
            if (app != null)
                return app.Window.NativeHost.SetWindowState(WindowState.Normal);
            return false;
        }

        /// <summary> Handle Double click on drag bar events. </summary>
        public static void DoubleClickDrag_Handler(IChromelyNativeHost nativeHost) {
            var state = nativeHost.GetWindowState();
            if (state == WindowState.Maximize) {
                nativeHost.SetWindowState(WindowState.Normal);
            }
            else {
                nativeHost.SetWindowState(WindowState.Maximize);
            }
        }
    }
}
