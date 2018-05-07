using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertHall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество интервалов, на которых замерялась АЧХ");
            var intervals = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите усредненная громкость через пробел");
            var midVolString = Console.ReadLine();
            var midVolArray = midVolString.Split(' ');
            var midVol = new int[midVolArray.Length];
            for (var f = 0; f < midVolArray.Length; f++)
            {
                midVol[f] = int.Parse(midVolArray[f]);
            }
            var maxMidVolume = midVol.Max();
            bool[,] middleVolume = new bool[intervals, maxMidVolume];

            for (var row = 0; row < intervals; row++)
            {
                for (var col = 0; col < midVol[row]; col++)
                {
                    middleVolume[row, col] = true;
                }
            }
            var amplifier = 0;
            for (var col = 0; col < maxMidVolume; col++)
            {
                var lastVolume = true;
                for(var row = 0; row < intervals; row++)
                {
                    if (middleVolume[row, col] == false && lastVolume==true) 
                    {
                        amplifier++;
                    }
                    lastVolume = middleVolume[row, col];
                }
            }
            Console.WriteLine("{0}", amplifier);
            Console.ReadLine();
        }
    }
}
