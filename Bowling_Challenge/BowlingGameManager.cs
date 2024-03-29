﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling_Challenge
{
    class BowlingGameManager
    {
        static int INITIAL_PIN_NUMBER = 10;
        
        public bool isGameOver;
        public int pinsOnLane;

        Frame[] frames;
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
            if (currentFrame.shotsLeft > 0)
            {
                currentFrame.shotsLeft -= 1;
                this.calculateFrameScore(pinsHit, currentFrame);
                this.calculatePriorStrikeAndSpareBonuses();
                this.pinsOnLane -= pinsHit;
                if (currentFrame.isStrike || currentFrame.shotsLeft == 0)
                {
                    this.currentFrameNumber++;
                    if (this.currentFrameNumber == 11 && currentFrame.shotsLeft == 0 &&
                        (this.pinsOnLane == 0 ||currentFrame.isStrike) && !currentFrame.bonusShotEarned)
                    {
                        currentFrame.bonusShotEarned = true;
                        currentFrame.shotsLeft = 1;
                        this.currentFrameNumber = 10;
                    } else if (this.currentFrameNumber == 11  && currentFrame.isStrike && currentFrame.shotsLeft > 0)
                    {
                        this.currentFrameNumber = 10;
                    }
                    this.pinsOnLane = INITIAL_PIN_NUMBER;
                }
            }
            this.detectGameOver();
        }

        public int calculateTotalScore()
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

        private void calculateFrameScore(int pinsHit, Frame currentFrame)
        {
            if (currentFrame.shotsLeft == 1 && pinsHit == INITIAL_PIN_NUMBER)
            {
                currentFrame.firstShotScore = 10;
                currentFrame.isStrike = true;
            } else if (currentFrame.shotsLeft == 1)
            {
                currentFrame.firstShotScore = pinsHit;
            } else
            {
                if (currentFrame.bonusShotEarned)
                {
                    currentFrame.bonusScore += pinsHit;
                } else
                {
                    currentFrame.secondShotScore = pinsHit;
                    currentFrame.isSpare = pinsOnLane - pinsHit == 0;
                }
                
            }
        }

        private void calculatePriorStrikeAndSpareBonuses()
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
                    if (priorFrame.isStrike)
                    {
                        priorPriorFrame.bonusScore = priorFrame.firstShotScore + currentFrame.firstShotScore;
                    }
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
