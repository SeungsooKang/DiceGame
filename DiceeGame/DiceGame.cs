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

        private string _gameStat = "";

        public DiceGame(int numberOfDice)
        {
            _isGameOver = false;
            Players = new List<Player>();
            Dices = new List<Dice>();

            for (int i = 0; i < numberOfDice; i++)
            {
                Dices.Add(new Dice());
            }
        }

        public void AddPlayer(Player player)
        {
            //if (_activePlayer != null)
            //    throw new Exception("The game is started. You cannot add a new player.");
            if (_gameStat.Equals("started"))
                throw new Exception("The game is started. You cannot add a new player.");
            Players.Add(player);
        }

        public void Start()
        {
            if (Players.Count<2)
                throw new Exception("There should be at least two players.");
            _gameStat = "started";
        }

        public void PlayTurn()
        {
            SetNextPlayer();
            RollDice();
            UpdatePlayerStat();
            CheckGameOver();
        }

        public void RollDice()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }
        }

        public RollResult ComputeTurnResult()
        {
            RollResult rollResult = RollResult.Lose;
            if (Dices.All(dice => dice.Face == Dices[0].Face))
                rollResult = Dices[0].Face == Dices[0].Max ? RollResult.Jackpot : RollResult.Win;
            return rollResult;
        }

        public void UpdatePlayerStat()
        {
            RollResult rollResult = ComputeTurnResult();
            _activePlayer.History.Add(rollResult);

            switch (rollResult)
            {
                case RollResult.Jackpot:
                    _activePlayer.Score += (Dices.Count * Dices[0].Max * 10);
                    _activePlayer.ThisTurnScore = Dices.Count * Dices[0].Max * 10;
                    break;
                case RollResult.Win:
                    _activePlayer.Score += (Dices.Count * Dices[0].Face * 5);
                    _activePlayer.ThisTurnScore = Dices.Count * Dices[0].Face * 5;
                    break;
                case RollResult.Lose:
                    _activePlayer.Score += 0;
                    _activePlayer.ThisTurnScore = 0;
                    break;
            }
        }

        public void SetNextPlayer()
        {
            _activePlayer = _activePlayer == null ? Players[0] : Players[(Players.IndexOf(_activePlayer) + 1) % Players.Count];
        }

        public Player TheWinner()
        {
            int maxScore = Players[0].Score;
            for (int i = 1; i < Players.Count; i++)
                maxScore = Math.Max(maxScore, Players[i].Score);

            List<Player> maxPlayers = Players.FindAll(player => player.Score == maxScore);
            return maxPlayers.Count > 1 ? null : maxPlayers[0];
        }

        public void CheckGameOver()
        {
            if (Players.Any(player => (player.History.FindAll(o => o == RollResult.Jackpot)).Count == 2)
                || Players.All(player => player.History.Count == 6))
            {
                _isGameOver = true;
            }
        }

    }
}
