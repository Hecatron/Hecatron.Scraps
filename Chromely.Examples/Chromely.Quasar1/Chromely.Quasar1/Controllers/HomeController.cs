using Chromely.Quasar1.Models.Config.Local;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Chromely.Quasar1.Controllers {

    /// <summary> Home Controller. </summary>
    public class HomeController : Controller {

        private AppOptions _appOptions;

        /// <summary> Constructor. </summary>
        /// <param name="appopts"> The Application Options. </param>
        public HomeController(IOptions<AppOptions> appopts) {
            _appOptions = appopts.Value;
        }

        /// <summary> Index Page. </summary>
        /// <returns> The view. </returns>
        [AllowAnonymous]
        public IActionResult Index() {
            return View();
        }

        /// <summary> Error Page. </summary>
        /// <returns> The view. </returns>
        [AllowAnonymous]
        public IActionResult Error() {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        /// <summary> Can be used for the client app to determine if we're running under Chromely. </summary>
        /// <returns> True if in a chromely frame, false if not. </returns>
        [AllowAnonymous]
        [Route("api/IsChromely")]
        public IActionResult IsChromely() {
            //return Ok(true);
            return Ok(_appOptions.UseChromely);
        }
    }
}
