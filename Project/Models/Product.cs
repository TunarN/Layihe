using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Project.Models
{
    class Product
    {
        private string _name;
        private string _inqredint;
        private int _price;
        
        public int Id { get; set; }
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                if (value!=null)
                {
                    _name = value;
                }
            }
                }
        public string Inqredint {
            get
            {
                return _inqredint;
            }
            set
            {
                if (value!=null)
                {
                    _inqredint = value;
                }
            }
                }
        public int Price {
            get
            {
                return _price;
            }

            set
            {
                if (value>0)
                {
                    _price = value;
                }
            }
        }
        public static int ProductID()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader("C:\\Users\\lenovo\\Desktop\\Proyekt\\Project\\Project\\Files\\products.json"))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            }

            int max = 0;
            foreach (Product item in products)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            return max + 1;
        }
    }
}
