using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        //public void Move(Direction dir)
        //{
        //    Hide();
        //    foreach(Point p in points)
        //    {
        //        p.Move(dir);
        //    }
        //    Draw();
        //}
        public void Move(Point[] Plist, Direction dir)
        {
            foreach (Point p in Plist)
            {
                p.Move(dir);
            }
        }

        public void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            if(VerifyPosition(clone))
                points = clone;

            Draw();
        }

        private bool VerifyPosition(Point[] Plist)
        {
            foreach(Point p in Plist)
            {
                if(p.x < 0 || p.y < 0 || p.x >= 40 || p.y >= 30)
                {
                    return false;
                }
            }
            return true;
        }

        private Point[] Clone()
        {
            var newPoints = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.hide();
            }
        }

        public abstract void Rotate();

    }
}
