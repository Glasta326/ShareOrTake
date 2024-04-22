using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareOrTake
{
    public class Game
    {
        /// <summary>
        /// The total number of rounds in the game
        /// </summary>
        private int NumRounds = 200;

        public List<Round> GameRounds = new List<Round>();

        public Game(int numRounds = 200)
        {
            NumRounds = numRounds;
        }

        public void Initalise()
        {
            // Initialise the game with the number of rounds
            for (int i = 0; i < NumRounds; i++)
            {
                GameRounds.Add(new Round());
            }
        }
    }
}
