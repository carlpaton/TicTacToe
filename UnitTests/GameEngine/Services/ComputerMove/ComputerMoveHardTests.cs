using GameEngine;
using GameEngine.Services.ComputerMove;
using GameEngine.Services.ComputerMove.MoveRules;
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
            IComputerMove classUnderTest = new ComputerMoveHard();

            // Act
            var actual = classUnderTest.IsMatch(computerLevel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("HorizontalData")]
        [TestCaseSource("VerticalData")]
        public void SetPosition_WhenTwoSquaresAreSetByTheHuman_TheComputerBlocksTheThird(int expected, int positionA, int positionB)
        {
            // Arrange
            IComputerMove classUnderTest = new ComputerMoveHard();
            var game = new Game();
            var computerPlayer = Player.O;
            var humanPlayer = Player.X;
            game.SetPosition(humanPlayer, positionA);
            game.SetPosition(humanPlayer, positionB);

            // Act
            var actual = classUnderTest.SetPosition(computerPlayer, game.GetCurrentBoard());            

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // TODO 
        // SetPosition_WhenTwoSquaresAreSetByTheComputer_TheComputerTakesTheThird

        static readonly object[] HorizontalData = new List<object>()
        {
           new object[]{ 1, 2, 3 },
           new object[]{ 2, 1, 3 },
           new object[]{ 3, 1, 2 },
           // TODO 4 5 6
           // TODO 7 8 9
        }.ToArray();

        static readonly object[] VerticalData = new List<object>()
        {
           new object[]{ 1, 4, 7 },
           new object[]{ 4, 1, 7 },
           new object[]{ 7, 1, 4 },
           // TODO 2 5 8
           // TODO 3 6 9
        }.ToArray();

        // TODO check at 45 degrees top-left to bottom-right

        // TODO check at 135 degrees top-right to bottom-left
    }
}
