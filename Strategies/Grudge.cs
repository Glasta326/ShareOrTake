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
                // if the opponent stole last round
                if (playerNum == 0)
                { 
                    if (!lastRound.Share1)
                    {
                        HasGrudge = true;
                    }
                }
                if (playerNum == 1)
                {
                    if (!lastRound.Share0)
                    {
                        HasGrudge = true;
                    }
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
