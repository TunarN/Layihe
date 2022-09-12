using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Project.Models
{
    class UserCrud
    {
        public static void Add()
        {
            string usarname = Console.ReadLine();
            string password = Console.ReadLine();
            int price = Convert.ToInt32(Console.ReadLine());
            List<User> users = new List<User>();
            users.Add(new User { Username = usarname, Password = password });
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\products.json"))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }
        }
        public static List<User> GetInfoUser()
        {
            List<User> users = new List<User>();
            using (StreamReader sr= new StreamReader ("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\users.json"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            return users;
        }
        public static List<User> WriterUser(List<User>users)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\users.json"))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }
            return users;
        }
       
        public static List<User> UserDelete( int id)
        {
            List<User> users = GetInfoUser();
            users.Remove(users.SingleOrDefault(x => x.Id == id));
            UserCrud.WriterUser(users);
            return users;
        }
        public static List<User> UpdateUser( bool value,int id)
        {
            List<User> users = GetInfoUser();
            User olduser = users.Find(x => x.Id == id);
            if (olduser==null)
            {
                Console.WriteLine("Bele bir Id tapilmadi");
                return users;
            }
            int id1 = olduser.Id;
            UserCrud.UserDelete(olduser.Id);
            if (olduser.isAdmin == true)
            {
                olduser.isAdmin = false;
            }
            else if (olduser.isAdmin==false)
            {
                olduser.isAdmin = true;
            }
            users.Add(olduser);
            UserCrud.WriterUser(users);
            return users;
           
        }
    }
}
