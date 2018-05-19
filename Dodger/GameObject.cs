using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRender
{
    internal class GameObject
    {
        public GameObject()
        {
            Position = new Point();
        }

        public Point Position { get; set; }
    }
}