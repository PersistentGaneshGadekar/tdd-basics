using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameTests
    {
        private Game game;
        private GameOperations gameOperations;
        public GameTests()
        {
            gameOperations = new GameOperations();
            game = new Game();
            
        }
        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                gameOperations.Roll(pins);
            }
        }
        private void rollSpare()
        {
            gameOperations.Roll(6);
            gameOperations.Roll(4);
        }
        [Fact]
        public void TestBowlingGameClass()
        {
            Assert.IsType<Game>(game);
        }

        [Fact]
        public void GutterGameTest()
        {
            rollMany(20, 0);
            Assert.Equal(0, game.Score(gameOperations));
        }

        [Fact]
        public void AllOnesTest()
        {
            rollMany(20, 1);
            Assert.Equal(20, game.Score(gameOperations));
        }

        [Fact]
        public void OneSpareTest()
        {
            rollSpare();
            gameOperations.Roll(4);
            rollMany(17, 0);
            Assert.Equal(18, game.Score(gameOperations));
        }

        [Fact]
        public void OneStrikeTest()
        {
            gameOperations.Roll(10);
            gameOperations.Roll(4);
            gameOperations.Roll(5);
            rollMany(17, 0);
            Assert.Equal(28, game.Score(gameOperations));
        }

        [Fact]
        public void AllStrikesTest()
        {
            rollMany(12, 10);
            Assert.Equal(300, game.Score(gameOperations));
        }

        [Fact]
        public void RandomGameNoExtraRollTest()
        {
            gameOperations.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, game.Score(gameOperations));
        }

        [Fact]
        public void RandomGameWithSpareThenStrikeAtEndTest()
        {
            gameOperations.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, game.Score(gameOperations));
        }

        [Fact]
        public void RandomGameWithThreeStrikesAtEndTest()
        {
            gameOperations.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, game.Score(gameOperations));
        }
    }
}
