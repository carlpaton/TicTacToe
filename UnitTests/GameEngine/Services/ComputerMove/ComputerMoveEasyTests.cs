using GameEngine;
using GameEngine.Services.ComputerMove;
using GameEngine.Services.ComputerMove.MoveRules;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using static GameEngine.PlayerEnum;
using Microsoft.Extensions.Logging;

namespace UnitTests.GameEngine.Services.ComputerMove
{
    public class ComputerMoveEasyTests
    {
        [TestCase(ComputerLevel.Easy, true)]
        [TestCase(ComputerLevel.Medium, false)]
        [TestCase(ComputerLevel.Hard, false)]
        public void IsMatch_GivenComputerLevel_MatchesGivenExpected(ComputerLevel computerLevel, bool expected)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveEasy>>();
            IComputerMove classUnderTest = new ComputerMoveEasy(mockLogger.Object);

            // Act
            var actual = classUnderTest.IsMatch(computerLevel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetPosition_GivenValidDataAndTheBoardHasOpenSquares_SetsBoardPosition()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveEasy>>();
            IComputerMove classUnderTest = new ComputerMoveEasy(mockLogger.Object);
            var game = new Game();
            var player = Player.O;
            var mockFallback = new Mock<IEnumerable<IComputerMove>>();

            // Act
            var position = classUnderTest.SetPosition(player, game.GetCurrentBoard(), mockFallback.Object);
            var expected = game.GetPositionValue(position);

            // Assert
            Assert.AreEqual(expected, player.ToString());
        }
    }
}
