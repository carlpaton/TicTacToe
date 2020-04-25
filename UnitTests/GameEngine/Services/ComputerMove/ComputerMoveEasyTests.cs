using GameEngine;
using GameEngine.Services.ComputerMove;
using GameEngine.Services.ComputerMove.MoveRules;
using NUnit.Framework;
using static GameEngine.PlayerEnum;

namespace UnitTests.GameEngine.Services.ComputerMove
{
    public class ComputerMoveEasyTests
    {
        [TestCase(ComputerLevel.Easy, true)]
        [TestCase(ComputerLevel.Medium, false)]
        public void IsMatch_GivenComputerLevel_MatchesGivenExpected(ComputerLevel computerLevel, bool expected)
        {
            // Arrange
            IComputerMove classUnderTest = new ComputerMoveEasy();

            // Act
            var actual = classUnderTest.IsMatch(computerLevel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetPosition_GivenValidDataAndTheBoardHasOpenSquares_SetsBoardPosition()
        {
            // Arrange
            IComputerMove classUnderTest = new ComputerMoveEasy();
            var game = new Game();
            var player = Player.O;

            // Act
            var position = classUnderTest.SetPosition(player, game.GetCurrentBoard());
            var expected = game.GetPositionValue(position);

            // Assert
            Assert.AreEqual(expected, player.ToString());
        }
    }
}
