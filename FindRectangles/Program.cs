using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк, количество чисел в строках и диапазон чисел через пробел");
            var numberString = Console.ReadLine();
            var numbersStrings = numberString.Split(' ');
            var lines = int.Parse(numbersStrings[0]);
            var columns = int.Parse(numbersStrings[1]);
            var range = int.Parse(numbersStrings[2]);

            Console.WriteLine("Введите числа через пробел (необходимо соблюдать ранее заданное количество чисел в каждой строке)");
            int[,] coordArray = new int[lines, columns];
            for (var i=0;i<lines;i++)
            {
                var numString = Console.ReadLine();
                var numStingsArray = numString.Split(' ');
                for (var j = 0; j < columns; j++)
                {
                    coordArray[i, j] = int.Parse(numStingsArray[j]);
                }
            }
            for (var col=0;col<columns;col++)
            {
                for (var row=0;row<lines/2;row++)
                {
                    var l = coordArray[row, col];
                    coordArray[row, col] = coordArray[lines-row-1, col];
                    coordArray[lines-row-1, col] = l;
                }
            }
            for (var r = 1; r <= range;r++)
            {
                for (var col = 0; col < columns; col++)
                {
                    for (var row=0;row<lines;row++)
                    {
                        if (coordArray[row, col] == r)
                        {
                            Console.Write("{0} ", col);
                            col = columns;
                            break;
                        }
                    }
                }

                for (var row = 0; row < lines; row++)
                {
                    for (var col = 0; col < columns; col++)
                    {
                        if (coordArray[row, col] == r)
                        {
                            Console.Write("{0} ", row);
                            row = lines;
                            break;
                        }
                    }
                }

                for (var col=columns-1;col>0;col--)
                {
                    for(var row=lines-1;row>0;row--)
                    {
                        if (coordArray[row, col]==r)
                        {
                            Console.Write ("{0} ",col+1 );
                            col = -1;
                            break;
                        }
                    }
                }
                
                for(var row=lines-1;row>0;row--)
                {
                    for(var col=columns-1;col>0;col--)
                    {
                        if(coordArray[row, col] == r)
                        {
                            Console.Write("{0} ", row+1);
                            row = -1;
                            break;
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
