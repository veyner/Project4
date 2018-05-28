using System;
using Humanizer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Humanizer.Inflections;

namespace BullNCow
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            Vocabularies.Default.AddIrregular("корова", "коровы");
            Vocabularies.Default.AddIrregular("бык", "быка");
            Console.WriteLine("Загадайте 4-значное число, состоящее из неповторяющихся цифр");
            var firstNumber = Console.ReadLine();
            Console.Clear();
            var bull = 0;
            var cow = 0;
            var score = 0;
            Console.WriteLine("Необходимо угадать загаданное число за ограниченное число ходов, вводя 4-значные числа");
            for (; bull < 4;)
            {
                var secondNumber = Console.ReadLine();
                for (int i = 0; i < secondNumber.Length; i++)
                {
                    var k = firstNumber.IndexOf(secondNumber[i]);
                    if (k == i)
                    {
                        bull++;
                    }
                    else if (k != -1)
                    {
                        cow++;
                    }
                }
                score++;
                Console.WriteLine("Бык".ToQuantity(bull));
                Console.WriteLine("Корова".ToQuantity(cow));

                if (bull == 4)
                {
                    Console.WriteLine("Вы угадали число за {0} ходов", score);
                    break;
                }
                cow = 0;
                bull = 0;
            }
            Console.ReadLine();
        }
    }
}