// - Дана база данных автомобилей. Каждый автомобиль характеризуется годом выпуска, маркой и городом регистрации. С помощью запросов необходимо: 
//	- выдать данные по каждой марке автомобиля
//	- выдать данные по заданному году выпуска
//	- выдать данные группированные по городу

using System;
namespace Task
{
  class Car
  {
    public string brand;
    public int year;
    public string city;
    public Car(string brand, int year, string city)
    {
      this.brand = brand;
      this.year = year;
      this.city = city;
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
            Selectors();
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

        DisplaySelectionMenu();
        Console.Write("Выберите действие: ");
        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            logic.Option2();
            break;
          case "2":
            logic.Option3();
            break;
          case "3":
            logic.Option4();
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
      Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Создание машины\n(2) - Выборки\n(q) - Выход\n");
    }

    public void DisplaySelectionMenu()
    {
      Console.WriteLine("-- Выборки --\n\nВыберите действие:\n(1) - Вывести данные по каждой марке автомобиля\n(2) - Вывести данные по заданному году выпуска\n(3) - Вывести данные группированные по городу\n(q) - Выход\n");
    }
  }
  public class Logic
  {
    List<Car> cars = new List<Car>{
      new Car("Toyota", 2010, "Moscow"),
      new Car("Toyota", 2012, "Saint Petersburg"),
      new Car("Haval", 2018, "China")
    };

    public void Option1()
    {
      Console.Clear();

      Console.WriteLine("-- Создание машины --\n\n");
      Console.Write("Введите марку машины: ");
      string brand = Console.ReadLine();
      Console.Write("Введите год выпуска машины: ");
      int year = int.Parse(Console.ReadLine());
      Console.Write("Введите город регистрации машины: ");
      string city = Console.ReadLine();

      cars.Add(new Car(brand, year, brand));

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }

    public void Option2()
    {
      Console.Clear();
      Console.WriteLine("- Выборка по каждой марке автомобиля -\n");

      var query = from car in cars
                  group car by car.brand into groupedCars
                  select groupedCars;

      foreach (var q in query)
      {
        Console.WriteLine($"- Марка: {q.Key}");
        foreach (var car in q)
        {
          Console.WriteLine($"Год: {car.year}, город: {car.city}");
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
    }

    public void Option3()
    {
      Console.Clear();
      Console.WriteLine("- Выборка по году выпуска автомобиля -\n");

      var query = from car in cars
                  group car by car.year into groupedCars
                  select groupedCars;

      foreach (var q in query)
      {
        Console.WriteLine($"- Год: {q.Key}");
        foreach (var car in q)
        {
          Console.WriteLine($"Марка: {car.brand}, город: {car.city}");
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
    }

    public void Option4()
    {
      Console.Clear();
      Console.WriteLine("- Выборка по городу -\n");

      var query = from car in cars
                  group car by car.city into groupedCars
                  select groupedCars;

      foreach (var q in query)
      {
        Console.WriteLine($"- Город: {q.Key}");
        foreach (var car in q)
        {
          Console.WriteLine($"Марка: {car.brand}, год: {car.year}");
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
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