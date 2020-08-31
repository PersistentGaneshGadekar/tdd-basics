using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameTests
    {
        private readonly Game game;
        private readonly GameOperations gameOperations;
        public GameTests()
        {
            gameOperations = new GameOperations();
            game = new Game();
            
        }
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                gameOperations.Roll(pins);
            }
        }
        private void RollSpare()
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
            RollMany(20, 0);
            Assert.Equal(0, game.Score(gameOperations));
        }

        [Fact]
        public void AllOnesTest()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.Score(gameOperations));
        }

        [Fact]
        public void OneSpareTest()
        {
            RollSpare();
            gameOperations.Roll(4);
            RollMany(17, 0);
            Assert.Equal(18, game.Score(gameOperations));
        }
        [Fact]
        public void TwoSpareTest()
        {
            RollSpare();
            RollSpare();
            Assert.Equal(26, game.Score(gameOperations));
        }
        [Fact]
        public void OneStrikeTest()
        {
            gameOperations.Roll(10);
            gameOperations.Roll(4);
            gameOperations.Roll(5);
            RollMany(17, 0);
            Assert.Equal(28, game.Score(gameOperations));
        }

        [Fact]
        public void ThreeStrikeTest()
        {
            gameOperations.Roll(10);
            gameOperations.Roll(10);
            gameOperations.Roll(10);
            Assert.Equal(60, game.Score(gameOperations));
        }
        [Fact]
        public void  StrikeAtBothEndTest()
        {
            gameOperations.Roll(10);
            gameOperations.Roll(4);
            gameOperations.Roll(5);
            gameOperations.Roll(10);
            RollMany(17, 0);
            Assert.Equal(38, game.Score(gameOperations));
        }

        [Fact]
        public void StrikeAtEndTest()
        {
            gameOperations.Roll(4);
            gameOperations.Roll(5);
            gameOperations.Roll(10);
            RollMany(17, 0);
            Assert.Equal(19, game.Score(gameOperations));
        }

        [Fact]
        public void AllStrikesTest()
        {
            RollMany(12, 10);
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
