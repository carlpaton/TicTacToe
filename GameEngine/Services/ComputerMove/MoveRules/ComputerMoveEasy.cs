using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Services.ComputerMove.MoveRules
{
    public class ComputerMoveEasy : IComputerMove
    {
        private readonly ILogger<ComputerMoveEasy> _logger;

        public ComputerMoveEasy(ILogger<ComputerMoveEasy> logger)
        {
            _logger = logger;
        }

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
        public int SetPosition(PlayerEnum.Player playerComputer, Dictionary<int, string> board, IEnumerable<IComputerMove> fallback)
        {
            for (int i = 1; i <= 9; i++)
            {
                var random = new Random().Next(i, 9);
                if (board.TryGetValue(random, out string s))
                {
                    if (s.Equals(string.Empty))
                    {
                        board[random] = playerComputer.ToString();
                        _logger.LogTrace($"Square={random}");
                        return random;
                    }
                }
            }

            if (board.Select(x => x.Value == string.Empty).Where(x => x == true).Any())
                throw new Exception("Board SetPosition failed.");
            else
                return (int)GameStatus.GameDraw;

        }
    }
}
