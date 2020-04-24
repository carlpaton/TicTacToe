using Microsoft.AspNetCore.Mvc;
using GameUI.Models;
using GameEngine;

namespace GameUI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGame _game;

        public GameController(IGame game)
        {
            _game = game;
        }

        public IActionResult Index()
        {
            return View(GetGameViewModel());
        }

        public IActionResult Reset()
        {
            _game.ResetBoard();
            return RedirectToAction("Index");
        }

        private GameViewModel GetGameViewModel() 
        {
            return new GameViewModel()
            {
                CurrentPlayer = _game.GetCurrentPlayer(),

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
