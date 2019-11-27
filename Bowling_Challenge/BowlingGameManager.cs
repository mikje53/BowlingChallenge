using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling_Challenge
{
    class BowlingGameManager
    {
        static int INITIAL_PIN_NUMBER = 10;
        Frame[] frames;
        int pinsOnLane;
        int currentFrameNumber;
        public bool isGameOver;

        public BowlingGameManager()
        {
            this.currentFrameNumber = 1;
            this.frames = new Frame[10];
            for(int i = 0; i < 10; i++)
            {
                this.frames[i] = new Frame();
            }
            this.pinsOnLane = 10;
            this.isGameOver = false;
        }

        public void rollBall(int pinsHit)
        {
            Frame currentFrame = this.frames[this.currentFrameNumber - 1];
            currentFrame.shotsLeft -= 1;
            this.pinsOnLane -= pinsHit;
            if (this.pinsOnLane == 0 && currentFrame.shotsLeft == 1)
            {
                calculateFrameScore(true, false);
            } else if (this.pinsOnLane == 0)
            {
                this.calculateFrameScore(false, true);
            } else if (currentFrame.shotsLeft == 0)
            {
                this.calculateFrameScore(false, false);
            }
            this.detectGameOver();
        }

        public int calculateScore()
        {
            int totalScore = 0;
            for (int i = 0; i < currentFrameNumber; i++)
            {
                totalScore += this.frames[i].score;
            }
            return totalScore;
        }

        private void calculateFrameScore(bool strike, bool spare)
        {
            Frame currentFrame = this.frames[currentFrameNumber - 1];
            currentFrame.isStrike = strike;
            currentFrame.isSpare = spare;
            currentFrame.score = INITIAL_PIN_NUMBER - this.pinsOnLane;
            this.pinsOnLane = INITIAL_PIN_NUMBER;
            this.currentFrameNumber++;
        }

        private void detectGameOver()
        {
            if (this.currentFrameNumber == 11)
            {
                this.isGameOver = true;
            }
            this.currentFrameNumber = this.currentFrameNumber < 10 ? this.currentFrameNumber : 10;
        }
    }
}
