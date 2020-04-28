using GameEngine.Exceptions;
using GameEngine.Services.ComputerMove;
using System.Collections.Generic;
using static GameEngine.PlayerEnum;

namespace GameEngine
{
    public class Game : IGame
    { 
        // TODO ~ this member being public is just a quick hack while buulding `ComputerMove` rules
        // the UI will need to be able to set this
        public ComputerLevel ComputerLevel { get; set; }

        // TODO ~ this is also a hack, this state should be controlled by well defined methods
        public bool GameOver { get; set; }

        private string _currentPlayer = Player.X.ToString(); // X is now the human forever more, this is not great as this is then assumed in the `ComputerMoveX` classes
        private Dictionary<int, string> _board;       

        public Game() 
        {
            ComputerLevel = ComputerLevel.Medium;
            GameOver = false;
            ResetBoard();
        }

        public void SwapCurrentPlayer()
        {
            if (_currentPlayer.Equals(Player.X.ToString()))
                _currentPlayer = Player.O.ToString();
            else
                _currentPlayer = Player.X.ToString();
        }

        public void ResetBoard()
        {
            _board = new Dictionary<int, string>();
            for (int i = 1; i <= 9; i++)
            {
                _board.Add(i, string.Empty);
            }
        }

        public void SetPosition(Player player, int position) 
        {
            if (position <= 0)
                throw new PositionException("Position selection too small.");

            if (position >= 10)
                throw new PositionException("Position selection too large.");

            if (_board.TryGetValue(position, out string s))
            {
                if (s.Equals(string.Empty))
                    _board[position] = player.ToString();
                else
                    throw new PositionException("Position already taken.");
            }
        }

        public string GetPositionValue(int position)
        {
            if (_board.TryGetValue(position, out string s))
                return s;

            return string.Empty;
        }

        public Dictionary<int, string> GetCurrentBoard() 
        {
            return _board;
        }

        public string GetCurrentPlayer()
        {
            return _currentPlayer;
        }
    }
}
