using GameEngine.Services;
using GameEngine.Services.Interfaces;
using NUnit.Framework;

namespace UnitTests.GameEngine.Services
{
    public class GameLogServiceTests
    {
        [Test]
        public void Append_GivenAMessage_AppendsTheMessage()
        {
            // Arrange
            IGameLogService classUnderTest = new GameLogService();
            var expected = "bar\r\nfoo";

            // Act
            classUnderTest.Append("foo");
            var actual = classUnderTest.Append("bar");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reset_WithCurrentState_ReturnsEmpty()
        {
            // Arrange
            IGameLogService classUnderTest = new GameLogService();
            var expected = "";

            // Act
            classUnderTest.Append("foo");
            classUnderTest.Append("bar");
            var actual = classUnderTest.Reset();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
