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
            List<Quest> _quests = quests;
        }

        public void UserMenu()
        {
            var questName = _quests[0].Name;
            Console.WriteLine("{0}", questName);
            Console.WriteLine("Начать новую игру - нажмите 1");
            Console.WriteLine("Загрузить сохраненную игру - нажмите 2");
            Console.WriteLine("Сменить квест - нажмите 3");
            Console.WriteLine("Выход - нажмите 4");
        }

        public void ChoiceMenu()
        {
            var choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                new Game().GameLoop(0, 0);
            }
            if (choice == 2)
            {
                var saveList = new GameSaveManager().GetSaves(Properties.Settings.Default.PathToSaves);
                Console.WriteLine("Выберите сохранение");
                foreach (var save in saveList)
                {
                    Console.WriteLine("{0}", save.Name);
                }
                var point = int.Parse(Console.ReadLine());
                new Game().GameLoop(saveList[point].ArcID, saveList[point].ScreenNumber);
            }
            if (choice == 3)
            {
            }
        }

        public void SaveMenu(GameState gameState)
        {
            Console.WriteLine("Введите название сохранения");
            var saveName = Console.ReadLine();
            new GameSaveManager().SaveGame(saveName, gameState);
        }
    }
}