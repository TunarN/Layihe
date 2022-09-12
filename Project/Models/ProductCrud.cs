using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Project.Models
{
    class ProductCrud
    {
        public static void Add()
        {
            string name = Console.ReadLine();
            string inqredint = Console.ReadLine();
            int price = Convert.ToInt32(Console.ReadLine());
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = Product.ProductID(), Name = name, Inqredint = inqredint, Price = price });
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\products.json"))
            {
                sw.Write(JsonConvert.SerializeObject(products));
            }

        }
        public static void PrintProduct()
        {
            List<Product> products;
            using (StreamReader sr = new StreamReader("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\products.json"))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            }
            foreach (Product item in products)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Inqredint + " " + item.Price);

            }
        }
        public static List<Product> WriterProduct(List<Product> products)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\products.json"))
            {
                sw.Write(JsonConvert.SerializeObject(products));
            }
            return products;
        }
        public static List<Product> GetInfoProduct()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\products.json"))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            }
            return products;
        }
        public static List<Product> ProductDelete(int id)
        {
            List<Product> products = GetInfoProduct();
            products.Remove(products.SingleOrDefault(x => x.Id == id));
            ProductCrud.WriterProduct(products);
            return products;
        }
        public static void ChangePizzaId(int Id)
        {
            PizzasName:
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader("C:\\Users\\user\\Documents\\Code Academy\\C# ProjectForPizza\\PizzaProject\\Files\\Products.json"))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            }
            Product product = products.Find(x => x.Id == Id);
            Console.WriteLine("Change your Pizza name:");
            string pizzaname = Console.ReadLine();
            Console.WriteLine("Please write your indegreient's name:");
            string ingredient = Console.ReadLine();
            if (product == null)
            {
                Console.WriteLine("Pizza with this id doesn't found");
            }
            else
            {
                if (!Validation.NameProduct(pizzaname))
                {
                    Console.Clear();
                    Console.WriteLine("Pizza's Name creating is empty pls create a new one: ");
                    goto PizzasName;
                }
                Ingredient:
                if (!Validation.NameIngredient(ingredient))
                {
                    Console.Clear();
                    Console.WriteLine("Ingredient name  is empty pls create a new one: ");
                    goto Ingredient;
                }
            }
            Price:
            try
            {
                Console.WriteLine("Please write your Pizza's price: ");
               
                int price = Convert.ToInt32(Console.ReadLine());
                if (!Validation.PricePizza(price))
                {
                    Console.Clear();
                    Console.WriteLine("Price is wrong pls create a new one: ");
                    goto Price;
                }
                ProductCrud.Add();
            }
            catch (Exception)
            {

                goto Price;
            }
            Console.WriteLine("Pizza deyisildi...");
           
        }





    }
}
