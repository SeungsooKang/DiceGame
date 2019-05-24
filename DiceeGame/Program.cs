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
            Dice d1 = new Dice();
            d1.Roll();
            Console.WriteLine(d1.Face);
        }
    }
}
