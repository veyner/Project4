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
        public void UserMenu()
        {
            Console.WriteLine("Начать новую игру - нажмите 1");
            Console.WriteLine("Загрузить сохраненную игру - нажмите 2");
            Console.WriteLine("Сменить квест - нажмите 3");
        }
    }
}