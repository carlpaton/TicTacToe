using Microsoft.AspNetCore.Mvc;
using GameUI.Models;
using GameEngine;
using GameEngine.Services.Interfaces;

namespace GameUI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGame _game;
        private readonly IGameLogService _gameLogService;

        public GameController(IGame game, IGameLogService gameLogService)
        {
            _game = game;
            _gameLogService = gameLogService;
        }

        public IActionResult Index()
        {
            return View(GetGameViewModel());
        }

        public IActionResult Reset()
        {
            _gameLogService.Reset();
            _gameLogService.Append("Game reset");
            _game.ResetBoard();
            return RedirectToAction("Index");
        }

        private GameViewModel GetGameViewModel() 
        {
            return new GameViewModel()
            {
                CurrentPlayer = _game.GetCurrentPlayer(),

                CurrentGameLog = _gameLogService.GetLog(),

                Square1 = _game.GetPositionValue(1),
                Square2 = _game.GetPositionValue(2),
                Square3 = _game.GetPositionValue(3),
                Square4 = _game.GetPositionValue(4),
                Square5 = _game.GetPositionValue(5),
                Square6 = _game.GetPositionValue(6),
                Square7 = _game.GetPositionValue(7),
                Square8 = _game.GetPositionValue(8),
                Square9 = _game.GetPositionValue(9),
            };
        }
    }
}
