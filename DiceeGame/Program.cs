using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceGame diceGame = new DiceGame(2);

            Player p1 = new Player();
            Player p2 = new Player();
            Player p3 = new Player();
            Player p4 = new Player();

            p1.Name = "John";
            p2.Name = "Peter";
            p3.Name = "Mike";
            p4.Name = "Cathy";

            diceGame.AddPlayer(p1);
            diceGame.AddPlayer(p2);
            diceGame.AddPlayer(p3);
            diceGame.AddPlayer(p4);

            diceGame.Start();

            Console.WriteLine(diceGame.ActivePlayer.Name);
            diceGame.SetNextPlayer();

           

        }
    }
}
