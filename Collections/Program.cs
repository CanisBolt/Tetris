using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums1 = new int[5];
            //nums1[0] = 1;
            //nums1[1] = 2;

            //foreach(int i in nums1)
            //{
            //    Console.WriteLine(i);
            //}

            //Point[] points = new Point[3];
            //points[0] = new Point(1, 2, 'a');
            //points[1] = new Point(3, 4, 'b');
            //points[2] = new Point(5, 6, 'c');

            //foreach(Point p in points)
            //{
            //    p.Draw();
            //}

            char[][] field = new char[3][];
            field[0] = new char[3];
            field[1] = new char[3];
            field[2] = new char[3];

            field[0][0] = 'X';
            field[2][2] = 'O';


            for(int i = 0; i < field.Length; i++)
            {
                for(int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
