using GameEngine;
using GameEngine.Services;
using GameEngine.Services.Interfaces;
using NUnit.Framework;
using static GameEngine.PlayerEnum;

namespace GameEngineTests.Services
{
    public class WinnerServiceTests
    {
        // Horizontal
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 7, 8, 9 })]
        // Vertical
        [TestCase(new int[] { 1, 4, 7 })]
        [TestCase(new int[] { 2, 5, 8 })]
        [TestCase(new int[] { 3, 6, 9 })]
        // Diagonal
        [TestCase(new int[] { 1, 5, 9 })]
        [TestCase(new int[] { 7, 5, 3 })]
        public void GetWinner_WhenCheckedSquaresAreTheSame_ReturnsTrue(int[] squares)
        {
            // Arrange           
            IWinnerService classUnderTest = new WinnerService();
            var player = Player.O;
            var expected = true;

            var game = new Game();
            game.SetPosition(player, squares[0]);
            game.SetPosition(player, squares[1]);
            game.SetPosition(player, squares[2]);
            var currentBoard = game.GetCurrentBoard();

            // Act
            var actual = classUnderTest
                .GetWinner(currentBoard)
                .HasWon;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
