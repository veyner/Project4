using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextQuest
{
    internal class Game
    {
        private Quest _quest;

        public Game(Quest quest)
        {
            _quest = quest;
        }

        public void GameLoop(int arcNumber, int screenNumber)
        {
            var currentArc = _quest.Arcs[arcNumber];
            var currentScreen = currentArc.Screens[screenNumber];
            var playerScore = 0;
            while (true)
            {
                Console.Clear();
                // ВЫВОДИМ ВСЕ НА ЭКРАН
                // Рисуем скрин
                Console.WriteLine("{0}", currentScreen.Text);

                // Если есть выбор - рисуем
                if (currentScreen.HasSelectionOption(currentScreen))
                {
                    currentScreen.DrawOptions(currentScreen, playerScore);
                }
                else
                {
                    if (currentArc.HasNextScreen(currentScreen))
                    {
                        Console.WriteLine("1. Далее...");
                        Console.WriteLine("Введите S для меню сохранения");
                    }
                }

                // СЧИТЫВАЕМ ДЕЙСТВИЕ ПОЛЬЗОВАТЕЛЯ
                // Считываем пользовательский ввод
                var userInput = Console.ReadLine();

                //запись сохранения
                if (userInput == "S")
                {
                    var _gamestat = new GameState();
                    _gamestat.QuestName = _quest.Name;
                    _gamestat.ArcID = currentArc.ID;
                    _gamestat.ScreenNumber = currentScreen.Number;

                    new SaveOption().SaveMenu(_gamestat);
                    continue;
                }

                // ОБНОВЛЯЕМ ИГРОВУЮ ЛОГИКУ
                if (currentScreen.HasSelectionOption(currentScreen))
                {
                    var selectedOption = int.Parse(userInput) - 1;
                    playerScore = playerScore + currentScreen.SelectionOption[selectedOption].Point;
                    Console.WriteLine("Ваши набранные баллы - {0}", playerScore);
                    currentArc = _quest.Arcs[currentScreen.SelectionOption[selectedOption].Destination];
                    currentScreen = currentArc.Screens[0];
                }
                else
                {
                    if (currentArc.HasNextScreen(currentScreen))
                    {
                        // Переходим на следующий скрин
                        currentScreen = currentArc.Screens[currentScreen.Number + 1];
                    }
                    else
                    {
                        Console.WriteLine("Для выхода в главное меню нажмите любую клавишу");
                        break; // Скрины кончились. Конец игры.
                    }
                }

                arcNumber = currentArc.ID;
                screenNumber = currentScreen.Number;
            }
            Console.ReadLine();
        }
    }
}