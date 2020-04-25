using Microsoft.AspNetCore.Mvc;
using GameUI.Models;
using GameEngine.Services.Interfaces;
using GameEngine;
using System;
using static GameEngine.PlayerEnum;
using GameEngine.Exceptions;
using System.Net;
using GameEngine.Services.ComputerMove;
using System.Collections.Generic;
using System.Linq;

namespace GameUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        private readonly IGame _game;
        private readonly IWinnerService _winnerService;
        private readonly IGameLogService _gameLogService;
        private readonly IEnumerable<IComputerMove> _computerMoves;

        public ApiGameController(IGame game, IWinnerService winnerService, IGameLogService gameLogService, IEnumerable<IComputerMove> computerMoves)
        {
            _game = game;
            _winnerService = winnerService;
            _gameLogService = gameLogService;
            _computerMoves = computerMoves;
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
                    _game.SwapCurrentPlayer();
                    Enum.TryParse(_game.GetCurrentPlayer(), out Player playerComputer);

                    // AI level
                    var positionComputer = _computerMoves
                        .First(rule => rule
                        .IsMatch(_game.ComputerLevel))
                        .SetPosition(playerComputer, _game.GetCurrentBoard());

                    apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Computer {_game.GetCurrentPlayer()} chose square number {positionComputer}");
                    apiGameMoveResponseModel.Computer.Player = _game.GetCurrentPlayer();
                    apiGameMoveResponseModel.Computer.Square = positionComputer;
                    _game.SwapCurrentPlayer();
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
