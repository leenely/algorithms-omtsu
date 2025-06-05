using System;
using System.Collections.Generic;

namespace MenuApp
{
    public struct TimeInfo
    {
        public string TakeDate;
        public string ReturnDate;

        public TimeInfo(string takeDate, string returnDate)
        {
            TakeDate = takeDate;
            ReturnDate = returnDate;
        }

        public bool IsReturned(string returnDate)
        {
            return !string.IsNullOrEmpty(returnDate);
        }
    }
    public struct Book
    {
        public string author;
        public string title;
        public int year;
        public string publisher;
        public List<TimeInfo> takes;

        public Book(string author, string title, int year, string publisher)
        {
            this.author = author;
            this.title = title;
            this.year = year;
            this.publisher = publisher;
            this.takes = new List<TimeInfo>();
        }

        public bool WasLoaned()
        {
            return takes.Count > 0;
        }

        public bool HasUnreturnedCopies()
        {
            foreach (var loan in takes)
            {
                if (string.IsNullOrEmpty(loan.ReturnDate))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Logic
    {
        private List<Book> library;

        public Logic()
        {
            InitializeLibrary();
        }

        private void InitializeLibrary()
        {
            library = new List<Book>
            {
                new Book("test", "test_name1", 1869, "publisher1"),
                new Book("test2", "test_name2", 1866, "publisher2"),
                new Book("test3", "test_name3", 1904, "publisher3"),

                new Book("test4", "test_name4", 1833, "publisher4")
                {
                    takes = new List<TimeInfo>
                    {
                        new TimeInfo("01.10.2025", "15.10.2025"),
                        new TimeInfo("01.11.2025", "")
                    }
                },
                new Book("test2", "test_name5", 1842, "publisher2")
                {
                    takes = new List<TimeInfo>
                    {
                        new TimeInfo("01.09.2025", "")
                    }
                }
            };
        }

        public void Option1()
        {
            Console.Clear();

            Console.WriteLine("-- Отчёты --\n");

            Console.WriteLine("Книги, которые ни разу не выдавались:");

            foreach (var book in library)
            {
                if (!book.WasLoaned())
                {
                    PrintBook(book);
                }
            }

            Console.WriteLine("\nКниги, которые не возвращены обратно:");

            foreach (var book in library)
            {
                if (book.HasUnreturnedCopies())
                {
                    PrintBook(book);
                }
            }

            Console.Write("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void PrintBook(Book book)
        {
            Console.WriteLine($"{book.author}. {book.title}, {book.year}, {book.publisher}");
        }
    }

    public class Menu
    {
        private Logic logic;

        public Menu(Logic logic)
        {
            this.logic = logic;
        }

        public void Run()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();

                DisplayMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        logic.Option1();
                        break;
                    case "q":
                        isExit = true;
                        break;
                    default:
                        Console.Write("Неверная операция! Для того, чтобы вернуться обратно нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Показать отчёты\n(q) - Выход\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logic logicUnit = new Logic();
            Menu menu = new Menu(logicUnit);
            menu.Run();
        }
    }
}