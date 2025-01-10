using System;

namespace AirplanesTask
{
	class Flight
	{
		public string departureCity;
		public string arrivalCity;
		public int timeInFlight;
		public string name;

		public Flight(string departureCity, string arrivalCity, int timeInFlight, string name)
		{
			this.departureCity = departureCity;
			this.arrivalCity = arrivalCity;
			this.timeInFlight = timeInFlight;
			this.name = name;
		}

		public string[] getBothCities()
		{
			return [departureCity, arrivalCity];
		}

		public void printFlight()
		{
			Console.WriteLine($"Город отправления: {departureCity}, город прибытия: {arrivalCity}, время в пути: {timeInFlight}, название: {name}");
		}
	}

	class CityAirport
	{
		public string city;
		public List<Flight> flights;

		public CityAirport(string city)
		{
			this.city = city;
			this.flights = new List<Flight>();
		}

		public void addFlight(Flight airplane)
		{
			flights.Add(airplane);
		}

		public void printAirplanes()
		{
			Console.WriteLine($"- {city} -");
			foreach (Flight flight in flights)
			{
				Console.WriteLine($"Город отправления: {flight.arrivalCity}, город прибытия: {flight.departureCity}, время в пути: {flight.timeInFlight}, название: {flight.name}");
			}
		}

		public List<Flight> getFlightsByRequestedParam(string value, string param)
		{
			List<Flight> neededFlights = new List<Flight>();
			foreach (Flight flight in flights)
			{
				switch (param)
				{
					case "departureCity":
						if (flight.departureCity == value)
						{
							neededFlights.Add(flight);
						}
						break;
					case "name":
						if (flight.name == value)
						{
							neededFlights.Add(flight);
						}
						break;
				}
			}
			return neededFlights;
		}
	}


	class RenderMenu
	{
		List<CityAirport> airportsList = new List<CityAirport>();

		void GetAllFlights()
		{
			foreach (CityAirport airport in airportsList)
			{
				airport.printAirplanes();
			}
			Console.WriteLine("------------------------");
			Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadLine();
		}

		void GetFlightsByRequest(string request)
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
			List<Flight> FlightsByRequestedParam = new List<Flight>();

			foreach (CityAirport airport in airportsList)
			{
				FlightsByRequestedParam.AddRange(airport.getFlightsByRequestedParam(operation, request));
			}
			foreach (Flight flight in FlightsByRequestedParam)
			{
				flight.printFlight();
			}
			Console.WriteLine("------------------------");
			Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadLine();
		}

		void FlightManager(Flight flight)
		{
			if (flight.departureCity == flight.arrivalCity)
			{
				// Добавляем рейс только один раз в список аэропорта
				string city = flight.departureCity;
				CityAirport tempAirport = null;

				foreach (CityAirport airport in airportsList)
				{
					if (airport.city == city)
					{
						tempAirport = airport;
						break;
					}
				}

				if (tempAirport == null)
				{
					tempAirport = new CityAirport(city);
					airportsList.Add(tempAirport);
				}

				tempAirport.addFlight(flight);
			}
			else
			{
				foreach (string city in flight.getBothCities())
				{
					CityAirport tempAirport = null;

					foreach (CityAirport airport in airportsList)
					{
						if (airport.city == city)
						{
							tempAirport = airport;
							break;
						}
					}

					if (tempAirport == null)
					{
						tempAirport = new CityAirport(city);
						airportsList.Add(tempAirport);
					}

					tempAirport.addFlight(flight);
				}
			}
		}

		public void FlightCreationProcess()
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Создание рейса --\n");
				Console.Write("Введите город отправления: ");
				string departureCity = Console.ReadLine();
				Console.Write("Введите город прибытия: ");
				string arrivalCity = Console.ReadLine();
				Console.Write("Введите время в пути: ");
				int distance = int.Parse(Console.ReadLine());
				Console.Write("Введите тип самолёта: ");
				string name = Console.ReadLine();

				FlightManager(new Flight(departureCity, arrivalCity, distance, name));
				Console.WriteLine("Продолжить создание рейсов? (y/n)");
				string answer = Console.ReadLine();
				if (answer != "y")
				{
					isContinue = false;
				}
			}
		}

		public string UseMenuWriter(string menuText)
		{
			Console.Clear();
			Console.WriteLine($"{menuText}");
			string operation = Console.ReadLine();
			return operation;
		}

		public void UseErrorKeyMessage()
		{
			Console.Write("Неверная операция! Для того, чтобы продолжить нажмите любую клавишу...");
			Console.ReadLine();
		}

		public void MainMenu()
		{
			while (true)
			{

				string operation = UseMenuWriter("-- Главное меню --\n\nВыбор операции:\n- Создание рейса (1)\n- Выбор рейса (2)\n- Выход из программы (q)");

				switch (operation)
				{
					case "1":
						FlightCreationProcess();
						break;
					case "2":
						SecondaryMenu();
						break;
					case "q":
						return;
					default:
						UseErrorKeyMessage();
						break;
				}
			}
		}

		public void SecondaryMenu()
		{
			bool isContinue = true;

			while (isContinue)
			{
				string operation = UseMenuWriter("-- Второе меню --\n\nВыбор операции:\n- Вывести все рейсы (1)\n- Вывести рейсы с одним городом назначения (2)\n- Вывести рейсы с одним типом (3)\n- Выход в главное меню (q) ");

				switch (operation)
				{
					case "1":
						GetAllFlights();
						break;
					case "2":
						GetFlightsByRequest("departureCity");
						break;
					case "3":
						GetFlightsByRequest("name");
						break;
					case "q":
						isContinue = false;
						break;
					default:
						UseErrorKeyMessage();
						break;
				}
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			RenderMenu menu = new RenderMenu();
			menu.MainMenu();
		}
	}
}