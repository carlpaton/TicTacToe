using GameEngine.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GameEngine.Services
{
    public class GameLogService : IGameLogService
    {
        private List<string> _log = new List<string>();

        public string Append(string message)
        {
            _log.Add(message);
            return GetLog();
        }

        public string Reset()
        {
            _log = new List<string>();
            return GetLog();
        }

        public string GetLog() 
        {
            var arr = _log.ToArray();
            Array.Reverse(arr);

            return string.Join(
                "<br>",
                arr);
        }
    }
}
