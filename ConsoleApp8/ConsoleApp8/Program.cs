using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
        }

        static void First()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Author = "Михаил Булгаков",
                    Name = "Мастер и Маргарита",
                    Price = 4000,
                    Year = 1966
                },
                new Book()
                {
                    Author ="Мигель де Сервантес",
                    Name = "Хитроумный идальго Дон Кихот Ламанчский",
                    Price =3000,
                    Year =1605
                },
                new Book()
                {
                    Author ="Виктор Гюго",
                    Name = "Отверженные",
                    Price =3500,
                    Year =1862
                },
                new Book()
                {
                    Author ="Грегори Дэвид Робертс",
                    Name = "Шантарам",
                    Price =3000,
                    Year =2003
                }
            };

            BinaryFormatter formater = new BinaryFormatter();
            using (FileStream stream = new FileStream("book.bin", FileMode.OpenOrCreate))
            {
                formater.Serialize(stream, books);
            }

            Console.WriteLine("Нажмите ENTER для выполнения следующей задачи...");
            Console.ReadLine();
            books = null;

            using(FileStream stream = new FileStream("book.bin", FileMode.OpenOrCreate))
            {
                books = (List<Book>)formater.Deserialize(stream);

                foreach(Book book in books)
                {
                    Console.WriteLine("Автор: " + book.Author);
                    Console.WriteLine("Название: " + book.Name);
                    Console.WriteLine("Цена: " + book.Price + "тг.");
                    Console.WriteLine("Год публикации: " + book.Year + "\n");
                }
            }

            Console.WriteLine("Нажмите ENTER для выполнения следующей задачи...");
            Console.ReadLine();

            string str;
            int menu = -1;
            string author;
            string name;
            int price;
            int year;

            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("1 - Добавить книгу");
                Console.WriteLine("0 - Выход");
                str = Console.ReadLine();
                if(Int32.TryParse(str, out menu)){
                    menu = Int32.Parse(str);
                }
                else { menu = -1; }

                if (menu == 1)
                {
                    Book newBook = new Book();

                    Console.WriteLine("Введите автора");
                    author = Console.ReadLine();

                    Console.WriteLine("Введите название книги");
                    name = Console.ReadLine();

                    Console.WriteLine("Введите стоимость книги");
                    str = Console.ReadLine();
                    if(Int32.TryParse(str, out price)){
                        price = Int32.Parse(str);
                    }
                   
                    Console.WriteLine("Введите год публикации");
                    str = Console.ReadLine();
                    if (Int32.TryParse(str, out year))
                    {
                        year = Int32.Parse(str);
                    }
                    
                    newBook.AddNewBook(author, name, price, year);
                    books.Add(newBook);
                    using (FileStream stream = new FileStream("Book.bin", FileMode.OpenOrCreate))
                    {
                        formater.Serialize(stream, books);
                    }
                }
                else if(menu == 0)
                {
                    break;
                }
            }

        }
    }
}
