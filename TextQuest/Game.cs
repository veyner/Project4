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
                Console.WriteLine(" ");

                // Если есть выбор - рисуем
                if (currentScreen.HasSelectionOption(currentScreen))
                {
                    currentScreen.DrawOptions(currentScreen, playerScore);
                }
                else
                {
                    if (currentArc.HasNextScreen(currentScreen))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Далее");
                        Console.WriteLine("Sk. Пропустить до выбора");
                        Console.WriteLine("S. Меню сохранения");
                        Console.WriteLine("0. Выход в главное меню");
                    }
                }

                // СЧИТЫВАЕМ ДЕЙСТВИЕ ПОЛЬЗОВАТЕЛЯ
                // Считываем пользовательский ввод

                var userInput = Console.ReadLine();

                if (userInput == "Sk")
                {
                    for (var i = currentScreen.Number; i < currentArc.Screens.Length; i++)
                    {
                        if (!currentScreen.HasSelectionOption(currentScreen) && currentArc.HasNextScreen(currentScreen))
                        {
                            currentScreen = currentArc.Screens[currentScreen.Number + 1];
                        }
                        else
                        {
                            break;
                        }
                    }
                    continue;
                }
                //запись сохранения
                if (userInput == "S")
                {
                    var _gamestat = new GameState();
                    _gamestat.QuestName = _quest.Name;
                    _gamestat.ArcID = currentArc.ID;
                    _gamestat.ScreenNumber = currentScreen.Number;

                    new SaveMenu().ShowMenu(_gamestat);
                    continue;
                }
                if (userInput == "0")
                {
                    break;
                }

                // ОБНОВЛЯЕМ ИГРОВУЮ ЛОГИКУ
                if (currentScreen.HasSelectionOption(currentScreen))
                {
                    var selectedOption = int.Parse(userInput) - 1;
                    playerScore = playerScore + currentScreen.SelectionOption[selectedOption].Point;
                    Console.WriteLine("Ваши набранные баллы - {0}", playerScore);
                    Console.ReadLine();
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
                        Console.ReadLine();
                        break; // Скрины кончились. Конец игры.
                    }
                }

                arcNumber = currentArc.ID;
                screenNumber = currentScreen.Number;
            }
        }
    }
}