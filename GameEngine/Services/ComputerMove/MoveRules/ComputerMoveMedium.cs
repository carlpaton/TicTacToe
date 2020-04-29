using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Services.ComputerMove.MoveRules
{
    public class ComputerMoveMedium : IComputerMove
    {
        public bool IsMatch(ComputerLevel computerLevel)
        {
            return computerLevel == ComputerLevel.Medium;
        }

        public int SetPosition(PlayerEnum.Player playerComputer, Dictionary<int, string> board, IEnumerable<IComputerMove> fallback)
        {
            /* BOARD SQUARES
             * 1, 2, 3
             * 4, 5, 6
             * 7, 8, 9
             */

            // high value board squares that allow x number of rows through/from them to win
            // 5       - it allows for 4 rows
            // 1,3,7,9 - they allow for 3 rows
            // 2,4,6,8 - that remain only allow for 2 rows

            var highValueSquareLists = new List<List<int>>() 
            {
                new List<int>() { 5 },
                new List<int>() { 1, 3, 7, 9 },
                new List<int>() { 2, 4, 6, 8 }
            };

            foreach (var highValueSquares in highValueSquareLists)
            {
                var randomHighValueSquares = highValueSquares.OrderBy(a => new Random().Next()).ToList();
                foreach (var square in randomHighValueSquares)
                {
                    if (board.TryGetValue(square, out string squareValue)) 
                    {
                        if (squareValue.Equals(string.Empty))
                        {
                            board[square] = playerComputer.ToString();
                            return square;
                        }
                    }
                }              
            }

            // no potential winning rows, fallback to easy
            return fallback
                .First(rule => rule
                .IsMatch(ComputerLevel.Easy))
                .SetPosition(playerComputer, board, fallback);
        }
    }
}
