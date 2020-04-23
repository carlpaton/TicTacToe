using Microsoft.AspNetCore.Mvc;
using GameUI.Models;

namespace GameUI.Controllers
{
    public class GameController : Controller
    {
        private readonly DummyContext _context;

        public GameController(DummyContext context)
        {
            _context = context;
        }

        // GET: Game
        public IActionResult Index()
        {
            var gameViewModel = new GameViewModel
            {
                Square1 = "X",
                Square2 = "O",
                Square3 = "O",
                Square4 = "X",
                Square5 = "X",
                Square6 = "O",
                Square7 = "O",
                Square8 = "O",
                Square9 = "X"
            };

            return View(gameViewModel);
        }
    }
}
