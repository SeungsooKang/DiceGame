using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceeGame
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<RollResult> History { get; set; }

        public Player()
        {
            History = new List<RollResult>();
        }
    }
}
