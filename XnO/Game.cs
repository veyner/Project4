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
            var gameField = new char[9];
            var currentPlayer = 'X';
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.WriteLine(" {0} | {1} | {2} ", gameField[0], gameField[1], gameField[2]);
                Console.WriteLine(" ---------");
                Console.WriteLine(" {0} | {1} | {2} ", gameField[3], gameField[4], gameField[5]);
                Console.WriteLine(" ---------");
                Console.WriteLine(" {0} | {1} | {2} ", gameField[6], gameField[7], gameField[8]);
                Console.WriteLine(" ");

                if (CheckGameEnd(gameField, 'X'))
                {
                    Console.WriteLine("Выиграл X");
                    Console.WriteLine("0. Вернуться в главное меню");
                    var backTomenu = int.Parse(Console.ReadLine());
                    if (backTomenu == 0)
                    {
                        break;
                    }
                }
                if (CheckGameEnd(gameField, 'O'))
                {
                    Console.WriteLine("Выиграл O");
                    Console.WriteLine("0. Вернуться в главное меню");
                    var backTomenu = int.Parse(Console.ReadLine());
                    if (backTomenu == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("Введите номер ячейки");
                var userAnswer = Console.ReadLine();
                var cell = 0;
                if (!int.TryParse(userAnswer, out cell) || cell > 9)
                {
                    Console.WriteLine("Вы ввели некорректный номер ячейки. Попробуйте еще раз");
                    Console.ReadLine();
                    continue;
                }

                if (gameField[cell - 1] == 'X' || gameField[cell - 1] == 'O')
                {
                    Console.WriteLine("Ячейка занята. Выберите другую");
                    Console.ReadLine();
                    continue;
                }

                gameField[cell - 1] = currentPlayer;

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        private bool CheckGameEnd(char[] gameField, char currentPlayer)
        {
            var result = false;
            var winString = new char[3];
            //k - номера элемента массива winString
            //Запись столбца gameField в новый массив для проверки выигрыша
            for (var i = 0; i < 3; i++)
            {
                for (int j = 0, k = 0; j < gameField.Length; j += 3, k++)
                {
                    winString[k] = gameField[j];
                }
                //проверка выигрыша
                if (winString.All(T => T == currentPlayer))
                {
                    result = true;
                    break;
                }
            }
            //Запись строки gameField в новый массив для проверки выигрыша
            for (var j = 0; j < gameField.Length; j += 3)
            {
                for (int i = 0, k = 0; i < 3; i++, k++)
                {
                    winString[k] = gameField[i];
                }
                if (winString.All(T => T == currentPlayer))
                {
                    result = true;
                    break;
                }
            }
            //Проверка выигрыша по диагоналям

            Array.Clear(winString, 0, winString.Length);
            for (int i = 0, k = 0; i < gameField.Length; i += 4, k++)
            {
                winString[k] = gameField[i];
                if (winString.All(T => T == currentPlayer))
                {
                    result = true;
                    break;
                }
            }

            Array.Clear(winString, 0, winString.Length);
            for (int i = 2, k = 0; i < 7; i += 2, k++)
            {
                winString[k] = gameField[i];
                if (winString.All(T => T == currentPlayer))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}