using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var bootstraper = new Bootstraper(Properties.Settings.Default.PathToQuests);
            bootstraper.Load();
            if (!bootstraper.Quests.Any())
            {
                Console.WriteLine("Добавьте квесты в {0}", Properties.Settings.Default.PathToQuests);
                return;
            }
            new Game().GameLoop();
        }
    }
}