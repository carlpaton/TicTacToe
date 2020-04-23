using static TicTacToe.PlayerEnum;

namespace TicTacToe.Services.Models
{
    public class WinnerModel
    {
        public bool HasWon { get; set; }
        public Player Player { get; set; }
    }
}
