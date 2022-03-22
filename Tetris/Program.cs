using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Figure[] f = new Figure[2];
            //f[0] = new Square(5, 5, '*');
            f[1] = new Stick(20, 4, '#');
            f[1].Hide();

            f[1].Move(Direction.LEFT);
            f[1].Draw();
            Thread.Sleep(500);
            f[1].Hide();
            Thread.Sleep(500);

            f[1].Move(Direction.DOWN);
            f[1].Draw();
            Thread.Sleep(500);
            f[1].Hide();

            f[1].Rotate();
            f[1].Draw();

            Console.ReadKey();
        }
    }
}
