using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class Screen
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public SelectionOptions[] SelectionOption { get; set; }
    }
}