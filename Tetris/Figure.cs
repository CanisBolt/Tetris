using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        public Point[] Points = new Point[4];

        public void Draw()
        {
            foreach (Point p in Points)
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

        public Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
                Points = clone;

            Draw();

            return result;
        }

        public Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
                Points = clone;

            Draw();

            return result;
        }

        private Result VerifyPosition(Point[] plist)
        {
            foreach(Point p in plist)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;
                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;
                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
        }

        private Point[] Clone()
        {
            var newPoints = new Point[Points.Length];
            for (int i = 0; i < Points.Length; i++)
            {
                newPoints[i] = new Point(Points[i]);
            }
            return newPoints;
        }

        public void Hide()
        {
            foreach(Point p in Points)
            {
                p.Hide();
            }
        }

        public abstract void Rotate(Point[] plist);

    }
}
