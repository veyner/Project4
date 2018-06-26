using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class SaveOption
    {
        public void SaveMenu(GameState gameState)
        {
            Console.WriteLine("Введите название сохранения");
            gameState.Name = Console.ReadLine();
            new GameSaveManager().SaveGame(gameState);
        }
    }
}