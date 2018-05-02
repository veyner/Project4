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
            for (var i = 0; i < lines; i++)
            {
                var numString = Console.ReadLine();
                var numStingsArray = numString.Split(' ');
                for (var j = 0; j < columns; j++)
                {
                    coordArray[i, j] = int.Parse(numStingsArray[j]);
                }
            }
            ReflectArrayHorizontaly(coordArray,columns,lines);

            for (var numberOfRectangle = 1; numberOfRectangle <= range; numberOfRectangle++)
            {
                var x1 = FindCoords(coordArray, 0, 0, columns, lines, numberOfRectangle,true);
                var y1 = FindCoords(coordArray, 0, 0, lines, columns, numberOfRectangle,false);
                var x2 = FindCoords(coordArray, columns - 1, lines - 1, -1,-1, numberOfRectangle,true);
                var y2 = FindCoords(coordArray, lines-1, columns-1, -1, -1, numberOfRectangle,false);
                Console.WriteLine("{0} {1} {2} {3}", x1, y1, x2+1, y2+1);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Нахождение координат прямоугольников
        /// </summary>
        /// <param name="coordArray">Массив прямоугольников</param>
        /// <param name="startX">Начало вычисления координат по оси Х</param>
        /// <param name="startY">Начало вычисления координат по оси Y</param>
        /// <param name="endX">Конец координат по оси Х</param>
        /// <param name="endY">Конец координат по оси Y</param>
        /// <param name="numberOfRectangle">Номер прямоугольника</param>
        /// <param name="isHorizontal">Направление вычисления (по вертикали-true;по горизонтали-false)</param>
        /// <returns>Координату</returns>
        static int FindCoords(int[,] coordArray, int startX, int startY, int endX, int endY, int numberOfRectangle, bool isHorizontal)
        {
            // coefForwardOrBackward - коеффициент направления вычисления координаты (Forward - 1;Backward - -1)
            var coefForwardOrBackward = 1;
            if (startX > endX)
            {
                coefForwardOrBackward = -1;
            }
            for (var col = startX; col != endX; col = col + coefForwardOrBackward)
            {
                for (var row = startY; row != endY; row = row + coefForwardOrBackward)
                {
                    if (isHorizontal)
                    {
                        if (coordArray[row, col] == numberOfRectangle)
                        {
                            return col;
                        }
                    }
                    else
                    {
                        if (coordArray[col, row] == numberOfRectangle)
                        {
                            return col;
                        }
                    } 
                }
            }
            return 0;
        }
        /// <summary>
        /// Функция, меняющая члены  массива
        /// </summary>
        /// <param name="coordArray">Массив прямоугольников</param>
        /// <param name="columns">Столбцы</param>
        /// <param name="lines">Строки</param>
        /// <returns>Измененный массив прямоугольников</returns>
        static void ReflectArrayHorizontaly(int[,] coordArray, int columns, int lines)
        {
            for (var col = 0; col < columns; col++)
            {
                for (var row = 0; row < lines / 2; row++)
                {
                    var l = coordArray[row, col];
                    coordArray[row, col] = coordArray[lines - row - 1, col];
                    coordArray[lines - row - 1, col] = l;
                }
            }
        }
    }
}
