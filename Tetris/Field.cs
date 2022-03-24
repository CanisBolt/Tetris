using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        private static int _width = 20;
        private static int _height = 20;
        private static bool[][] _heap;

        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(_width, _height);
                Console.SetBufferSize(_width, _height);
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                Console.SetWindowSize(_width, _height);
                Console.SetBufferSize(_width, _height);
            }
        }

        static Field()
        {
            _heap = new bool[Height][];

            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static void TryDeleteLines()
        {
            for(int j = 0; j < Height; j++)
            {
                int counter = 0;

                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                        counter++;
                }
                if (counter == Width)
                {
                    DeleteLines(j);
                    Redraw();
                }
            }
        }

        private static void DeleteLines(int line)
        {
            for(int j = line; j >= 0; j--)
            {
                for(int i =0; i < Width; i++)
                {
                    if (j == 0)
                        _heap[j][i] = false;
                    else
                        _heap[j][i] = _heap[j - 1][i];
                }
            }
        }

        private static void Redraw()
        {
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                        Drawer.DrawPoint(i, j);
                    else
                        Drawer.HidePoint(i, j);
                }
            }
        }

        public static void AddFigure(Figure fig)
        {
            foreach(var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }
    }
}
