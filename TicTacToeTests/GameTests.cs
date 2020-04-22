using NUnit.Framework;
using System;
using TicTacToe;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void SetRandomPosition_GivenPlayer_SetsBoardPosition()
        {
            // Arrange
            var game = new Game();
            var player = Game.Player.O;

            // Act
            var position = game.SetRandomPosition(player);
            var expected = game.GetPositionValue(position);

            // Assert
            Assert.AreEqual(expected, player.ToString());
        }

        [Test]
        public void SetPosition_GivenPlayerAndValidPosition_SetsBoardPosition()
        {
            // Arrange
            var game = new Game();
            var position = 5;
            var player = Game.Player.O;

            // Act
            game.SetPosition(player, position);
            var expected = game.GetPositionValue(position);

            // Assert
            Assert.AreEqual(expected, player.ToString());
        }

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(42)]
        public void SetPosition_GivenPlayerAndInValidPosition_ThrowsException(int position)
        {
            // Arrange
            var game = new Game();

            // Act
            // Assert
            Assert.Throws<Exception>(() => game.SetPosition(Game.Player.O, position));
        }
    }
}