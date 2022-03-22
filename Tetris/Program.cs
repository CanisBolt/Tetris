﻿using System;
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

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s;

            while (true)
            {
                FigureFall(out s, generator);
                s.Draw();
            }

            Console.ReadKey();
        }

        static void FigureFall(out Figure fig, FigureGenerator gen)
        {
            fig = gen.GetNewFigure();
            for (int i = 0; i < 20; i++)
            {
                fig.Hide();
                fig.Move(Direction.DOWN);
                fig.Draw();
                Thread.Sleep(200);
            }
        }
    }
}
