using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorCoords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество базовых станций");
            var baseStation = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите название оператора и ниже станции координаты и ее радиус через пробел");
            var operatorsAndStationCoords = new Tuple<string,int,int,int>[baseStation];
            for (var i = 0; i < baseStation; i++)
            {
                var netOperator = Console.ReadLine();
                var coordsString = Console.ReadLine();
                var coordsArray = coordsString.Split(' ');
                var coordX = int.Parse(coordsArray[0]);
                var coordY = int.Parse(coordsArray[1]);
                var radius = int.Parse(coordsArray[2]);
                operatorsAndStationCoords[i] = new Tuple<string, int, int, int>(netOperator, coordX, coordY, radius);
            }
            Console.WriteLine("Введите ваши координаты через пробел");
            var myCoordsString = Console.ReadLine();
            var myCoordsArray = myCoordsString.Split(' ');
            var myCoordX = int.Parse(myCoordsArray[0]);
            var myCoordY = int.Parse(myCoordsArray[1]);

            var operatorsList = new List<string>();
            foreach (var k in operatorsAndStationCoords)
            {
                if (!operatorsList.Contains(k.Item1))
                {
                    operatorsList.Add(k.Item1);
                }
            }
            var operatorsAndStations = new List<Tuple<string, int>>();

            foreach (var t in operatorsList)
            {
                var supportedStation = 0;
                foreach (var j in operatorsAndStationCoords)
                {
                    if (t == j.Item1)
                    {
                        var range = RangeBetweenPoints(myCoordX, myCoordY, j.Item2, j.Item3);
                        if (j.Item4 - range > 0)
                        {
                            supportedStation++;
                        }
                    }
                }
                operatorsAndStations.Add(Tuple.Create<string, int>(t, supportedStation));
            }
            Console.WriteLine("{0}", operatorsAndStations.Count);
            foreach (var o in operatorsAndStations)
            {
                Console.WriteLine("{0} {1}", o.Item1, o.Item2);
            }
            Console.ReadLine();
        }
        static double RangeBetweenPoints(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
