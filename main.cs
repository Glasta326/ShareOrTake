using ShareOrTake.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShareOrTake
{
    public class main
    {
        static List<Player> PlayerList = new List<Player>();

        static Game Game;

        #region Game Fields
        const int NumGames = 1000;
        #endregion

        static void Main(string[] args)
        {
            // Assemble the players
            PlayerList.Add(new Player(new AlwaysShare()));
            PlayerList.Add(new Player(new AlwaysTake()));
            PlayerList.Add(new Player(new RandomStrategy()));
            PlayerList.Add(new Player(new CopyCat()));
            PlayerList.Add(new Player(new Grudge()));
            PlayerList.Add(new Player(new SneakyCopyCat()));
            PlayerList.Add(new Player(new LetsMakeUp()));


            // for every player, play against every player
            // this forces a "times tables grid" of playoffs where every player plays against everyone including themselves
            // in the situation where a player plays against itself, techinically it is impossible to lose as whoever wins, the player still gains the points
            // this is why it is important for the reward of taking against someone who shares to be < the reward for both parties sharing,
            // as you gain greater when playing against yourself if you are a coorperative strategy
            foreach (var player0 in PlayerList)
            {
                foreach (var player1 in PlayerList)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine($"Playing : {player0.Strategy.Name} vs {player1.Strategy.Name}\n");

                    int initialPlayer0Points = player0.Points;
                    int initialPlayer1Points = player1.Points;

                    Initalise();
                    for (int i = 0; i < NumGames; i++)
                    {
                        Round CurrentRound = Game.GameRounds[i];
                        List<Round> CurrentGameState = Game.GameRounds;

                        // get the player choices
                        bool Player0Decision = player0.MakeDecision(CurrentGameState, 0, i);
                        bool Player1Decision = player1.MakeDecision(CurrentGameState, 1, i);

                        // update the current round info
                        CurrentRound.ShareResult[0] = Player0Decision;
                        CurrentRound.ShareResult[1] = Player1Decision;
                        CurrentRound.RoundHasPlayed = true;
                        Game.GameRounds[i] = CurrentRound;

                        player0.Points += Game.GameRounds[i].Reward()[0];
                        player1.Points += Game.GameRounds[i].Reward()[1];
                    }

                    
                    Console.WriteLine($"Player {player0.Strategy.Name} point gain : {(double)(player0.Points - initialPlayer0Points) / NumGames}");
                    Console.WriteLine($"Player {player1.Strategy.Name} point gain : {(double)(player1.Points - initialPlayer1Points) / NumGames}\n");

                    player0.Strategy.ResetValues();
                    player1.Strategy.ResetValues();
                }
            }

            // at the end, display each player's scores
            // scores are displayed divided by round number, so the result stays relevent regardless of rounds
            // sort the list of players by score first
            PlayerList.Sort((p1, p2) => p2.Points.CompareTo(p1.Points));
            for (int i = 0; i < PlayerList.Count; i++)
            {
                Console.WriteLine($"Player {PlayerList[i].Strategy.Name}'s Overall score : {(double)PlayerList[i].Points / NumGames}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Set up the game, the player list ect
        /// </summary>
        public static void Initalise()
        {
            Game = new Game(NumGames);
            Game.Initalise();
        }
    }
}
