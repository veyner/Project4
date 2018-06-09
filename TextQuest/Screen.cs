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

        public bool HasSelectionOption(Screen currentScreen)
        {
            return currentScreen.SelectionOption.Any();
        }

        public void DrawOptions(Screen currentScreen, int playerScore)
        {
            for (int j = 0; j < currentScreen.SelectionOption.Length; j++)
            {
                if (playerScore >= currentScreen.SelectionOption[j].OpenScore)
                {
                    Console.WriteLine("{0}", currentScreen.SelectionOption[j].Text);
                }
            }
        }
    }
}