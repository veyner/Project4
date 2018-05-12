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
    class Fighter
    {
        public int HP { get; set; }
        public bool Block { get; set; }
        /// <summary>
        /// конструктор для генерации случайного числа
        /// </summary>
        private Random _random; 
        public Fighter(Random rnd)
        {
            _random = rnd;
        }

        public void LeftPunch(Fighter opponent)
        {
            MakePunch(opponent,1,5);
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
                opponent.HP -= damage+1;
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

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
        }
    }
}
