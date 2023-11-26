namespace Amgine.CLI.Handlers
{
    /// <summary>
    /// Abstraction of a handler for command line options.
    /// </summary>
    internal interface IOptionHandler
    {
        /// <summary>
        /// Handles the provided command line options.
        /// </summary>
        void Handle();
    }
}