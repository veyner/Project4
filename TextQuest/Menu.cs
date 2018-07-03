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

        public void ShowMenu()
        {
            var currentQuest = _quests[0];
            var exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в квест - {0}", currentQuest.Name);
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Начать новую игру");
                Console.WriteLine("2. Загрузить сохраненную игру");
                Console.WriteLine("3. Сменить квест");
                Console.WriteLine("0. Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        new Game(currentQuest).GameLoop(0, 0);
                        break;

                    case "2":
                        LoadSaveMenu(currentQuest);
                        break;

                    case "3":
                        ChangeQuestMenu(currentQuest);
                        break;

                    case "0":
                        exit = false;
                        break;
                }
            }
        }

        private void LoadSaveMenu(Quest currentQuest)
        {
            Console.Clear();
            var saveList = new GameSaveManager().GetSaves(Properties.Settings.Default.PathToSaves);
            var currentQuestSaves = new List<GameState>();
            foreach (var save in saveList)
            {
                if (currentQuest.Name == save.QuestName)
                {
                    currentQuestSaves.Add(save);
                }
            }

            Console.WriteLine("Выберите сохранение:");
            for (var i = 0; i < currentQuestSaves.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, currentQuestSaves[i].Name);
            }
            Console.WriteLine("0. Вернуться в главное меню");
            var point = int.Parse(Console.ReadLine()) - 1;
            if (point == -1)
            {
                return;
            }
            new Game(currentQuest).GameLoop(saveList[point].ArcID, saveList[point].ScreenNumber);
        }

        private void ChangeQuestMenu(Quest currentQuest)
        {
            Console.Clear();
            Console.WriteLine("Выберите квест:");
            for (var i = 0; i < _quests.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, _quests[i].Name);
            }
            Console.WriteLine("0. Вернуться в главное меню");
            var point = int.Parse(Console.ReadLine()) - 1;
            if (point == -1)
            {
                return;
            }
            currentQuest = _quests[point];
        }
    }
}