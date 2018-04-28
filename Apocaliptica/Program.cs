using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apocalyptica
{
    class Program
    {
        static void Main(string[] args)
        {

        
              
            Console.WriteLine("Введите количество людей");
            var peopleCount = int.Parse(Console.ReadLine());
            var minimalValue = double.MaxValue;
            Console.WriteLine("Введите количество банок и количество спичек через пробел");
            for (int i = 0; i < peopleCount; i++)
            {
                var stringarray = Console.ReadLine();
                var stringNumbers = stringarray.Split(' ');
                var b = double.Parse(stringNumbers[0]);
                var s = double.Parse(stringNumbers[1]);
                var currentValue = b / s;
                if (currentValue < minimalValue)
                    minimalValue=currentValue;
            }
            var result = minimalValue * 1000;
            
            Console.WriteLine(string.Format("{0:F2}",result));
            Console.ReadLine();

        }
    }
}
