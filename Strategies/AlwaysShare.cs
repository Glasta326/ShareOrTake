using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    /// <summary>
    /// A simple strategy that does not look at the state of the game in any capacity, and just always returns true or "share" 
    /// </summary>
    public class AlwaysShare : Strategy
    {
        public override string Name => "Always Share";

        /// <summary>
        /// Always Share
        /// </summary>
        public override bool StrategyResult(List<Round> gameState, int playerNum, int round)
        {
            return true;
        }

    }
}
