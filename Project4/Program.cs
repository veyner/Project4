using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ввод количества цифр в массиве
            ввод цифр на каждой строке
            сортировка по возрастанию
            вывод отсортированных цифр*/
            Console.WriteLine("Введите числа через пробел: ");
            var inputstring=Console.ReadLine();
            var stringArray=inputstring.Split(' ');
            var arrayNumbers = new int [stringArray.Length];

            for (int t = 0; t < stringArray.Length; t++)
                arrayNumbers[t]=int.Parse(stringArray[t]);

            /*Console.WriteLine("Введите количество цифр в массиве: ");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] arrayNumbers = new int[arrayLength];
            
            for (int arrayMember = 0; arrayMember < arrayLength; arrayMember++)
            {
                Console.Write("Введите число: ");
                arrayNumbers[arrayMember] = int.Parse(Console.ReadLine());
            }*/

            for(int cycleNumber=0;cycleNumber<arrayNumbers.Length;cycleNumber++)
                {
                for (int arrayMember = 0; arrayMember < arrayNumbers.Length - 1; arrayMember++)
                {
                    if (arrayNumbers[arrayMember] > arrayNumbers[arrayMember + 1])
                    {
                        int elem = arrayNumbers[arrayMember + 1];
                        arrayNumbers[arrayMember + 1] = arrayNumbers[arrayMember];
                        arrayNumbers[arrayMember] = elem;
                    }
                }
            }
            for (int arrayMember = 0; arrayMember < arrayNumbers.Length; arrayMember++)
                Console.Write("{0} ",arrayNumbers[arrayMember]);

            Console.Read();

        }
    }
}
