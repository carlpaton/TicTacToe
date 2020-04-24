namespace GameEngine.Services.Interfaces
{
    public interface IGameLogService
    {
        /// <summary>
        /// Appends `message` to the log. Returns the new log.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        string Append(string message);

        /// <summary>
        /// Resets the current log. Returns the new empty log.
        /// </summary>
        /// <returns></returns>
        string Reset();

        /// <summary>
        /// Returns the current log, ordered with the most recent logs first.
        /// </summary>
        /// <returns></returns>
        string GetLog();
    }
}
