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

        public Point(int a, int b)
        {
            X = a;
            Y = b;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);
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
            DrawerProvider.Drawer.HidePoint(X, Y);
        }
    }
}
