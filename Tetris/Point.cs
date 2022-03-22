using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Point
    {
        public int x;
        public int y;
        public char c;

        public Point(int a, int b, char symb)
        {
            x = a;
            y = b;
            c = symb;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        internal void Move(Direction dir)
        {
            switch(dir)
            {
                case Direction.DOWN:
                    y++;
                    break;
                case Direction.LEFT:
                    x--;
                    break;
                case Direction.RIGHT:
                    x++;
                    break;
            }
        }

        public void hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
