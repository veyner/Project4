using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class SaveMenu
    {
        public void ShowMenu(GameState gameState)
        {
            Console.WriteLine("Введите название сохранения");
            gameState.Name = Console.ReadLine();
            new GameSaveManager().SaveGame(gameState);
        }
    }
}