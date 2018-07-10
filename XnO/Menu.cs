using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XnO
{
    internal class Menu
    {
        public void ShowMenu()
        {
            var exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в Крестики vs Нолики");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Начать новую игру для двух игроков");
                Console.WriteLine("2. Начать новую одиночную игру");
                Console.WriteLine("0. Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        new Game().PlayGame(false);
                        break;

                    case "2":
                        new Game().PlayGame(true);
                        break;

                    case "0":
                        exit = false;
                        break;
                }
            }
        }
    }
}