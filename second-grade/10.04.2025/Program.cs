using System;

public struct TimeInfo
{
  public string? TakeData;
  public string? ReturnData;
}
namespace Books
{
  class Book
  {
    public int id;
    public string author;
    public string title;
    public int year;
    public string publisher;
    public List<TimeInfo> takeHistory;

    public Book(int id, string author, string title, int year, string publisher)
    {
      this.id = id;
      this.author = author;
      this.title = title;
      this.year = year;
      this.publisher = publisher;
      this.takeHistory = new List<TimeInfo>();
    }

    public void Info()
    {
      Console.WriteLine($"---\nid: {id}\nАвтор: {author}\nНазвание: {title}\nГод издания: {year}\nИздательство: {publisher}\nВыдачи: {takeHistory.Count}\n---");
    }

    public void AddTake(string dateTake)
    {
      takeHistory.Add(new TimeInfo() { TakeData = dateTake });
    }

    public void AddReturn(string dateReturn)
    {
      string dateTake = takeHistory[takeHistory.Count() - 1].TakeData;
      takeHistory.RemoveAt(takeHistory.Count() - 1);
      takeHistory.Add(new TimeInfo() { TakeData = dateTake, ReturnData = dateReturn });
    }

    public bool IsNotTaken()
    {
      if (takeHistory.Count() == 0 || takeHistory[takeHistory.Count() - 1].ReturnData != null)
      {
        return true;
      }
      return false;
    }

    public bool IsNotReturned()
    {
      foreach (var item in takeHistory)
      {
        if (item.ReturnData == null)
        {
          return true;
        }
      }
      return false;
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
          case "2":
            logic.Option2();
            break;
          case "3":
            logic.Option3();
            break;
          case "4":
            Selectors();
            break;
          case "5":
            logic.Option5();
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

    public void Selectors()
    {
      bool isExit = false;
      while (!isExit)
      {
        Console.Clear();
        DisplaySelectorsMenu();
        Console.Write("Выберите действие: ");
        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            logic.Option4();
            break;
          case "2":
            logic.Option5();
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
      Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Регистрация книги\n(2) - Выдать книгу\n(3) - Вернуть книгу\n(4) - Выбор\n(q) - Выход\n");
    }

    public void DisplaySelectorsMenu()
    {
      Console.WriteLine("-- Выбор --\n\nВыберите действие:\n(1) - Вывод книг, которые не выданы\n(2) - Вывод книг, которые не возвращены\n(q) - Вернуться назад\n");
    }
  }

  public class Logic
  {
    List<Book> books = new List<Book>();

    public void Option1()
    {
      Console.Clear();

      Console.WriteLine("-- Регистрация книги --\n\n");

      Console.WriteLine("Введите автора книги: ");
      string author = Console.ReadLine();
      Console.WriteLine("Введите название книги: ");
      string title = Console.ReadLine();
      Console.WriteLine("Введите год издания книги: ");
      int year = int.Parse(Console.ReadLine());
      Console.WriteLine("Введите издательство книги: ");
      string publisher = Console.ReadLine();
      books.Add(new Book(books.Count(), author, title, year, publisher));

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }

    public void Option2()
    {
      Console.Clear();
      Console.WriteLine("-- Выдача книги --\n\n");

      Console.WriteLine("Введите номер книги для выдачи: ");
      int id = int.Parse(Console.ReadLine());

      if (id >= books.Count)
      {
        Console.WriteLine("Нет такой книги!");
        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("Введите дату выдачи книги: ");
      string dateTake = Console.ReadLine();

      if (books[id].IsNotTaken())
      {
        books[id].AddTake(dateTake);
      }
      else
      {
        Console.WriteLine("Книга уже выдана!");
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }

    public void Option3()
    {
      Console.Clear();
      Console.WriteLine("-- Возврат книги --\n\n");

      Console.WriteLine("Введите номер книги для возврата: ");
      int id = int.Parse(Console.ReadLine());

      if (id >= books.Count)
      {
        Console.WriteLine("Нет такой книги!");
        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
        return;
      }

      if (books[id].IsNotTaken())
      {
        Console.WriteLine("Книга не выдана!");
        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("Введите дату возврата книги: ");
      string dateReturn = Console.ReadLine();
      books[id].AddReturn(dateReturn);

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }

    public void Option4()
    {
      Console.Clear();
      Console.WriteLine("-- Вывод книг, которые не выданы --\n\n");
      foreach (var item in books)
      {
        if (item.IsNotTaken())
        {
          item.Info();
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }

    public void Option5()
    {
      Console.Clear();
      Console.WriteLine("-- Вывод книг, которые не возвращены --\n\n");
      foreach (var item in books)
      {
        if (item.IsNotReturned())
        {
          item.Info();
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }
  }

  public class Program
  {
    public static void Main()
    {
      Logic logic = new Logic();
      Menu menu = new Menu(logic);

      menu.Run();
    }
  }
}