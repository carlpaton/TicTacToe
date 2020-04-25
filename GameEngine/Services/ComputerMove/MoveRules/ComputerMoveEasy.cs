using System;
using System.Collections.Generic;

namespace GameEngine.Services.ComputerMove.MoveRules
{
    public class ComputerMoveEasy : IComputerMove
    {
        public bool IsMatch(ComputerLevel computerLevel)
        {
            return computerLevel == ComputerLevel.Easy;
        }

        /// <summary>
        /// Sets a random position on the board for the given player and returns the position it was set at.
        /// </summary>
        /// <param name="playerComputer"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public int SetPosition(PlayerEnum.Player playerComputer, Dictionary<int, string> board)
        {
            for (int i = 1; i <= 9; i++)
            {
                var random = new Random().Next(i, 9);
                if (board.TryGetValue(random, out string s))
                {
                    if (s.Equals(string.Empty))
                    {
                        board[random] = playerComputer.ToString();
                        return random;
                    }
                }
            }
            throw new Exception("Board set random failed.");
        }
    }
}
