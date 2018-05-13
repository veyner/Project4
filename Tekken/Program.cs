using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekken
{
    /// <summary>
    /// описание бойца, нанесения ударов
    /// </summary>
    internal class Fighter
    {
        public int HP { get; set; }
        public bool Block { get; set; }
        public string Name { get; set; }

        private Random _random;

        /// <summary>
        /// конструктор для генерации случайного числа
        /// </summary>
        public Fighter(Random rnd)
        {
            _random = rnd;
        }

        public void LeftPunch(Fighter opponent)
        {
            MakePunch(opponent, 1, 5);
        }

        public void RightPunch(Fighter opponent)
        {
            MakePunch(opponent, 2, 5);
        }

        public void LegPunch(Fighter opponent)
        {
            MakePunch(opponent, 3, 9);
        }

        public void Blocking()
        {
            Block = true;
        }

        /// <summary>
        /// функция нанесения удара
        /// </summary>
        /// <param name="opponent">оппонент</param>
        /// <param name="damage">количество урона</param>
        /// <param name="interval">интервал для определения, какой удар был нанесен</param>
        private void MakePunch(Fighter opponent, int damage, int interval)
        {
            // генерация случайного числа в заданном промежутке
            int twoDices = _random.Next(2, 13);
            if (twoDices == 12)
            {
                opponent.HP -= damage + 1;
            }
            else if (opponent.Block)
            {
                opponent.Block = false;
            }
            else if (twoDices >= interval)
            {
                opponent.HP -= damage;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            var fighter1 = new Fighter(rnd) { HP = 10, Name = "Bob" };
            var fighter2 = new Fighter(rnd) { HP = 10, Name = "Paul" };
            var fighter = fighter2;
            var opponent = fighter1;

            while (opponent.HP > 0)
            {
                var i = fighter;
                fighter = opponent;
                opponent = i;

                Console.Write("Выберите действие и введите соответствующую цифру\n Левый удар - 1\n Правый удар - 2\n Удар ногой - 3\n Блок - 4\n");
                var punchOrBlock = int.Parse(Console.ReadLine());

                switch (punchOrBlock)
                {
                    case 1:
                        fighter.LeftPunch(opponent);
                        break;

                    case 2:
                        fighter.RightPunch(opponent);
                        break;

                    case 3:
                        fighter.LegPunch(opponent);
                        break;

                    case 4:
                        fighter.Blocking();
                        break;
                }

                Console.WriteLine("{0} - здоровье {1}\n{2} - здоровье {3}", fighter1.HP, fighter1.Name, fighter2.HP, fighter2.Name);
            }

            Console.WriteLine("{0} Win", fighter.Name);
            Console.ReadLine();
        }
    }
}