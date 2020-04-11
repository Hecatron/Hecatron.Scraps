using System;
using System.Runtime.InteropServices;
using Chromely.Core.Host;
using static Chromely.Native.WinNativeMethods;

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
            var ret = false;
            if (app != null)
                ret = ShowWindow(app.WindowHandle, ShowWindowCommand.SW_SHOWMAXIMIZED);
            return ret;
        }

        /// <summary> Minimizes the window.  </summary>
        /// <returns> True if it succeeds. </returns>
        public bool Minimize() {
            var app = CustomChromelyApp.SingleTonInstance;
            var ret = false;
            if (app != null)
                ret = ShowWindow(app.WindowHandle, ShowWindowCommand.SW_SHOWMINIMIZED);
            return ret;
        }

        /// <summary> Restores the window.  </summary>
        /// <returns> True if succeeds. </returns>
        public bool Restore() {
            var app = CustomChromelyApp.SingleTonInstance;
            var ret = false;
            if (app != null)
                ret = ShowWindow(app.WindowHandle, ShowWindowCommand.SW_RESTORE);
            return ret;
        }

        /// <summary> Handle Double click on drag bar events. </summary>
        public static void DoubleClickDrag_Handler(IChromelyNativeHost nativeHost) {
            var maximised = IsWindowMaximized(nativeHost.Handle);
            var app = CustomChromelyApp.SingleTonInstance;
            if (maximised) {
                ShowWindow(app.WindowHandle, ShowWindowCommand.SW_RESTORE);
            }
            else {
                ShowWindow(app.WindowHandle, ShowWindowCommand.SW_SHOWMAXIMIZED);
            }
        }

        private static bool IsWindowMaximized(IntPtr hWnd) {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.Length = Marshal.SizeOf(placement);
            GetWindowPlacement(hWnd, ref placement);
            return placement.ShowCmd == ShowWindowCommands.Maximized;
        }

    }
}
