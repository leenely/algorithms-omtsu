using System;
namespace MenuApp
{
	public class Phone
	{
		public string phoneNumber;
		public string operatorName;

		public Phone(string phoneNumber, string operatorName)
		{
			this.phoneNumber = phoneNumber;
			this.operatorName = operatorName;
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
			Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Добавить номер\n(2) - Вывести частоту появлений\n(q) - Выход\n");
		}
	}

	public class Logic
	{
		List<Phone> phones = new List<Phone>()
		{
			new Phone("123", "мтс"),
			new Phone("456", "мтс"),
			new Phone("789", "vnc"),
		};

		public void Option1()
		{
			Console.Clear();

			Console.WriteLine("-- Опция 1 --\n\n");
			Console.Write("Введите номер телефона: ");
			string phoneNumber = Console.ReadLine();
			Console.Write("Введите оператора связи: ");
			string operatorName = Console.ReadLine();

			phones.Add(new Phone(phoneNumber, operatorName));

			Console.WriteLine("Номер зарегистрирован. Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadKey();
			return;
		}

		public void Option2()
		{
			Console.Clear();

			Dictionary<string, int> operatorNumbers = new Dictionary<string, int>();

			foreach (var number in phones)
			{
				if (operatorNumbers.ContainsKey(number.operatorName))
				{
					operatorNumbers[number.operatorName]++;
				}
				else
				{
					operatorNumbers[number.operatorName] = 1;
				}
			}

			foreach (var operatorName in operatorNumbers)
			{
				Console.WriteLine($"{operatorName.Key}  -  {operatorName.Value}");
			}

			Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
			Console.ReadKey();
		}
	}

	class Program
	{
		static void Main()
		{
			Logic logicUnit = new Logic();
			Menu menu = new Menu(logicUnit);
			menu.Run();
		}
	}
}