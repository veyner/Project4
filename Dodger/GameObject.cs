using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodger
{
    internal class GameObject
    {
        public GameObject()
        {
            Position = new Point();
            Speed = new Vector();
        }

        public Point Position { get; set; }
        public Vector Speed { get; set; }

        public static GameObject CreateOpponent(Random random, int maxWidth, int maxHeight)
        {
            GameObject opponent = new GameObject();
            int i = random.Next(0, 4);
            if (i == 0)
            {
                opponent.Position.X = maxWidth - 2;
                opponent.Position.Y = random.Next(1, maxHeight);
                opponent.Speed.X = -1;
            }
            else if (i == 1)
            {
                opponent.Position.X = 1;
                opponent.Position.Y = random.Next(1, maxHeight);
                opponent.Speed.X = 1;
            }
            else if (i == 2)
            {
                opponent.Position.X = random.Next(1, maxWidth);
                opponent.Position.Y = 1;
                opponent.Speed.Y = 1;
            }
            else if (i == 3)
            {
                opponent.Position.X = random.Next(1, maxWidth);
                opponent.Position.Y = maxHeight - 2;
                opponent.Speed.Y = -1;
            }
            return opponent;
        }
    }
}