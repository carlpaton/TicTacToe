using Microsoft.AspNetCore.Mvc;
using GameUI.Models;
using GameEngine.Services.Interfaces;
using GameEngine;
using System;
using static GameEngine.PlayerEnum;
using GameEngine.Exceptions;

namespace GameUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        private readonly IGame _game;
        private readonly IWinnerService _winnerService;

        public ApiGameController(IGame game, IWinnerService winnerService)
        {
            _game = game;
            _winnerService = winnerService;
        }

        // POST: api/ApiGame
        [HttpPost]
        public IActionResult Post(ApiGameMoveModel apiGameMoveModel)
        {
            var apiGameMoveResponseModel = new ApiGameMoveResponseModel();

            try 
            {
                Enum.TryParse(_game.GetCurrentPlayer(), out Player player);
                _game.SetPosition(player, int.Parse(apiGameMoveModel.SquareNumber));
                _game.SwapCurrentPlayer();

                apiGameMoveResponseModel.Status = "ok";
                apiGameMoveResponseModel.CurrentPlayer = _game.GetCurrentPlayer();
            }
            catch (PositionException exp) 
            {
                var message = exp.Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new JsonResult(apiGameMoveResponseModel);
        }
    }
}
