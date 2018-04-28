using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourPriest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите номер жреца-покровителя для каждой конфедерации через пробел");
            var priestArray = Getconfedirationpriests();

            Console.WriteLine("Введите количество поданных заявок");
            var requestString = Console.ReadLine();
            if (!Validate(requestString))
            {
                Console.WriteLine("Введены некорректные данные");
                return;
            }
            var request = int.Parse(requestString);
            
            Console.WriteLine("Введите номер текущего и желаемого жреца по порядку через пробел");
            var newPriestArray = GetCurrentAndFuturePriest(request);
            var result = Change(priestArray, newPriestArray);
            GiveFuturePriest(result);
           

        }
        /// <summary>
        /// Заменяет жрецов на новых жрецов
        /// </summary>
        /// <param name="priestArray">старые жрецы</param>
        /// <param name="newPriestArray">новые жрецы</param>
        /// <returns>массив новых жрецов</returns>
        static int[] Change(int[] priestArray, int[] newPriestArray)
        {
            var resultArray = new int[priestArray.Length];
            for (var j = 0; j < priestArray.Length; j++)
            {
                resultArray[j] = priestArray[j];
                for (var k = 0; k < newPriestArray.Length; k = k + 2)
                {
                    if (resultArray[j] == newPriestArray[k])
                    {
                        resultArray[j] = newPriestArray[k + 1];
                        break;
                    }
                }
            }
            return resultArray;
        }
        /// <summary>
        /// Получает массив нынешних жрецов
        /// </summary>
        /// <returns>массив нынешних жрецов</returns>
        static int[] Getconfedirationpriests()
        {
            var priestString = Console.ReadLine();
            if (!Validate(priestString))
                return null;

            var priestNumbers = priestString.Split(' ');

            if (priestNumbers.Length > 5000 && priestNumbers.Length<1)
            {
                Console.WriteLine("Введено слишком много значений");
                return null;
            }
            foreach (var c in priestNumbers)
            {
                if (string.IsNullOrWhiteSpace(c))
                {
                    Console.WriteLine("Слишком много пробелов между данными");
                        return null;
                }
            }

            var priestArray = new int[priestNumbers.Length];
            for (var i = 0; i < priestArray.Length; i++)
                priestArray[i] = int.Parse(priestNumbers[i]);
            return priestArray;
        }
        /// <summary>
        /// Получает массив заявки на замену жрецов
        /// </summary>
        /// <param name="request">количество заявок</param>
        /// <returns>массив нынешних и будущих жрецов</returns>
        static int[] GetCurrentAndFuturePriest(int request)
        {
            var newPriestArray = new int[request * 2];
            for (var n = 0; n < newPriestArray.Length; n = n + 2)
            {
                var newPriestString = Console.ReadLine();
                if (!Validate(newPriestString))
                    return null;

                var newPriestNumbers = newPriestString.Split(' ');
                if (newPriestNumbers.Length > 2)
                    Console.WriteLine("Вы ввели неправильные данные");
                foreach (var c in newPriestNumbers)
                    if (string.IsNullOrWhiteSpace(c))
                    {
                        Console.WriteLine("Введено слишком много пробелов");
                        return null;
                    }
                newPriestArray[n] = int.Parse(newPriestNumbers[0]);
                newPriestArray[n + 1] = int.Parse(newPriestNumbers[1]);
            }
            return newPriestArray;
        }
        /// <summary>
        /// Выводит массив будущих жрецов
        /// </summary>
        /// <param name="result">результат перестановки старых жрецов на новых по заявкам</param>
        static void GiveFuturePriest(int[] result)
        {
            for (var priestMember = 0; priestMember<result.Length; priestMember++)
            Console.Write("{0}", result[priestMember]);
            Console.ReadLine();
        }
        /// <summary>
        /// Проверяет правильность введенных данных
        /// </summary>
        /// <param name="toValidate">Строка данныз для проверки</param>
        /// <returns>правильно или неправильно введены данные</returns>
        static bool Validate(string toValidate)
        {
            if (string.IsNullOrWhiteSpace(toValidate))
            {
                Console.WriteLine("Вы не ввели данные");
                return false;
            }
            foreach (var t in toValidate)
            {
                if (!char.IsDigit(t) && t != ' ')
                {
                    Console.WriteLine("Вы ввели неверные данные");
                    return false;
                }
            }
            return true;
        }

    }

}

