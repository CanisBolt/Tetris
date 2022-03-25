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

        public void Move(Direction dir)
        {
            foreach (Point p in Points)
            {
                p.Move(dir);
            }
        }

        public Result TryMove(Direction dir)
        {
            Hide();

            Move(dir);

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(dir));

            Draw();

            return result;
        }

        public Result TryRotate()
        {
            Hide();
            Rotate();

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Rotate();

            Draw();

            return result;
        }

        private Direction Reverse(Direction dir)
        {
            switch(dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.UP:
                    return Direction.DOWN;
                case Direction.DOWN:
                    return Direction.UP;
            }
            return dir;
        }

        private Result VerifyPosition()
        {
            foreach(Point p in Points)
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

        public void Hide()
        {
            foreach(Point p in Points)
            {
                p.Hide();
            }
        }

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }

        public abstract void Rotate();

    }
}
