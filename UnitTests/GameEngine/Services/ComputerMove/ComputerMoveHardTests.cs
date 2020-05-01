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
    public class ComputerMoveHardTests
    {
        [TestCase(ComputerLevel.Easy, false)]
        [TestCase(ComputerLevel.Medium, false)]
        [TestCase(ComputerLevel.Hard, true)]
        public void IsMatch_GivenComputerLevel_MatchesGivenExpected(ComputerLevel computerLevel, bool expected)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveHard>>();
            IComputerMove classUnderTest = new ComputerMoveHard(mockLogger.Object);

            // Act
            var actual = classUnderTest.IsMatch(computerLevel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("HorizontalData")]
        [TestCaseSource("VerticalData")]
        [TestCaseSource("Degrees45")]
        [TestCaseSource("Degrees135")]
        public void SetPosition_WhenTwoSquaresAreSetByTheHuman_TheComputerBlocksTheThird(int expected, int positionA, int positionB)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveHard>>();
            IComputerMove classUnderTest = new ComputerMoveHard(mockLogger.Object);
            var mockFallback = new Mock<IEnumerable<IComputerMove>>();
            var game = new Game();
            var computerPlayer = Player.O;
            var humanPlayer = Player.X;
            game.SetPosition(humanPlayer, positionA);
            game.SetPosition(humanPlayer, positionB);

            // Act
            var actual = classUnderTest.SetPosition(computerPlayer, game.GetCurrentBoard(), mockFallback.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("HorizontalData")]
        [TestCaseSource("VerticalData")]
        [TestCaseSource("Degrees45")]
        [TestCaseSource("Degrees135")]
        public void SetPosition_WhenTwoSquaresAreSetByTheComputer_TheComputerTakesTheThird(int expected, int positionA, int positionB)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ComputerMoveHard>>();
            IComputerMove classUnderTest = new ComputerMoveHard(mockLogger.Object);
            var mockFallback = new Mock<IEnumerable<IComputerMove>>();
            var game = new Game();
            var computerPlayer = Player.O;
            game.SetPosition(computerPlayer, positionA);
            game.SetPosition(computerPlayer, positionB);

            // Act
            var actual = classUnderTest.SetPosition(computerPlayer, game.GetCurrentBoard(), mockFallback.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        static readonly object[] HorizontalData = new List<object>()
        {
            // row 1 ~ for the first row:
            // 1 is the square expected to be blocked by the computer/human
            // 2, 3 are already populated by the human/computer
            // the subsequent lines are permutations of the above
            new object[]{ 1, 2, 3 },
            new object[]{ 2, 1, 3 },
            new object[]{ 3, 1, 2 },

            // row 2
            new object[]{ 4, 5, 6 },
            new object[]{ 5, 4, 6 },
            new object[]{ 6, 4, 5 },

            // row 3
            new object[]{ 4, 5, 6 },
            new object[]{ 5, 4, 6 },
            new object[]{ 6, 4, 5 }
        }.ToArray();

        static readonly object[] VerticalData = new List<object>()
        {
            // column 1 ~ for the first row:
            // 1 is the square expected to be blocked by the computer/human
            // 4, 7 are already populated by the human/computer
            // the subsequent lines are permutations of the above
            new object[]{ 1, 4, 7 },
            new object[]{ 4, 1, 7 },
            new object[]{ 7, 1, 4 },

            // column 2
            new object[]{ 2, 5, 8 },
            new object[]{ 5, 2, 8 },
            new object[]{ 8, 2, 5 },

            // column 3
            new object[]{ 3, 6, 9 },
            new object[]{ 6, 3, 9 },
            new object[]{ 9, 3, 6 }
        }.ToArray();

        static readonly object[] Degrees45 = new List<object>()
        {
            // 45 degrees top-left to bottom-right ~ for the first row:
            // 1 is the square expected to be blocked by the computer/human
            // 5, 9 are already populated by the human/computer
            // the subsequent lines are permutations of the above
            new object[]{ 1, 5, 9 },
            new object[]{ 5, 1, 9 },
            new object[]{ 9, 1, 5 }
        }.ToArray();

        static readonly object[] Degrees135 = new List<object>()
        {
            // 135 degrees top-right to bottom-left ~ for the first row:
            // 3 is the square expected to be blocked by the computer/human
            // 5, 7 are already populated by the human/computer
            // the subsequent lines are permutations of the above
            new object[]{ 3, 5, 7 },
            new object[]{ 5, 3, 7 },
            new object[]{ 7, 5, 3 }
        }.ToArray();
    }
}
