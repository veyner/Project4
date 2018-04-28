using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardsWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа через пробел: ");
            var stringArray = Console.ReadLine();
            var stringNumbers = stringArray.Split(' ');
            var arrayNumbers = new int[stringNumbers.Length];

            for (var t = 0; t < stringNumbers.Length; t++)
                arrayNumbers[t] = int.Parse(stringNumbers[t]);
            
            var mika=0;
            var piter = 0;
            
            for (var t=0; t<arrayNumbers.Length; t++)
            {
                var j = arrayNumbers[t] * (t + 2);
                
                if (t % 2 == 0)
                    mika += j;
                else
                    piter += j;
            }
            var answer = " ";
            if (mika < piter)
                answer = "Win";
            else if (mika == piter)
                answer="?";
            else
                answer="Lost";
            Console.WriteLine("{0}", answer);
            Console.ReadLine();
               
        }
    }
}
