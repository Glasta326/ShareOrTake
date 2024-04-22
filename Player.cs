using ShareOrTake.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake
{
    public class Player
    {
        /// <summary>
        /// The strategy this player will use
        /// </summary>
        public Strategy Strategy { get; set; }

        /// <summary>
        /// The score of this player
        /// </summary>
        public int Points { get; set; } = 0;

        public Player(Strategy strategy)
        {
            // oh my god strategy does not look like a real word
            Strategy = strategy;
        }


        /// <summary>
        /// Make a decision based on this player's strategy
        /// </summary>
        /// <param name="gameState"></param>
        /// <param name="playerNum">Player 0 or Player 1</param>
        /// <param name="roundNum">the index of the current round we are working on</param>
        /// <returns></returns>
        public bool MakeDecision(List<Round> gameState, int playerNum, int roundNum)
        {
            return Strategy.StrategyResult(gameState, playerNum, roundNum);
        }
    }
}
