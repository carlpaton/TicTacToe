using Microsoft.AspNetCore.Mvc;
using GameUI.Models;
using GameEngine.Services.Interfaces;
using GameEngine;
using System;
using static GameEngine.PlayerEnum;
using GameEngine.Exceptions;
using System.Net;

namespace GameUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        private readonly IGame _game;
        private readonly IWinnerService _winnerService;
        private readonly IGameLogService _gameLogService;

        public ApiGameController(IGame game, IWinnerService winnerService, IGameLogService gameLogService)
        {
            _game = game;
            _winnerService = winnerService;
            _gameLogService = gameLogService;
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
                apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Player {_game.GetCurrentPlayer()} chose square number {apiGameMoveModel.SquareNumber}");
                                
                var winnerModel = _winnerService.GetWinner(_game.GetCurrentBoard());
                if (winnerModel.HasWon) 
                {
                    apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Winner! Player {winnerModel.Player} wins!");
                } 
                else 
                {
                    // AI level 1
                    _game.SwapCurrentPlayer();
                    Enum.TryParse(_game.GetCurrentPlayer(), out Player playerComputer);
                    var positionComputer = _game.SetRandomPosition(playerComputer);
                    apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Computer {_game.GetCurrentPlayer()} chose square number {positionComputer}");
                    _game.SwapCurrentPlayer();

                    // TODO AI level 2,3        
                }

                apiGameMoveResponseModel.Status = HttpStatusCode.OK.ToString();
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
