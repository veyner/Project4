using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class GameState
    {
        public string Name { get; set; }
        public string QuestName { get; set; }
        public int ArcID { get; set; }
        public int ScreenNumber { get; set; }
    }
}