using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Square square = new Square(5, 5, '*');
            Stick stick = new Stick(4, 4, '#');

            Console.ReadKey();
        }
    }
}
