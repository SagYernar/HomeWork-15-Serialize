using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    [Serializable]
    public class Book
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }

        public void AddNewBook(string author, string name, int price, int year)
        {
            Author = author;
            Name = name;
            Price = price;
            Year = year;
        }
    }
}
