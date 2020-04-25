using System;
using System.Collections.Generic;

namespace GameEngine.Services.ComputerMove.MoveRules
{
    public class ComputerMoveMedium : IComputerMove
    {
        public bool IsMatch(ComputerLevel computerLevel)
        {
            return computerLevel == ComputerLevel.Medium;
        }

        public int SetPosition(PlayerEnum.Player playerComputer, Dictionary<int, string> board)
        {
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
                var checkedList = CheckHighValueSquares(highValueSquares, board, playerComputer);
                if (checkedList != -1) 
                {
                    board[checkedList] = playerComputer.ToString();
                    return checkedList;
                }
            }

            throw new Exception("Board SetPosition failed.");
        }

        private int CheckHighValueSquares(List<int> highValueSquares, Dictionary<int, string> board, PlayerEnum.Player playerComputer) 
        {
            for (int i = 1; i <= highValueSquares.Count; i++)
            {
                var random = new Random().Next(i, highValueSquares.Count);
                var randomTranslated = RandomTranslated(random, highValueSquares);
                if (board.TryGetValue(randomTranslated, out string squareFourRows))
                {
                    if (squareFourRows.Equals(string.Empty))
                    {
                        board[randomTranslated] = playerComputer.ToString();
                        return randomTranslated;
                    }
                }
            }
            return -1;
        }

        private int RandomTranslated(int random, List<int> actualSquares)
        {
            var zeroBased = random - 1;
            return actualSquares[zeroBased];
        }
    }
}
