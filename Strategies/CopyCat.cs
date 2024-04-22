using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    public class CopyCat : Strategy
    {
        public override string Name => "CopyCat";


        /// <summary>
        /// Copy the action of the other player from the previous round
        /// </summary>
        public override bool StrategyResult(List<Round> gameState, int playerNum, int roundNum)
        {
            if (roundNum > 0)
            {
                Round lastRound = gameState[roundNum - 1];
                int otherPlayer = (playerNum == 0 ? 1 : 0);

                return lastRound.ShareResult[otherPlayer];
            }
            // on first move, share
            else
            {
                return true;
            }

        }
    }
}
