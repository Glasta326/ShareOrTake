using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    /// <summary>
    /// The base class all strategies inherit from
    /// </summary>
    public abstract class Strategy
    {
        /// <summary>
        /// The name of the strategy
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The logic behind the strategy
        /// </summary>
        public abstract bool StrategyResult(List<Round> gameState, int playerNum, int roundNum);

        /// <summary>
        /// Reset any round specific values like held grudges
        /// </summary>
        public virtual void ResetValues()
        {

        }
    }
}
