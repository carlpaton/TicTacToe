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

        public int SetPosition(Player playerComputer, Dictionary<int, string> board)
        {
            /* BOARD SQUARES
             * 1, 2, 3
             * 4, 5, 6
             * 7, 8, 9
             */

            var playersList = new List<Player>() 
            {
                Player.O,
                Player.X
            };

            /* Logic to determine potential winning rows:
             * 1. check vertically top down
             * 2. check horizontally left right
             * 3. check at 45 degrees top-left to bottom-right
             * 4. check at 135 degrees top-right to bottom-left
             */

            var verticalSquareLists = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 }
            };

            // Determine if there are potential winning rows (For the computer to win)

            // Determine if there are potential winning rows (For the human to win)

            foreach (var list in verticalSquareLists)
            {
                var playersFound = new List<PlayersFound>();
                for (int i = 0; i <= list.Count; i++)
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

                            var openSpace = list[0];
                        }
                    }        
                }
            }

            // no potential winning rows found
            return -1;
        }

        class PlayersFound 
        {
            public int Square { get; set; }
            public string Player { get; set; }
        }
    }
}
