using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenDots
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество точек");
            var allDots = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите координаты точек целыми числами через пробел");
            var dotsArray = new int[allDots * 2];
            for (var i = 0; i < allDots * 2; i = i + 2)
            {
                var j = Console.ReadLine();
                var dotsString = j.Split(' ');
                dotsArray[i] = int.Parse(dotsString[0]);
                dotsArray[i + 1] = int.Parse(dotsString[1]);
            }
            var distanceArray = new double[((allDots - 1) * allDots) / 2];
            var t = 0;
            for (var x = 0; x < dotsArray.Length; x = x + 2)
            {
                for (var y = x + 2; y < dotsArray.Length; y = y + 2)
                {
                    distanceArray[t] = Math.Sqrt(Math.Pow((dotsArray[y] - dotsArray[x]), 2) + Math.Pow(dotsArray[y + 1] - dotsArray[x + 1], 2));
                    t++;
                }
            }
            var resultArray = distanceArray.Distinct().ToArray();
            var l = resultArray.Count();
            Console.WriteLine("{0}", l);
            foreach (var resultNumber in resultArray)
            {
                Console.WriteLine("{0}", resultNumber);
            }
            Console.ReadLine();
        }
    }
}
