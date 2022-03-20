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

            Point p1 = new Point(2, 3, '*');
            p1.Draw();

            Point p2 = new Point(5, 5, '$');
            p2.Draw();

            Console.ReadKey();
        }
    }
}
