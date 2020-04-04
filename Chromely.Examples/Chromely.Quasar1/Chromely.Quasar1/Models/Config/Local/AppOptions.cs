namespace Chromely.Quasar1.Models.Config.Local {

    /// <summary> General purpose applucation options. </summary>
    public class AppOptions {

        /// <summary> Title for the Frame window Chromely creates. </summary>
        public readonly string ChromelyFrameTitle = "App Frame Title";

        /// <summary> When running under Chromely decide if to make the window frameless. </summary>
        /// <value> True if framesless required, false if not. </value>
        public bool ChromelyFrameless { get; set; } = false;

        /// <summary> When running under Chromely if to allow devtools </summary>
        /// <value> True if chromely debugging mode, false if not. </value>
        public bool ChromelyDebuggingMode { get; set; } = false;

        /// <summary> A list of url's to use. </summary>
        /// <value> List of url's to use. </value>
        public string[] Urls { get; set; }

        /// <summary> If Chromely is to be used (run in a window instead of a website). </summary>
        /// <value> True if use chromely, false if not. </value>
        public bool UseChromely { get; set; }

    }
}
