using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake.Strategies
{
    public class LetsMakeUp : Strategy
    {
        public override string Name => "Lets Make Up";

        private int OpponentNiceness = 1;

        public override bool StrategyResult(List<Round> gameState, int playerNum, int roundNum)
        {
            // share on first round
            if (roundNum == 0)
            {
                return true;
            }
            else
            {
                Round lastRound = gameState[roundNum - 1];
                int otherPlayer = (playerNum == 0 ? 1 : 0);


                // if our opponent was nice, be nice too!
                if (lastRound.ShareResult[otherPlayer])
                {
                    OpponentNiceness++;
                    return true;
                }
                    
                if (!lastRound.ShareResult[otherPlayer])
                {
                    // if the opponent is not being nice, lower our opinion of them
                    OpponentNiceness -= 3;

                    // if theyve been not very nice without being nice, retaliate
                    if (OpponentNiceness <= 0)
                    {
                        return false;
                    }
                    // if they start to be nice again, be nice too
                    if (OpponentNiceness > 0)
                    {
                        return true;
                    }
                }
                

                
                // this should never need to run but just in case
                return true;
                
            }
        }

        public override void ResetValues()
        {
            OpponentNiceness = 1;
        }
    }
}
