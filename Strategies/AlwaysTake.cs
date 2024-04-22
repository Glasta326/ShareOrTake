using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{

    /// <summary>
    /// A simple strategy that does not look at the state of the game in any capacity, and just always returns false or "take"
    /// </summary>
    public class AlwaysTake : Strategy
    {
        public override string Name => "Always Take";

        /// <summary>
        /// Always take
        /// </summary>
        public override bool StrategyResult(List<Round> gameState, int playerNum, int round)
        {
            return false;
        }
    }
}
