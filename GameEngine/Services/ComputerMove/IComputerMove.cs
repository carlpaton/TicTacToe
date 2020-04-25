using System.Collections.Generic;
using static GameEngine.PlayerEnum;

namespace GameEngine.Services.ComputerMove
{
    public interface IComputerMove
    {
        bool IsMatch(ComputerLevel computerLevel);

        int SetPosition(Player playerComputer, Dictionary<int, string> board);
    }
}
