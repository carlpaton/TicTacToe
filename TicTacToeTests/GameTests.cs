using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TicTacToe;
using static TicTacToe.PlayerEnum;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void ResetBoard_WhenCurrentBoardHasUsedPositions_ClearsTheBoard()
        {
            // Arrange
            IGame classUnderTest = new Game();
            var player = Player.O;
            classUnderTest.SetRandomPosition(player);
            classUnderTest.SetRandomPosition(player);            
            var expected = "{\"1\":\"\",\"2\":\"\",\"3\":\"\",\"4\":\"\",\"5\":\"\",\"6\":\"\",\"7\":\"\",\"8\":\"\",\"9\":\"\"}";

            // Act
            classUnderTest.ResetBoard();
            var currentBoard = classUnderTest.GetCurrentBoard();
            var actual = JsonConvert.SerializeObject(currentBoard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetRandomPosition_GivenPlayer_SetsBoardPosition()
        {
            // Arrange
            IGame classUnderTest = new Game();
            var player = Player.O;

            // Act
            var position = classUnderTest.SetRandomPosition(player);
            var expected = classUnderTest.GetPositionValue(position);

            // Assert
            Assert.AreEqual(expected, player.ToString());
        }

        [Test]
        public void SetPosition_GivenPlayerAndValidPosition_SetsBoardPosition()
        {
            // Arrange
            IGame classUnderTest = new Game();
            var position = 5;
            var expected = Player.O;

            // Act
            classUnderTest.SetPosition(expected, position);
            var actual = classUnderTest.GetPositionValue(position);

            // Assert
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(42)]
        public void SetPosition_GivenPlayerAndInValidPosition_ThrowsException(int position)
        {
            // Arrange
            IGame classUnderTest = new Game();

            // Act
            // Assert
            Assert.Throws<Exception>(() => classUnderTest.SetPosition(Player.O, position));
        }
    }
}