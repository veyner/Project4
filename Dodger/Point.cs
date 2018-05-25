using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodger
{
    internal class Point
    {
        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(Vector speed)
        {
            X += speed.X;
            Y += speed.Y;
        }

        public override bool Equals(object obj)
        {
            var point = (Point)obj;
            return point.X == X && point.Y == Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}