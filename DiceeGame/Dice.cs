using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceeGame
{
    class Dice
    {
        private int _face;
        public int Face
        {
            get { return _face; }
        }

        private int _max;
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public Dice(int max = 6)
        {
            _max = max;
        }

        public void Roll()
        {
            Random rnd = new Random();
            _face = rnd.Next(1, _max + 1);
        }

    }
}
