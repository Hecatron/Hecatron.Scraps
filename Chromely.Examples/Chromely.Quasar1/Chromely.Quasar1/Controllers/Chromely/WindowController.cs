using Chromely.Quasar1.Providers.Chromely;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Chromely.Native.WinNativeMethods;

namespace Chromely.Quasar1.Controllers.Chromely {

    /// <summary> A Controller for handling chromely window changes. </summary>
    public class WindowController : Controller {

        /// <summary> Close the main window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/close")]
        public IActionResult Close() {
            var app = CustomChromelyApp.SingleTonInstance;
            app?.Window.Close();
            return Ok();
        }

        /// <summary> Maximizes the window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/maximize")]
        public IActionResult Maximize() {
            var app = CustomChromelyApp.SingleTonInstance;
            var ret = false;
            if (app != null)
                ret = ShowWindow(app.WindowHandle, ShowWindowCommand.SW_SHOWMAXIMIZED);
            return Ok(ret);
        }

        /// <summary> Minimizes the window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/minimize")]
        public IActionResult Minimize() {
            var app = CustomChromelyApp.SingleTonInstance;
            var ret = false;
            if (app != null)
                ret = ShowWindow(app.WindowHandle, ShowWindowCommand.SW_SHOWMINIMIZED);
            return Ok(ret);
        }

        /// <summary> Restores the window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/restore")]
        public IActionResult Restore() {
            var app = CustomChromelyApp.SingleTonInstance;
            var ret = false;
            if (app != null)
                ret = ShowWindow(app.WindowHandle, ShowWindowCommand.SW_RESTORE);
            return Ok(ret);
        }
    }
}
