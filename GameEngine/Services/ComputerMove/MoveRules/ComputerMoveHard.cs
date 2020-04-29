using System.Collections.Generic;
using System.Linq;
using static GameEngine.PlayerEnum;

namespace GameEngine.Services.ComputerMove.MoveRules
{
    public class ComputerMoveHard : IComputerMove
    {
        public bool IsMatch(ComputerLevel computerLevel)
        {
            return computerLevel == ComputerLevel.Hard;
        }

        public int SetPosition(Player playerComputer, Dictionary<int, string> board, IEnumerable<IComputerMove> fallback)
        {
            // Determine if there are potential winning rows (For the computer to win)
            // Determine if there are potential winning rows (For the human to win)

            /* BOARD SQUARES
             * 1, 2, 3
             * 4, 5, 6
             * 7, 8, 9
             */

            var playersList = new List<Player>() 
            {
                Player.X, // Order is important as X is the human so check if the human can win first, not great to rely on order like this, consider this as an input. downside is the other `ComputerMoveX` classes will then need to take this param and probably not need it. Meh.
                Player.O
            };

            var squareLists = new List<List<int>>()
            {
                // check horizontally
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 },

                // check vertically
                new List<int>() { 1, 4, 7 },
                new List<int>() { 2, 5, 8 },
                new List<int>() { 3, 6, 9 },

                // check at 45 degrees top-left to bottom-right
                new List<int>() { 1, 5, 9 },

                // check at 135 degrees top-right to bottom-left
                new List<int>() { 3, 5, 7 }
            };

            foreach (var list in squareLists)
            {
                var playersFound = new List<PlayersFound>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (board.TryGetValue(list[i], out string squareValue)) 
                    {
                        if (!squareValue.Equals(string.Empty))
                        {
                            playersFound.Add(new PlayersFound() {
                                Player = squareValue,
                                Square = list[i]
                            });
                        }
                    }
                }
                if (playersFound.Count == 2) 
                {
                    foreach (var player in playersList)
                    {
                        var playerCount = playersFound
                            .Count(x => x.Player == player.ToString());

                        if (playerCount == 2) 
                        {
                            list.Remove(playersFound[0].Square);
                            list.Remove(playersFound[1].Square);

                            // this will either block the human or win the game for the computer
                            var openSpace = list[0];
                            board[openSpace] = playerComputer.ToString();

                            return openSpace; 
                        }
                    }        
                }
            }

            // no potential winning rows, fallback to medium
            return fallback
                .First(rule => rule
                .IsMatch(ComputerLevel.Medium))
                .SetPosition(playerComputer, board, fallback);
        }

        class PlayersFound 
        {
            public int Square { get; set; }
            public string Player { get; set; }
        }
    }
}
