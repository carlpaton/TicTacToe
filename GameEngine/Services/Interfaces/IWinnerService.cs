using System.Collections.Generic;
using GameEngine.Services.Models;

namespace GameEngine.Services.Interfaces
{
    public interface IWinnerService
    {
        /// <summary>
        /// Checks the given game board to see if there is a winner.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        WinnerModel GetWinner(Dictionary<int, string> board);
    }
}
