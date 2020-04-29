using System.Collections.Generic;
using static GameEngine.PlayerEnum;

namespace GameEngine.Services.ComputerMove
{
    public interface IComputerMove
    {
        /// <summary>
        /// This is the computer level the move implementation will match to
        /// </summary>
        /// <param name="computerLevel"></param>
        /// <returns></returns>
        bool IsMatch(ComputerLevel computerLevel);

        /// <summary>
        /// Sets the board position (by reference) for the given player
        /// Fallback to lower level computer move if nothing for this instance.
        /// </summary>
        /// <param name="playerComputer"></param>
        /// <param name="board"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        int SetPosition(Player playerComputer, Dictionary<int, string> board, IEnumerable<IComputerMove> fallback);
    }
}
