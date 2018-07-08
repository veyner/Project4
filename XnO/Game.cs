using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XnO
{
    internal class Game
    {
        public void PlayGame()
        {
            var numberField = new char[9];
            var currentSymbol = 'X';
            while (true)
            {
                Console.Clear();
                Console.WriteLine("{0}{1}{2}", numberField[0], numberField[1], numberField[2]);
                Console.WriteLine("{0}{1}{2}", numberField[3], numberField[4], numberField[5]);
                Console.WriteLine("{0}{1}{2}", numberField[6], numberField[7], numberField[8]);
                if (WinGame(numberField, 'X'))
                {
                    Console.WriteLine("Выиграл X");
                    break;
                }
                if (WinGame(numberField, 'O'))
                {
                    Console.WriteLine("Выиграл O");
                    break;
                }
                Console.WriteLine("Введите номер ячейки");
                var point = int.Parse(Console.ReadLine()) - 1;
                numberField[point] = currentSymbol;

                if (currentSymbol == 'X')
                {
                    currentSymbol = 'O';
                }
                else
                {
                    currentSymbol = 'X';
                }
            }
            Console.ReadLine();
        }

        private bool WinGame(char[] numberField, char currentSymbol)
        {
            var t = false;
            var winString = new char[3];
            for (var i = 0; i < 3; i++)
            {
                var k = 0;
                for (var j = 0; j < numberField.Length; j += 3)
                {
                    winString[k] = numberField[j];
                    k++;
                }
                if (winString.All(T => T == currentSymbol))
                {
                    t = true;
                    break;
                }
            }
            for (var j = 0; j < numberField.Length; j += 3)
            {
                var k = 0;
                for (var i = 0; i < 3; i++)
                {
                    winString[k] = numberField[i];
                    k++;
                }
                if (winString.All(T => T == currentSymbol))
                {
                    t = true;
                    break;
                }
            }
            var l = 0;
            for (var i = 0; i < numberField.Length; i += 4)
            {
                winString[l] = numberField[i];
                l++;
                if (winString.All(T => T == currentSymbol))
                {
                    t = true;
                    break;
                }
            }
            var p = 0;
            for (var i = 2; i < 7; i += 2)
            {
                winString[p] = numberField[i];
                p++;
                if (winString.All(T => T == currentSymbol))
                {
                    t = true;
                    break;
                }
            }
            return t;
        }
    }
}