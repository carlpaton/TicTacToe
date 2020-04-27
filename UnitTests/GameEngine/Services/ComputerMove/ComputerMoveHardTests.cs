using GameEngine;
using GameEngine.Services.ComputerMove;
using GameEngine.Services.ComputerMove.MoveRules;
using NUnit.Framework;
using static GameEngine.PlayerEnum;

namespace UnitTests.GameEngine.Services.ComputerMove
{
    public class ComputerMoveHardTests
    {
        [TestCase(ComputerLevel.Easy, false)]
        [TestCase(ComputerLevel.Medium, false)]
        [TestCase(ComputerLevel.Hard, true)]
        public void IsMatch_GivenComputerLevel_MatchesGivenExpected(ComputerLevel computerLevel, bool expected)
        {
            // Arrange
            IComputerMove classUnderTest = new ComputerMoveHard();

            // Act
            var actual = classUnderTest.IsMatch(computerLevel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetPosition_I_E()
        {
            // Arrange
            IComputerMove classUnderTest = new ComputerMoveHard();
            var game = new Game();
            var computerPlayer = Player.O;
            var humanPlayer = Player.X;
            game.SetPosition(humanPlayer, 1);
            game.SetPosition(humanPlayer, 2);
            var expected = 3;

            // Act
            var actual = classUnderTest.SetPosition(computerPlayer, game.GetCurrentBoard());            

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
