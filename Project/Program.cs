using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = UserCrud.GetInfoUser();
            LoginMenu:
            Console.WriteLine("1)Login");
            Console.WriteLine("2)Register");
            int choise;
            User user = new User();
            int.TryParse(Console.ReadLine(), out choise);
            Console.Clear();

            Login:
            if (choise == 1)
            {
                Console.WriteLine("Input your Username");
                string username = Console.ReadLine();
                Console.WriteLine("Input your Password");
                string password = Console.ReadLine();

                user = users.Find(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    Console.WriteLine("Did not Find Username or Password Please try again");
                    goto Login;
                }
                Console.WriteLine($"Welcome {user.Name} {user.Surname}");
                goto UserMenu;
            }
            else if (choise == 2)
            {
                RegistrationCRUD.Registration(users);
                goto LoginMenu;
            }
            else
            {
                Console.WriteLine("Please Input Correctly");
                goto LoginMenu;
            }
            if (user.isAdmin==true)
            {
                goto CRUDMENU;
            }
            else
            {
                goto UserMenu;
            }
            UserMenu:
            List<Product> products = ProductCrud.GetInfoProduct();
            Console.WriteLine("1)Look at the Pizzas");
            Console.WriteLine("2)Place an Order"); 

            int choise1;
            int.TryParse(Console.ReadLine(), out choise1);
            if (choise1 == 1)
            {
                ProductCrud.PrintProduct();
                goto UserMenu;
            }
            else if (choise1 == 2)
            {
                Console.WriteLine("Please Input ID");
                int ID = int.Parse(Console.ReadLine());
                Product product = products.Find(p => p.Id == ID);
                if (product==null)
                {
                    Console.WriteLine("Id ni duzgun daxil et");
                    goto UserMenu;
                }
                else
                {
                    Console.WriteLine("Please input Correctly");

                }
                Console.WriteLine("Sebete elave etmek Ucun S");
                Console.WriteLine("Menu-a qayitmaq ucun G");
                string choice2 = Console.ReadLine();
                if (choice2.ToUpper()=="S")
                {
                    Console.WriteLine("Pizza sayini daxil edin");
                    int counter = int.Parse(Console.ReadLine());
                    Console.WriteLine("Sebete elave Olundu");
                    double price = 1;
                    price = product.Price * counter;
                    Console.WriteLine("Sifaris Meblegi");
                    Console.WriteLine(price);
                    Console.WriteLine("Davam etmek ucun Nomre ve Adresi daxil edin");
                    Console.WriteLine("Nomreni daxil edin");
                    string phonenumber = Console.ReadLine();
                    Console.WriteLine("Adresi daxil edin");
                    string adress = Console.ReadLine();
                    Console.WriteLine("Sifaris verildi");
                    goto UserMenu;


                }
                else if (choice2.ToUpper()=="G")
                {
                    goto UserMenu;
                }
                else
                {
                    Console.WriteLine("Please Input Correctly");
                    goto UserMenu;
                }
            }
            if (user.isAdmin==true)
            {
                goto CRUDMENU;
            }
            else
            {
                Console.WriteLine("Please input correctly");
                goto UserMenu;
            }
            CRUDMENU:
            Console.WriteLine("1)Userler");
            Console.WriteLine("2)Pizzalar");
            int choice1;
            int.TryParse(Console.ReadLine(), out choice1);
            if (choice1==1)
            {
                goto UserCRUDMENU; 
                
            }
            else if (choice1==2)
            {
                goto ProductMenu;
            }
            else
            {
                Console.WriteLine("Please Input Correctly");
                goto CRUDMENU;
            }
            UserCRUDMENU:
            Console.WriteLine("1)Hamsina Bax");
            Console.WriteLine("2)Elave Etmek");
            Console.WriteLine("3)Sil");
            Console.WriteLine("4)Duzelis Et");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            if (choice==1)
            {
                UserCrud.GetInfoUser();
            }
            else if (choice==2)
            {
                UserCrud.Add();
            }
            else if (choice==3)
            {
                Console.WriteLine("Silmek istediyin userin id-ni daxil et");
                int id = int.Parse(Console.ReadLine());
                UserCrud.UserDelete(id);
            }
            else if (choice==4)
            {
                Console.WriteLine("Duzelis etmek istediyiniz userin id-ni daxil edin");
                int id1 = int.Parse(Console.ReadLine());
                UserCrud.UpdateUser(true, id1);
            }
            else
            {
                Console.WriteLine("Please Input Correctly");
                goto UserCRUDMENU;
            }
            ProductMenu:
            Console.WriteLine("1.Hamisina bax\n2.Elave et\n3.Duzelis et (Id-e gore)\n4.Sil(Id-e gore)");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    ProductCrud.PrintProduct();
                    break;
                case "2":
                    List<Product> product= new List<Product>();
                    using (StreamReader sr = new StreamReader("C:\\Users\\user\\Documents\\Code Academy\\C# ProjectForPizza\\PizzaProject\\Files\\Users.json"))
                    {
                        products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
                    }
                    PizzasName:
                    Console.ForegroundColor = ConsoleColor.Green; ;
                    Console.WriteLine("Pizzalarin adini girin:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string pizzaname = Console.ReadLine();
                    if (!Validation.NameProduct(pizzaname))
                    {
                        Console.Clear();
                        Console.WriteLine("Bele Bir Pizza var yenisini daxil edin: ");
                        goto PizzasName;
                    }
                    Ingredient:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Inqredintleri daxil edin:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string ingredint = Console.ReadLine();
                    if (!Validation.NameIngredient(ingredint))
                    {
                        Console.Clear();
                        Console.WriteLine("Bele bir inqredint var yenisi yaradin: ");
                        goto Ingredient;
                    }
                    Price:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pizzanin Qiymetini yazin: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int price = Convert.ToInt32(Console.ReadLine());
                        if (!Validation.PricePizza(price))
                        {
                            Console.Clear();
                            Console.WriteLine("Qiymet yanlisdir duzgun daxil edin: ");
                            goto Price;
                        }
                        ProductCrud.Add();
                    }
                    catch (Exception)
                    {

                        goto Price;
                    }
                    Console.WriteLine("Pizza elave olundu...");
                    goto ProductMenu;

                case "3":
                    PizzaId:
                    Console.WriteLine("Deyismek istediyiniz Pizzanin id-ni girin");
                    int pizzaid = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        ProductCrud.ChangePizzaId(pizzaid);
                    }
                    catch (Exception)
                    {
                        goto PizzaId;
                    } 

                    break;
            }










        }



    }
}
