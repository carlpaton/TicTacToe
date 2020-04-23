using static GameEngine.PlayerEnum;

namespace GameEngine.Services.Models
{
    public class WinnerModel
    {
        public bool HasWon { get; set; }
        public Player Player { get; set; }
    }
}
