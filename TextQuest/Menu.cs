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
                Console.WriteLine("Добро пожаловать в квест - {0}", currentQuest.Name);
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Начать новую игру");
                Console.WriteLine("2. Загрузить сохраненную игру");
                Console.WriteLine("3. Сменить квест");
                Console.WriteLine("0. Выход");

                var choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    new Game(currentQuest).GameLoop(0, 0);
                }
                if (choice == 2)
                {
                    Console.Clear();
                    var saveList = new GameSaveManager().GetSaves(Properties.Settings.Default.PathToSaves);
                    var currentQuestSaves = new List<GameState>();
                    foreach (var save in saveList)
                    {
                        if (currentQuest.Name == save.Name)
                        {
                            currentQuestSaves.Add(save);
                        }
                    }

                    Console.WriteLine("Выберите сохранение:");
                    for (var i = 0; i < currentQuestSaves.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, currentQuestSaves[i].Name);
                    }

                    var point = int.Parse(Console.ReadLine()) - 1;
                    new Game(currentQuest).GameLoop(saveList[point].ArcID, saveList[point].ScreenNumber);
                }
                if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите квест:");
                    for (var i = 0; i < _quests.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, _quests[i].Name);
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