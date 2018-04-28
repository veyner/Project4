using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace You_are_in_the_Army_now
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество солдат и количество рядов через пробел");
            var stringArray = Console.ReadLine();
            var arrayNumbers = stringArray.Split(' ');
            var soldiers = int.Parse(arrayNumbers[0]);
            var rows = int.Parse(arrayNumbers[1]);

            var result = 0;
            Console.WriteLine("Введите росты по количеству солдат в ряду через пробел");
            for (var i = 0; i < rows; i++)
            {
                var k = Console.ReadLine();
                var heightString = k.Split(' ');
                var heightArray = new int[heightString.Length];
                for (var t = 0; t < heightString.Length; t++)
                    heightArray[t] = int.Parse(heightString[t]);
                for (var j=1; j<heightArray.Length;j++)
                {
                    for (var n = 0; n < j; n++)
                        if (heightArray[n] > heightArray[j])
                            result++;
                }
            }
            Console.WriteLine("{0}", result);
            Console.ReadLine();
        }
    }
}
