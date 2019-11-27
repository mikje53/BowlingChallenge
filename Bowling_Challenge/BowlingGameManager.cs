using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling_Challenge
{
    class BowlingGameManager
    {
        static int INITIAL_PIN_NUMBER = 10;
        
        public bool isGameOver;

        Frame[] frames;
        int pinsOnLane;
        int currentFrameNumber;

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
            
            this.calculateFrameScore(pinsHit);
            this.calculatePriorStrikeAndSpareBonus();
            this.detectGameOver();
        }

        public int calculateScore()
        {
            int totalScore = 0;
            for (int i = 0; i < currentFrameNumber; i++)
            {
                totalScore += this.frames[i].frameScore;
            }
            return totalScore;
        }

        public int[] getFrameScoreBreakDown()
        {
            int[] scoreBreakdown = new int[10];
            for (int i = 0; i < 10; i++)
            {
                scoreBreakdown[i] = i == 0 ? this.frames[0].frameScore : this.frames[i].frameScore + scoreBreakdown[i - 1];
            }
            return scoreBreakdown;
        }

        private void calculateFrameScore(int pinsHit)
        {
            Frame currentFrame = this.frames[currentFrameNumber - 1];
            if (currentFrame.shotsLeft == 1 && pinsHit == INITIAL_PIN_NUMBER)
            {
                currentFrame.firstShotScore = 10;
                currentFrame.isStrike = true;
                this.pinsOnLane = INITIAL_PIN_NUMBER;
                this.currentFrameNumber++;
            } else if (currentFrame.shotsLeft == 1)
            {
                currentFrame.firstShotScore = pinsHit;
                this.pinsOnLane -= pinsHit;
            } else
            {
                currentFrame.secondShotScore = pinsHit;
                currentFrame.isSpare = pinsOnLane - pinsHit == 0;
                this.pinsOnLane = INITIAL_PIN_NUMBER;
                this.currentFrameNumber++;
            }
        }

        private void calculatePriorStrikeAndSpareBonus()
        {
            if (this.currentFrameNumber <= 10)
            {
                Frame currentFrame = this.frames[this.currentFrameNumber - 1];
                Frame priorFrame = this.currentFrameNumber > 1 ? this.frames[this.currentFrameNumber - 2] : null;
                Frame priorPriorFrame = this.currentFrameNumber > 2 ? this.frames[this.currentFrameNumber - 3] : null;

                if (priorFrame != null && priorFrame.isSpare)
                {
                    priorFrame.bonusScore = currentFrame.firstShotScore;
                }
                else if (priorFrame != null && priorFrame.isStrike)
                {
                    priorFrame.bonusScore = currentFrame.firstShotScore + currentFrame.secondShotScore;
                }

                if (priorPriorFrame != null && priorPriorFrame.isStrike)
                {
                    priorPriorFrame.bonusScore = currentFrame.firstShotScore + currentFrame.secondShotScore;
                }
            }
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
