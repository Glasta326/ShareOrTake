﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake
{
    /// <summary>
    /// A single instance of a round, where n rounds composes an entire game
    /// </summary>
    public class Round
    {
        /// <summary>
        /// The reward handed out if both parties share
        /// </summary>
        public const int BothShareReward = 3;

        /// <summary>
        /// The reward handed out to the party that shares when the other player does not
        /// </summary>
        public const int SingleShareReward = 0;

        /// <summary>
        /// The reward handed out to the party that takes when the other player does not
        /// </summary>
        public const int SingleTakeReward = 5;

        /// <summary>
        /// The reward handed out when both parties take
        /// </summary>
        public const int BothTakeReward = 1;

        /// <summary>
        /// Slot n for player n's share choice
        /// </summary>
        public bool[] ShareResult = new bool[] { false,false };

        /// <summary>
        /// True if this round has already been played
        /// </summary>
        public bool RoundHasPlayed = false;


        public Round(bool share0 = false, bool share1 = false)
        {
            ShareResult[0] = share0;
            ShareResult[1] = share1;
        }


        /// <summary>
        /// Calculate and return the appropraite reward for each party
        /// </summary>
        /// <returns>int[], [A's reward, B's reward]</returns>
        public int[] Reward()
        {
            // If both players share
            if (ShareResult[0] && ShareResult[1])
            {
                return new int[] { BothShareReward, BothShareReward };
            }

            // If 0 shares and 1 takes
            if (ShareResult[0] && !ShareResult[1])
            {
                return new int[] { SingleShareReward, SingleTakeReward };
            }

            // If 0 takes and 1 shares
            if (!ShareResult[0] && ShareResult[1])
            {
                return new int[] { SingleTakeReward, SingleShareReward };
            }

            // If Both 0 and 1 take
            if (!ShareResult[0] && !ShareResult[1])
            {
                return new int[] { BothTakeReward, BothTakeReward };
            }

            // If something goes horrifically wrong
            else
            {
                Console.WriteLine("Reward calulation issue");
                return new int[] { 0, 0 };
            }
        }
    }
}
