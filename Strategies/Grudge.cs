using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    /// <summary>
    /// Cooperates untill oponent steals a single time, then steals forever
    /// </summary>
    public class Grudge : Strategy
    {
        public override string Name => "GrudgeHolder";

        private bool HasGrudge = false;

        public override bool StrategyResult(List<Round> gameState, int playerNum, int roundNum)
        {
            if (roundNum > 0)
            {
                Round lastRound = gameState[roundNum - 1];
                int otherPlayer = (playerNum == 0 ? 1 : 0);

                // if the opponent stole last round
                if (!lastRound.ShareResult[otherPlayer])
                {
                    HasGrudge = true;
                }
            }
            if (!HasGrudge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ResetValues()
        {
            HasGrudge = false;
        }
    }
}
