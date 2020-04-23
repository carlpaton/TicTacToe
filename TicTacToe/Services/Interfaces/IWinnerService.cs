using System.Collections.Generic;
using TicTacToe.Services.Models;

namespace TicTacToe.Services.Interfaces
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
