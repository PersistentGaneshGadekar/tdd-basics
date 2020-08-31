using BowlingBall.Interfaces;
using System;

namespace BowlingBall
{
    public class Game : IGame
    {
        public int Score(GameOperations gameOperations)
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (gameOperations.IsSpare(frameIndex))
                {  
                    score += 10 + gameOperations.rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else if (gameOperations.IsStrike(frameIndex))
                {
                    score += 10 + gameOperations.rolls[frameIndex + 1] + gameOperations.rolls[frameIndex + 2];
                    frameIndex++;
                }
                else
                {
                    score += gameOperations.rolls[frameIndex] + gameOperations.rolls[frameIndex + 1];
                    frameIndex += 2;
                }

            }

            return score;
        }

    }
}

