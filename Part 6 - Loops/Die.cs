using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_6___Loops
{
    public class Die
    {
        private Random _generator;
        private int _roll;

        public Die(int _roll)
        {
            _generator = new Random();
            _roll = _generator.Next(1, 7);
        }

        public int Roll
        { get { return _roll; } }

        public override string ToString()
        {
            return _roll.ToString();
        }

        public void RollDie()
        {
            _roll = _generator.Next(1, 7);
        }

        public void DrawDie()
        {
            if (_roll == 1)
            {
                Console.WriteLine("-----\r\n|   |\r\n| o |\r\n|   |\r\n-----");
            }
            else if (_roll == 2)
            {
                Console.WriteLine("-----\r\n|o  |\r\n|   |\r\n|  o|\r\n-----");
            }
            else if (_roll == 3)
            {
                Console.WriteLine("-----\r\n|o  |\r\n| o |\r\n|  o|\r\n-----");
            }
            else if (_roll == 4)
            {
                Console.WriteLine("-----\r\n|o o|\r\n|   |\r\n|o o|\r\n-----");
            }
            else if (_roll == 5)
            {
                Console.WriteLine("-----\r\n|o o|\r\n| o |\r\n|o o|\r\n-----");
            }
            else
            {
                Console.WriteLine("-----\r\n|o o|\r\n|o o|\r\n|o o|\r\n-----");
            }
        }
    }
}
