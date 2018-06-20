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
        private GameState _gameState = new GameState();
        private List<Arc> _questData = new List<Arc>();

        public void GameLoop()
        {
            _questData = LoadQuestData();
            _gameState = LoadGame();

            var currentArc = _questData[_gameState.ArcID];
            var currentScreen = currentArc.Screens[_gameState.ScreenNumber];
            var playerScore = 0;
            while (true)
            {
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
                    }
                }

                // СЧИТЫВАЕМ ДЕЙСТВИЕ ПОЛЬЗОВАТЕЛЯ
                // Считываем пользовательский ввод
                var userInput = Console.ReadLine();
                if (ProcessUserInput(userInput))
                {
                    continue;
                }

                // ОБНОВЛЯЕМ ИГРОВУЮ ЛОГИКУ
                if (currentScreen.HasSelectionOption(currentScreen))
                {
                    var selectedOption = int.Parse(userInput) - 1;
                    playerScore = playerScore + currentScreen.SelectionOption[selectedOption].Point;
                    Console.WriteLine("Ваши набранные баллы - {0}", playerScore);
                    currentArc = _questData[currentScreen.SelectionOption[selectedOption].Destination];
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
                        Console.WriteLine("Для выхода нажмите любую клавишу");
                        break; // Скрины кончились. Конец игры.
                    }
                }

                _gameState.ArcID = currentArc.ID;
                _gameState.ScreenNumber = currentScreen.Number;
            }
            Console.ReadLine();
        }

        private GameState LoadGame()
        {
            // TODO: Проверить существование файла и не пустой ли он
            // TODO: Вынести save.json либо в константы либо в properties приложения
            using (var reader = new StreamReader(Properties.Settings.Default.PathToSaveFile))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<GameState>(json);
            }
        }

        private void SaveGame(GameState gameState)
        {
            // TODO: Вынести save.json либо в константы либо в properties приложения
            using (var writer = new StreamWriter(Properties.Settings.Default.PathToSaveFile))
            {
                var json = JsonConvert.SerializeObject(gameState);
                writer.Write(json);
            }
        }

        // Обработка пользовательского ввода (управление меню)
        private bool ProcessUserInput(string userInput)
        {
            switch (userInput)
            {
                case "s":
                    SaveGame(_gameState);
                    break;

                case "l":
                    _gameState = LoadGame();
                    break;

                default:
                    return false; // Ползьзователь ввел выбор
            }

            return true; // Пользователь ввел команду меню
        }
    }
}