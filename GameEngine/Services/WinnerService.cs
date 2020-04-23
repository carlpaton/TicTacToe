using System;
using System.Collections.Generic;
using GameEngine.Services.Interfaces;
using GameEngine.Services.Models;
using static GameEngine.PlayerEnum;

namespace GameEngine.Services
{
    public class WinnerService : IWinnerService
    {
        public WinnerModel GetWinner(Dictionary<int, string> board)
        {
            var winner = new WinnerModel();
            var squaresToCheck = new List<int[]>
            {
                // Horizontal
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },

                // Vertical
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 3, 6, 9 },

                // Diagonal
                new int[] { 1, 5, 9 },
                new int[] { 7, 5, 3 }
            };

            foreach (var squares in squaresToCheck)
            {
                winner = CheckBoardForWinner(squares, board);
                if (winner.HasWon)
                    return winner;
            }

            return winner;
        }

        private WinnerModel CheckBoardForWinner(int[] squares, Dictionary<int, string> board)
        {
            var winner = new WinnerModel();

            var a = board[squares[0]];
            var b = board[squares[1]];
            var c = board[squares[2]];

            if (a.Equals(string.Empty))
                return winner;

            if (a == b && a == c)
            {
                winner.HasWon = true;

                Enum.TryParse(board[squares[0]], out Player player);
                winner.Player = player;
            }

            return winner;
        }
    }
}
