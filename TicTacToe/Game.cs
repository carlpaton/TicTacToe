using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        private Dictionary<int, string> _board;
        public enum Player { X, O };

        public Game() 
        {
            ResetBoard();
        }

        public void ResetBoard()
        {
            _board = new Dictionary<int, string>();
            for (int i = 1; i <= 9; i++)
            {
                _board.Add(i, string.Empty);
            }
        }

        public int SetRandomPosition(Player player) 
        {
            for (int i = 1; i <= 9; i++)
            {
                var random = new Random().Next(i, 9);
                if (_board.TryGetValue(random, out string s))
                {
                    if (s.Equals(string.Empty)) 
                    {
                        _board[random] = player.ToString();
                        return random;
                    }                        
                }
            }
            throw new Exception("Board set random failed.");
        }

        public void SetPosition(Player player, int position) 
        {
            // TODO - custom exception

            if (position <= 0)
                throw new Exception("Position selection too small.");

            if (position >= 10)
                throw new Exception("Position selection too large.");

            if (_board.TryGetValue(position, out string s))
            {
                if (s.Equals(string.Empty))
                    _board[position] = player.ToString();
                else
                    throw new Exception("Position already taken.");
            }
        }

        public string GetPositionValue(int position)
        {
            if (_board.TryGetValue(position, out string s))
                return s;

            return string.Empty;
        }

        public string GetWinner() 
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
