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
        public List<Dice> Dices { get; set; }
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
            Players = new List<Player>();
            Dices = new List<Dice>();

            for (int i = 0; i < numberOfDice; i++)
            {
                Dices.Add(new Dice());
            }
        }

        public void AddPlayer(Player player)
        {
            if (_activePlayer != null)
            {
                throw new Exception("The game is started. You cannot add a new player.");
            }
            //Once the game starts, it’s not allowed to add new players.
            //Throw an exception from this method if the UI program tries to do such operation.
            Players.Add(player);
        }

        public void Start()
        {
            if (Players.Count<2)
                throw new Exception("There should be at least two players.");
            // Update a game state to mention that the game has started (so AddPlayer can’t
            // be called anymore).
            _activePlayer = Players[0];
        }

        public void PlayTurn()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }



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
