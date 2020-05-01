using GameEngine;
using GameEngine.Services.ComputerMove;
using GameEngine.Services.ComputerMove.MoveRules;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using static GameEngine.PlayerEnum;

namespace UnitTests.GameEngine.Services.ComputerMove
{
    public class ComputerMoveMediumTests
    {
        [TestCase(ComputerLevel.Easy, false)]
        [TestCase(ComputerLevel.Medium, true)]
        [TestCase(ComputerLevel.Hard, false)]
        public void IsMatch_GivenComputerLevel_MatchesGivenExpected(ComputerLevel computerLevel, bool expected)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveMedium>>();
            IComputerMove classUnderTest = new ComputerMoveMedium(mockLogger.Object);

            // Act
            var actual = classUnderTest.IsMatch(computerLevel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetPosition_WhenHighValueSquareIsAvalibleThatCanMake4Rows_ThisSquareIsUsed()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveMedium>>();
            IComputerMove classUnderTest = new ComputerMoveMedium(mockLogger.Object);
            var mockFallback = new Mock<IEnumerable<IComputerMove>>();
            var game = new Game();
            var player = Player.O;
            var expected = 5; // Only square 5 can make 4 rows

            // Act
            var actual = classUnderTest.SetPosition(player, game.GetCurrentBoard(), mockFallback.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("HighValueSquaresCanMake3RowsData")]
        public void SetPosition_WhenHighValueSquareIsAvalibleThatCanMake3Rows_ThisSquareIsUsed(int expected, int alreadyPopulatedA, int alreadyPopulatedB, int alreadyPopulatedC)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveMedium>>();
            IComputerMove classUnderTest = new ComputerMoveMedium(mockLogger.Object);
            var mockFallback = new Mock<IEnumerable<IComputerMove>>();
            var game = new Game();
            var player = Player.O;
            game.SetPosition(Player.X, 5); // assume square 5 was already taken (can make 4 rows)
            game.SetPosition(Player.X, alreadyPopulatedA);
            game.SetPosition(Player.X, alreadyPopulatedB);
            game.SetPosition(Player.X, alreadyPopulatedC);

            // Act
            var actual = classUnderTest.SetPosition(player, game.GetCurrentBoard(), mockFallback.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("HighValueSquaresCanMake2RowsData")]
        public void SetPosition_WhenHighValueSquareIsAvalibleThatCanMake2Rows_ThisSquareIsUsed(int expected, int alreadyPopulatedA, int alreadyPopulatedB, int alreadyPopulatedC)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveMedium>>();
            IComputerMove classUnderTest = new ComputerMoveMedium(mockLogger.Object);
            var mockFallback = new Mock<IEnumerable<IComputerMove>>();
            var game = new Game();
            var player = Player.O;
            // assume square 5 was already taken (can make 4 rows)
            game.SetPosition(Player.X, 5);

            // assume squares 1, 3, 7, 9 are already taken (can make 3 rows)
            game.SetPosition(Player.X, 1);
            game.SetPosition(Player.X, 3);
            game.SetPosition(Player.X, 7);
            game.SetPosition(Player.X, 9);

            game.SetPosition(Player.X, alreadyPopulatedA);
            game.SetPosition(Player.X, alreadyPopulatedB);
            game.SetPosition(Player.X, alreadyPopulatedC);

            // Act
            var actual = classUnderTest.SetPosition(player, game.GetCurrentBoard(), mockFallback.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        static readonly object[] HighValueSquaresCanMake3RowsData = new List<object>()
        {
            // high value board squares which allow for 3 rows ~ for the first row:
            // 1 is the square expected to be taken
            // 3, 7, 9 are already populated
            // the subsequent lines are permutations of the above
            new object[]{ 1, 3, 7, 9 },
            new object[]{ 3, 1, 7, 9 },
            new object[]{ 7, 3, 1, 9 },
            new object[]{ 9, 7, 3, 1 },
        }.ToArray();

        static readonly object[] HighValueSquaresCanMake2RowsData = new List<object>()
        {
            // high value board squares which allow for 2 rows
            new object[]{ 2, 4, 6, 8 },
            new object[]{ 4, 2, 6, 8 },
            new object[]{ 6, 4, 2, 8 },
            new object[]{ 8, 6, 4, 2 },
        }.ToArray();
    }
}
