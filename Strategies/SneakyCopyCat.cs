using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    public class SneakyCopyCat : Strategy
    {
        public override string Name => "Sneaky Copycat";

        Random random = new Random();

        /// <summary>
        /// Same as copycat, but 10% of the time steals regardless
        /// </summary>
        public override bool StrategyResult(List<Round> gameState, int playerNum, int roundNum)
        {
            // first move share
            if (roundNum == 0)
            {
                return true;
            }

            bool shouldShare = true;
            if (roundNum > 0)
            {
                Round lastRound = gameState[roundNum - 1];
                int otherPlayer = (playerNum == 0 ? 1 : 0);

                shouldShare = lastRound.ShareResult[otherPlayer];
            }
            // get sneaky and steal with 10% chance
            if (random.Next(0,10) == 0)
            {
                shouldShare = false;
            }

            return shouldShare;
        }
    }
}
