using System.Collections.Generic;
using static GameEngine.PlayerEnum;

namespace GameEngine
{
    public interface IGame
    {
        /// <summary>
        /// Resets the board to have no squares selected. This would be called on Game init and at the end of a round.
        /// </summary>
        void ResetBoard();

        /// <summary>
        /// Sets a random position on the board for the given player and returns the position it was set at.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        int SetRandomPosition(Player player);

        /// <summary>
        /// Sets the position for the given player, exceptions are thrown for invalid and taken positions.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="position"></param>
        void SetPosition(Player player, int position);

        /// <summary>
        /// Gets the value of the given position. The default value of `string.empty` is returned if nothing is found.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        string GetPositionValue(int position);

        /// <summary>
        /// Returns the current board.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetCurrentBoard();

        /// <summary>
        /// Swaps the current player. Example: X becomes O and vice versa.
        /// </summary>
        void SwapCurrentPlayer();

        /// <summary>
        /// Returns the current player stored in game state.
        /// </summary>
        /// <returns></returns>
        string GetCurrentPlayer();
    }
}
