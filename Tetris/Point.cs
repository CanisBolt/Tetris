using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(int a, int b, char symb)
        {
            X = a;
            Y = b;
            C = symb;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }

        internal void Move(Direction dir)
        {
            switch(dir)
            {
                case Direction.DOWN:
                    Y++;
                    break;
                case Direction.LEFT:
                    X--;
                    break;
                case Direction.RIGHT:
                    X++;
                    break;
                case Direction.UP:
                    Y--;
                    break;
            }
        }

        public void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
