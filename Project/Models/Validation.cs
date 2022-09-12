using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project.Models
{
    class Validation
    {
        public static bool LoginIsAllowed(string username)
        {
            if (username.Length >= 3 && username.Length <= 16)
            {
                return true;
            }
            Console.WriteLine("Please Input Correctly");
            return false;
        }
        public static bool NameIsAllowed(string name)
        {
            if (name.Length >= 3 && name.Length <= 20)
            {
                return true;
            }
            Console.WriteLine("Please Input Correctly");
            return false;
        }
        public static bool SurnameIsAllowed(string surname)
        {
            if (surname.Length >= 5 && surname.Length <= 20)
            {
                return true;
            }
            Console.WriteLine("Please input correctly");
            return false; 

        }
        public static bool Checklogin(List<User> users, string username)
        {
            using (StreamReader sr = new StreamReader("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\users.json"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            User user = users.Find(u => u.Username == username);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static bool PasswordIsAllowed(string password)
        {
            if (password.Length >= 6 && password.Length <= 16 && HasDigit(password) && HasUpper(password) && HasLower(password))
            {
                return true;
            }
            Console.WriteLine("Please Input Correctly");
            return false;

        }
        private static bool HasDigit(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] > 47 && word[i] < 58)
                {
                    return true;
                }

            }
            return false;
        }
        private static bool HasUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] > 64 && word[i] < 91)
                {
                    return true;
                }

            }
            return false;

        }
        private static bool HasLower(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] > 96 && word[i] < 123)
                {
                    return true;
                }

            }
            return false;
        }
        public static bool NameProduct(string name)
        {
            if (name.Length > 0)
            {

                return true;
            }
            return false;

        }

        public static bool NameIngredient(string ingredient)
        {
            if (ingredient.Length > 0)
            {

                return true;
            }
            return false;

        }
        public static bool PricePizza(int price)
        {
            if (price > 0)
            {

                return true;
            }
            return false;

        }
    }
}
