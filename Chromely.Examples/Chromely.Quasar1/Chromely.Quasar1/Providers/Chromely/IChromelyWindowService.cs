namespace Chromely.Quasar1.Providers.Chromely {

    /// <summary> Interface for chromely window service. </summary>
    public interface IChromelyWindowService {

        /// <summary> Closes the main window.  </summary>
        void Close();

        /// <summary> Maximizes the main window.  </summary>
        /// <returns> True if it succeeds. </returns>
        bool Maximize();

        /// <summary> Minimizes the main window.  </summary>
        /// <returns> True if it succeeds. </returns>
        bool Minimize();

        /// <summary> Restores the main window.  </summary>
        /// <returns> True if it succeeds. </returns>
        bool Restore();

    }
}
