using System;
using System.Reflection.Metadata;

namespace AirplanesTask1
{

	class Airplane
	{
		public string departureCity;
		public string arrivalCity;
		public int time;
		public string name;

		public Airplane(string departureCity, string arrivalCity, int time, string name)
		{
			this.departureCity = departureCity;
			this.arrivalCity = arrivalCity;
			this.time = time;
			this.name = name;
		}

		public string[] getBothCities()
		{
			return [departureCity, arrivalCity];
		}
	}

	class AirplanesByCity
	{
		public string city;
		public List<Airplane> airplanes;

		public AirplanesByCity(string city)
		{
			this.city = city;
			this.airplanes = new List<Airplane>();
		}

		public void addAirplane(Airplane airplane)
		{
			airplanes.Add(airplane);
		}

		public void printAirplanes()
		{
			foreach (Airplane airplane in airplanes)
			{
				Console.WriteLine($"Город отправления: {airplane.arrivalCity}, город прибытия: {airplane.departureCity}, время в пути: {airplane.time}, название: {airplane.name}");
			}
		}

		public List<Airplane> getAirplanesByCityOrName(string value, string type)
		{
			List<Airplane> neededAirplanes = new List<Airplane>();
			foreach (Airplane airplane in airplanes)
			{
				switch (type)
				{
					case "departureCity":
						if (airplane.departureCity == value)
						{
							neededAirplanes.Add(airplane);
						}
						break;
					case "name":
						if (airplane.name == value)
						{
							neededAirplanes.Add(airplane);
						}
						break;
				}
			}
			return neededAirplanes;
		}
	}

	class RenderMenu
	{
		List<AirplanesByCity> airplanesList = new List<AirplanesByCity>();

		void AddAirplanesToList(Airplane airplane)
		{
			foreach (string city in airplane.getBothCities())
			{
				AirplanesByCity temp = null;
				foreach (AirplanesByCity airplanesByThisCity in airplanesList)
				{
					if (airplanesByThisCity.city == city)
					{
						temp = airplanesByThisCity;
						break;
					}
				}

				if (temp == null)
				{
					temp = new AirplanesByCity(city);
					airplanesList.Add(temp);
				}

				temp.addAirplane(airplane);
			}
		}

		private void AirplanesCreationProcess()
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Создание самолёта --\n");
				Console.Write("Введите название города отправления: ");
				string departureCity = Console.ReadLine();
				Console.Write("Введите название города прибытия: ");
				string arrivalCity = Console.ReadLine();
				Console.Write("Введите время в пути: ");
				int distance = int.Parse(Console.ReadLine());
				Console.Write("Введите название самолёта: ");
				string name = Console.ReadLine();

				AddAirplanesToList(new Airplane(departureCity, arrivalCity, distance, name));

				Console.WriteLine("Продолжить создание самолётов? (y/n)");
				string answer = Console.ReadLine();
				if (answer != "y")
				{
					isContinue = false;
				}
			}
		}

		public void PrintAllAirplanesInList()
		{
			foreach (AirplanesByCity airplanesByCity in airplanesList)
			{
				Console.WriteLine($"- {airplanesByCity.city} -");
				airplanesByCity.printAirplanes();
			}
			Console.WriteLine("------------------------");
			Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadLine();
		}

		public void PrintAirplanesByRequest(string request)
		{
			switch (request)
			{
				case "departureCity":
					Console.Write("Введите город отправления: ");
					break;
				case "name":
					Console.Write("Введите тип самолёта: ");
					break;
			}
			string operation = Console.ReadLine();
			List<Airplane> AirplanesByRequestedParam = new List<Airplane>();
			
			foreach (AirplanesByCity airplanesByThisCity in airplanesList)
			{
				switch (request)
				{
					case "departureCity":
						AirplanesByRequestedParam.AddRange(airplanesByThisCity.getAirplanesByCityOrName(operation, request));
						Console.ReadLine();
						break;
					case "name":
						AirplanesByRequestedParam.AddRange(airplanesByThisCity.getAirplanesByCityOrName(operation, request));
						Console.ReadLine();
						break;
				}
			}
		}


		public void MainMenu()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("-- Главное меню --\n");
				Console.WriteLine($"Выбор операции:\n- Создать самолёт (1)\n- Выбор самолёта (2)\n- Выход из программы (q)");
				Console.Write("Выберите действие: ");
				string operation = Console.ReadLine();

				switch (operation)
				{
					case "1":
						AirplanesCreationProcess();
						break;
					case "2":
						SecondaryMenu();
						break;
					case "q":
						return;
					default:
						Console.Write("Неверная операция! Для того, чтобы вернуться обратно нажмите любую клавишу...");
						Console.ReadLine();
						break;
				}
			}
		}

		public void SecondaryMenu()
		{
			bool isContinue = true;

			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Второе меню --\n");
				Console.WriteLine($"Выбор операции:\n- Вывести все самолёты (1)\n- Вывести самолёты с одним городом назначения (2)\n- Вывести самолёты с одним типом (3)\n- Выход из программы (q)");
				Console.Write("Выберите действие: ");
				string operation = Console.ReadLine();

				switch (operation)
				{
					case "1":
						PrintAllAirplanesInList();
						break;
					case "2":
						PrintAirplanesByRequest("departureCity");
						break;
					case "q":
						isContinue = false;
						break;
					default:
						Console.Write("Неверная операция! Для того, чтобы вернуться обратно нажмите любую клавишу...");
						Console.ReadLine();
						break;
				}
			}
		}
	}



	class Program
	{
		static void Main1(string[] args)
		{
			RenderMenu menu = new RenderMenu();
			menu.MainMenu();



		}
	}
}

