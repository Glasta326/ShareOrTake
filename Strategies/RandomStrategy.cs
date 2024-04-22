using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    /// <summary>
    /// A simple strategy that just acts randomly
    /// </summary>
    public class RandomStrategy : Strategy
    {
        public override string Name => "Random";

        Random random = new Random();

        /// <summary>
        /// Random result
        /// </summary>
        public override bool StrategyResult(List<Round> gameState, int playerNum, int round)
        {
            if (random.Next(0,2) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
