using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Project.Models
{
    class RegistrationCRUD
    {
        public static void Registration(List<User> users)
        {
            wrongname:
            Console.WriteLine("Please Input Name");
            string name = Console.ReadLine();
            Console.Clear();
            if (!Validation.NameIsAllowed(name))
            {
                goto wrongname;
            }
            surname:
            Console.WriteLine("Please Input Surname");
            string surname = Console.ReadLine();
            Console.Clear();
            if (!Validation.SurnameIsAllowed(surname))
            {
                goto surname;
            }
            wronglogin:
            Console.WriteLine("Please Input Login");
            samelogin:
            string login = Console.ReadLine();
            if (Validation.Checklogin(users,login))
            {
                Console.Clear();
                Console.WriteLine("Have a Same Login");
            if (!Validation.LoginIsAllowed(login))
            {
                goto wronglogin;
            }
                goto samelogin;
            }
            Console.Clear();
            wrongpass:
            Console.WriteLine("Please input Password");
            string password = Console.ReadLine();
            Console.Clear();
            if (!Validation.PasswordIsAllowed(password))
            {
                goto wrongpass;
            }
            users.Add(new User {Id=User.UserID(), Name = name, Surname = surname, Username = login, Password = password });
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\users.json"))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }
            Console.WriteLine("Register is Succesfully");
        }
    }
}
