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
            if (_game.GameOver) 
            {
                apiGameMoveResponseModel.Status = GameStatus
                    .GameOver
                    .ToString()
                    .ToUpper();

                return new JsonResult(apiGameMoveResponseModel);
            }

            try 
            {
                Enum.TryParse(_game.GetCurrentPlayer(), out Player player);
                _game.SetPosition(player, int.Parse(apiGameMoveModel.SquareNumber));
                apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Player {_game.GetCurrentPlayer()} chose square number {apiGameMoveModel.SquareNumber}");
                                
                var winnerModel = _winnerService.GetWinner(_game.GetCurrentBoard());
                if (winnerModel.HasWon) 
                {
                    _game.GameOver = true;
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
                        .SetPosition(playerComputer, _game.GetCurrentBoard(), _computerMoves);

                    if (positionComputer > 0)
                        apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Computer {_game.GetCurrentPlayer()} chose square number {positionComputer}");
                    
                    apiGameMoveResponseModel.Computer.Player = _game.GetCurrentPlayer();
                    apiGameMoveResponseModel.Computer.Square = positionComputer;

                    if (positionComputer.Equals((int)GameStatus.GameDraw))
                    {
                        apiGameMoveResponseModel.CurrentPlayer = GameStatus.GameDraw.ToString();
                        apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append(GameStatus.GameDraw.ToString());
                        apiGameMoveResponseModel.Status = GameStatus
                            .GameDraw
                            .ToString()
                            .ToUpper();

                        return new JsonResult(apiGameMoveResponseModel);
                    }

                    var computerHasWon = _winnerService.GetWinner(_game.GetCurrentBoard());
                    if (computerHasWon.HasWon)
                    {
                        _game.GameOver = true;
                        apiGameMoveResponseModel.CurrentGameLog = _gameLogService.Append($"Winner! Computer {computerHasWon.Player} wins!");
                    }
                    else
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
