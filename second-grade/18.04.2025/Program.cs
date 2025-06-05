using System;
namespace MenuApp
{
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
      Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Опция 1\n(q) - Выход\n");
    }
  }

  public class Logic
  {
    public void Option1()
    {
      Console.Clear();

      Console.WriteLine("-- Опция 1 --\n\n");
      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
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