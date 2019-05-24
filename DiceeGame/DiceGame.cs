using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceeGame
{
    enum RollResult
    {
        Jackpot,    // all the dice have the max number
        Win,        // all the dice have the same number, but not the max
        Lose        // different numbers
    }

    class DiceGame
    {
        public List<Dice> Dice { get; set; }
        public List<Player> Players { get; set; }

        private Player _activePlayer;
        public Player ActivePlayer
        {
            get { return _activePlayer; }
        }

        private bool _isGameOver;
        public bool IsGameOver
        {
            get { return _isGameOver; }
        }

        public DiceGame(int numberOfDice)
        {

        }

        public void AddPlayer(Player player)
        {

        }

        public void Start()
        {

        }

        public void PlayTurn()
        {

        }

        public void RollDice()
        {

        }

        public void ComputeTurnResult()
        {

        }

        public void UpdatePlayerStat()
        {

        }

        public void SetNextPlayer()
        {

        }

        public Player TheWinner()
        {

            return new Player();
        }

    }
}
