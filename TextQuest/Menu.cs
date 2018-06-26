using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextQuest
{
    internal class Menu
    {
        private List<Quest> _quests;

        // загружать в меню список квестов и отображать выбранный квест
        public Menu(List<Quest> quests)
        {
            _quests = quests;
        }

        public void UserMenu()
        {
            var currentQuest = _quests[0];
            while (true)
            {
                Console.Clear();
                Console.WriteLine("{0}", currentQuest.Name);
                Console.WriteLine("Начать новую игру - нажмите 1");
                Console.WriteLine("Загрузить сохраненную игру - нажмите 2");
                Console.WriteLine("Сменить квест - нажмите 3");
                Console.WriteLine("Выход - нажмите 4");

                var choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    new Game(currentQuest).GameLoop(0, 0);
                }
                if (choice == 2)
                {
                    var saveList = new GameSaveManager().GetSaves(Properties.Settings.Default.PathToSaves);
                    Console.WriteLine("Выберите сохранение");
                    foreach (var save in saveList)
                    {
                        Console.WriteLine("{0}", save.Name);
                    }
                    var point = int.Parse(Console.ReadLine()) - 1;
                    new Game(currentQuest).GameLoop(saveList[point].ArcID, saveList[point].ScreenNumber);
                }
                if (choice == 3)
                {
                    foreach (var quest in _quests)
                    {
                        Console.WriteLine("{0}", quest.Name);
                    }
                    var point = int.Parse(Console.ReadLine()) - 1;
                    currentQuest = _quests[point];
                }
                if (choice == 4)
                {
                    break;
                }
            }
        }
    }
}