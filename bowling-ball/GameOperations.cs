using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
   public class GameOperations
    {
        public int[] rolls = new int[21];
        private int[] frame = new int[10];
        int currentRoll = 0;
        public bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        public bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                rolls[currentRoll++] = pins[i];
            }
        }
    }
}
