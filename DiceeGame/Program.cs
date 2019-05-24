using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceeGame
{
    class Program
    {
        public static Random RandomGen = new Random();

        static void Main(string[] args)
        {
            DiceGame diceGame = new DiceGame(2);
            Console.WriteLine("\nWelcome to Dice Game!!!!!");

            int numOfPlayers = GetNumberOfPlayers();
            AddPlayersToGame(diceGame, numOfPlayers);

            diceGame.Start();
            Console.WriteLine("\n------- Game Start! -------");
            while (!diceGame.IsGameOver)
            {
                diceGame.PlayTurn();
                Console.WriteLine($"\n{diceGame.ActivePlayer.Name}");
                ShowDiceResult(diceGame.Dices);
                Console.WriteLine($"  Score: {diceGame.ActivePlayer.Score}");
                // Include (System.Readline()) so the user can see the result.
            }

            PrintOutGameResult(diceGame);

        }

        public static int GetNumberOfPlayers()
        {
            int numOfPlayers;
            while (true)
            {
                Console.WriteLine("\nPlease type the number of players: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numOfPlayers) && numOfPlayers > 1)
                {
                    return numOfPlayers;
                }
                Console.WriteLine("\nInvalid Input!");
            }
        }

        public static void AddPlayersToGame(DiceGame diceGame, int numOfPlayers)
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                diceGame.AddPlayer(new Player()
                {
                    Name = $"Player{i + 1}",
                    Score = 0
                });
            }
        }

        public static void ShowDiceResult(List<Dice> dices)
        {
            for (int i = 0; i < dices.Count; i++)
            {
                Console.WriteLine($"  Dice({i + 1}): {dices[i].Face}");
            }
        }

        public static void PrintOutGameResult(DiceGame diceGame)
        {
            Player winner = diceGame.TheWinner();
            Console.WriteLine("\n------- Game End. -------\n");

            if (winner == null)
                Console.WriteLine("\nThere is no Winner.\n");
            else
            {
                Console.WriteLine($"The Winner is {winner.Name}.\n");
                for (int i = 0; i < winner.History.Count; i++)
                {
                    Console.WriteLine($"  Round({i + 1}) : {winner.History[i]}");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
