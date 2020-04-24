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
            return View(new GameViewModel());
        }
    }
}
