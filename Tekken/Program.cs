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

        public int LeftPunch(Fighter opponent, int twoDices)
        {
            return MakePunch(opponent, 1, 5, twoDices);
        }

        public int RightPunch(Fighter opponent, int twoDices)
        {
            return MakePunch(opponent, 2, 5, twoDices);
        }

        public int LegPunch(Fighter opponent, int twoDices)
        {
            return MakePunch(opponent, 3, 9, twoDices);
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

        private int MakePunch(Fighter opponent, int damage, int interval, int twoDices)
        {
            int dealedDamage = 0;
            if (twoDices == 12)
            {
                dealedDamage = damage + 1;
            }
            else if (opponent.Block)
            {
                opponent.Block = false;
            }
            else if (twoDices >= interval)
            {
                dealedDamage = damage;
            }
            opponent.HP -= dealedDamage;
            return dealedDamage;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            var fighter1 = new Fighter() { HP = 10, Name = "Денис" };
            var fighter2 = new Fighter() { HP = 10, Name = "Олег" };
            var fighter = fighter2;
            var opponent = fighter1;

            while (opponent.HP > 0)
            {
                var i = fighter;
                fighter = opponent;
                opponent = i;

                Console.WriteLine("\nХодит {0}", fighter.Name);
                Console.WriteLine("Выберите действие и введите соответствующую цифру\n1: Удар левой рукой 2: Удар правой рукой 3: Удар ногой 4: Блок - 4");
                var punchOrBlock = int.Parse(Console.ReadLine());
                int twoDices = rnd.Next(2, 13);
                Console.WriteLine("Бросок костей - {0}", twoDices);
                int damage = 0;
                switch (punchOrBlock)
                {
                    case 1:
                        damage = fighter.LeftPunch(opponent, twoDices);
                        Console.Write("{0} наносит удар левой рукой", fighter.Name);
                        break;

                    case 2:
                        damage = fighter.RightPunch(opponent, twoDices);
                        Console.Write("{0} наносит удар правой рукой", fighter.Name);
                        break;

                    case 3:
                        fighter.LegPunch(opponent, twoDices);
                        Console.Write("{0} наносит удар ногой", fighter.Name);
                        break;

                    case 4:
                        fighter.Blocking();
                        Console.Write("{0} блокирует следующий удар", fighter.Name);
                        break;
                }
                Console.WriteLine(" и наносит {0}ед. урона.", damage);
                Console.WriteLine("Здоровье {0}: {1}ед. Здоровье {2}: {3}ед.", fighter1.Name, fighter1.HP, fighter2.Name, fighter2.HP);
            }

            Console.WriteLine("Побеждает {0}!", fighter.Name);
            Console.ReadLine();
        }
    }
}