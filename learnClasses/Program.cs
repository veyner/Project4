using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnClasses
{
    /// <summary>
    /// описание единичного объекта (продукта)
    /// </summary>
    class Product
    {
        /// <summary>
        /// свойства объекта (продукта)
        /// </summary>
        public decimal Price { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
    /// <summary>
    /// описание общего объекта (инвентаря), в который войдут единичные продукты
    /// </summary>
    class Inventory
    {
        /// <summary>
        /// конструктор класса - создает список объектов (продуктов)
        /// </summary>
        public Inventory()
        {
            Storage = new List<Product>();
        }
        /// <summary>
        /// непосредственно список объектов
        /// </summary>
        public List<Product> Storage { get; set; }
        /// <summary>
        /// добавление объектов в инвентарь
        /// </summary>
        /// <param name="product"> название объекта</param>
        public void AddProduct(Product product)
        {
            Storage.Add(product);
        }
        /// <summary>
        /// вычисление общей стоимости всех продуктов в инвентаре
        /// </summary>
        /// <returns>общая стоимость</returns>
        public decimal InventoryTotal()
        {
            decimal value = 0;
            foreach (var prod in Storage)
            {
                value += prod.Price*prod.Quantity;
            }
            return value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // создание единичного инвернтаря
            var inverntory = new Inventory();
            // создание единичного объекта с вводом значения свойств и запись объекта в список "инвентарь"
            var apple = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Quantity = 3
            };
            inverntory.AddProduct(apple);
            var pen = new Product()
            {
                Id = Guid.NewGuid(),
                Price = 5,
                Quantity = 2
            };
            inverntory.AddProduct(pen);
            var total = inverntory.InventoryTotal();
            Console.WriteLine("{0}", total);
            Console.ReadLine();
        }
    }
}
