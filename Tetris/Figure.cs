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

        public void Move(Point[] plist, Direction dir)
        {
            foreach (Point p in plist)
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

        public void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            if(VerifyPosition(clone))
                points = clone;

            Draw();
        }

        private bool VerifyPosition(Point[] plist)
        {
            foreach(Point p in plist)
            {
                if(p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
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
                p.Hide();
            }
        }

        public abstract void Rotate(Point[] plist);

    }
}
