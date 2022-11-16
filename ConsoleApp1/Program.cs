using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Order
        {

        }

        public abstract class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Milk : Product
        {
            public DateTime ValidTo { get; set; }
        }

        public class Apple : Product
        {
            public string Color { get; set; }
        }

        public interface IService<T>
        {
            void Create(List<T> elements);
            void Update();
            void Delete();
            void Get();
        }

        public class OrderService : IService<Order>
        {
            public void Create(List<Order> orders)
            {
                Console.WriteLine("Uzsakymas buvo sukurtas");
            }

            public void Delete()
            {
                Console.WriteLine("Uzsakymas buvo pasalintas");
            }

            public void Get()
            {
                Console.WriteLine("Uzsakymo duomenys: pristatymo data 2022-11-16 8:45, uzsakovas Daumantas");
            }

            public void Update(/* duomenys */)
            {
                Console.WriteLine("Uzsakymas buvo atnaujintas");
            }
        }

        public class ProductsService : IService<Product>
        {
            public void Create(List<Product> products)
            {
                // issaugome

                // graziname informacija
                string result = "";
                foreach (var product in products)
                {
                    result += product.Name + " " + product.Description + "\n";
                }
                Console.WriteLine($"Produktai {result} buvo sukurti");
            }

            public void Delete()
            {
                Console.WriteLine("Produktas buvo pasalintas");
            }

            public void Get()
            {
                Console.WriteLine("Produktas duomenys: pristatymo data 2022-11-16 8:45, uzsakovas Daumantas");
            }

            public void Update(/* duomenys */)
            {
                Console.WriteLine("Produktas buvo atnaujintas");
            }
        }

        static void Main(string[] args)
        {
            ProductsService productsService = new ProductsService();
            List<Product> products = new List<Product>();

            Milk milk = new Milk();
            Apple apple = new Apple();

            products.Add(milk);
            products.Add(apple);

            productsService.Create(products);
        }
    }
}
