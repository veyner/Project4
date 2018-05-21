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

        public int X { get; set; }
        public int Y { get; set; }
    }
}