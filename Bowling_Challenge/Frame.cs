﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling_Challenge
{
    class Frame
    {
        public bool isStrike = false;
        public bool isSpare = false;
        public bool bonusShotEarned = false;
        public int firstShotScore = 0;
        public int secondShotScore = 0;
        public int bonusScore = 0;
        public int shotsLeft = 2;
        public int frameScore
        {
            get
            {
                return firstShotScore + secondShotScore + bonusScore;
            }
        }
    }
}
