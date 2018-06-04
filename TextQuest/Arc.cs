using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class Arc
    {
        public Screen[] Screens { get; set; }
        public int ID { get; set; }
        public bool HasNextScreen { get; set; }

    }
}