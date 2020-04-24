using Microsoft.AspNetCore.Mvc;
using GameUI.Models;

namespace GameUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        private readonly DummyContext _context;

        public ApiGameController(DummyContext context)
        {
            _context = context;
        }

        // POST: api/ApiGame
        [HttpPost]
        public IActionResult Post(ApiGameMoveModel apiGameMoveModel)
        {
            var response = new ApiGameMoveModel
            {
                Id = 42,
                Player = "player that was updated"
            };
            return new JsonResult(response);
        }
    }
}
