using Chromely.Quasar1.Providers.Chromely;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chromely.Quasar1.Controllers.Chromely {

    /// <summary> A Controller for handling chromely window changes. </summary>
    public class WindowController : Controller {

        /// <summary> Gets or sets the window service. </summary>
        /// <value> The window service. </value>
        public IChromelyWindowService WindowService { get; set; }

        /// <summary> Constructor. </summary>
        /// <param name="windowservice"> The windowservice. </param>
        public WindowController(IChromelyWindowService windowservice) {
            WindowService = windowservice;
        }

        /// <summary> Close the main window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/close")]
        public IActionResult Close() {
            WindowService.Close();
            return Ok();
        }

        /// <summary> Maximizes the window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/maximize")]
        public IActionResult Maximize() {
            var ret = WindowService.Maximize();
            return Ok(ret);
        }

        /// <summary> Minimizes the window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/minimize")]
        public IActionResult Minimize() {
            var ret = WindowService.Minimize();
            return Ok(ret);
        }

        /// <summary> Restores the window. </summary>
        /// <returns> An IActionResult. </returns>
        [AllowAnonymous]
        [Route("/chromely/window/restore")]
        public IActionResult Restore() {
            var ret = WindowService.Restore();
            return Ok(ret);
        }
    }
}
