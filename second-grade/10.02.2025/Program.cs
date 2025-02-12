using System;
namespace MenuApp
{
    public class User
    {
        public Int32 id;
        public string fullName;
        public List<PhoneNumber> phoneNumber;

        public User(Int32 id, string fullName)
        {
            this.id = id;
            this.fullName = fullName;
            this.phoneNumber = new List<PhoneNumber>();
        }

        public void AddNumber(PhoneNumber number)
        {
            phoneNumber.Add(number);
        }

        public string GetAllInfo()
        {
            return $"- Имя: {fullName}, ID: {id}, Информация о номерах:\n{this.GetInfoAboutNumbers()}";
        }

        public string GetInfoAboutNumbers()
        {
            string infoLine = "";
            for (Int32 i = 0; i < phoneNumber.Count(); i++)
            {
                PhoneNumber numberNow = phoneNumber[i];
                infoLine += $"-- Номер {i + 1}: {numberNow.number}, название оператора: {numberNow.operatorName}, город регистрации номера: {numberNow.city}, год регистрации номера: {numberNow.year}\n";
            }
            return infoLine;
        }
    }

    public class PhoneNumber
    {
        public Int32 userId;
        public string number;
        public string operatorName;
        public string city;
        public string year;

        public PhoneNumber(Int32 userId, string number, string operatorName, string city, string year)
        {
            this.userId = userId;
            this.number = number;
            this.operatorName = operatorName;
            this.city = city;
            this.year = year;
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
                Console.Write("Выберите действие: ");
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

                DisplaySelectorsMenu();
                Console.Write("Выберите действие: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        logic.GetAllUsers();
                        break;
                    case "2":
                        Console.Write("\nВведите номер телефона: ");
                        string phoneNumber = Console.ReadLine();
                        logic.GetUserByPhone(phoneNumber);
                        break;
                    case "3":
                        Console.Write("\nВведите название оператора: ");
                        string operatorName = Console.ReadLine();
                        logic.GetUsersByOperator(operatorName);
                        break;
                    case "4":
                        Console.Write("\nВведите год регистрации номера: ");
                        string year = Console.ReadLine();
                        logic.GetUsersByYear(year);
                        break;
                    case "5":
                        Console.Write("\nВведите город регистрации номера: ");
                        string city = Console.ReadLine();
                        logic.GetUsersByCity(city);
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
            Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Создание абонента\n(2) - Выбор по параметру\n(q) - Выход\n");
        }

        public void DisplaySelectorsMenu()
        {
            Console.WriteLine("-- Выбор по параметру --\n\nВыберите действие:\n(1) - Вывод всех пользователей\n(2) - Вывод по телефону\n(3) - Вывод по оператору связи\n(4) - Вывод по году подключения\n(5) - Вывод по городу покдлючения\n(q) - Выход\n");
        }
    }

    public class Logic
    {
        List<User> users = new List<User>();
        List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();

        public void Option1()
        {
            Console.Clear();

            Console.WriteLine("-- Создание абонента --\n\n");

            Console.Write("Введите полное имя абонента: ");
            string fullName = Console.ReadLine();
            Int32 id = users.Count();
            User user = new User(id, fullName);
            users.Add(user);

            bool isDone = false;
            while (!isDone)
            {
                Console.Write("Введите номер телефона: ");
                string number = Console.ReadLine();
                Console.Write("Введите название оператора: ");
                string operatorName = Console.ReadLine();
                Console.Write("Введите город регистрации номера: ");
                string city = Console.ReadLine();
                Console.Write("Введите год регистрации номера: ");
                string year = Console.ReadLine();

                PhoneNumber phoneNumber = new PhoneNumber(id, number, operatorName, city, year);
                phoneNumbers.Add(phoneNumber);
                user.AddNumber(phoneNumber);

                Console.Write("\n- Продолжить создание номера? (y/n) ");
                string operation = Console.ReadLine();
                if (operation != "y")
                {
                    isDone = true;
                }
            }

            Console.Write("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        public void GetAllUsers()
        {
            foreach (User user in users)
            {
                string infoLine = user.GetAllInfo();
                Console.WriteLine($"{infoLine}");
            }

            Console.Write("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        public void GetUserByPhone(string phone)
        {
            foreach (PhoneNumber number in phoneNumbers)
            {
                if (number.number != phone) continue;
                foreach (User user in users)
                {
                    if (user.id == number.userId)
                    {
                        string infoLine = user.GetAllInfo();
                        Console.WriteLine($"{infoLine}");
                    }
                }
            }

            Console.Write("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        public void GetUsersByOperator(string operatorName)
        {
            foreach (PhoneNumber number in phoneNumbers)
            {
                if (number.operatorName != operatorName) continue;
                foreach (User user in users)
                {
                    if (user.id == number.userId)
                    {
                        string infoLine = user.GetAllInfo();
                        Console.WriteLine($"{infoLine}");
                    }
                }
            }

            Console.Write("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        public void GetUsersByYear(string year)
        {
            foreach (PhoneNumber number in phoneNumbers)
            {
                if (number.year != year) continue;
                foreach (User user in users)
                {
                    if (user.id == number.userId)
                    {
                        string infoLine = user.GetAllInfo();
                        Console.WriteLine($"{infoLine}");
                    }
                }
            }

            Console.Write("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        public void GetUsersByCity(string city)
        {
            foreach (PhoneNumber number in phoneNumbers)
            {
                if (number.city != city) continue;
                foreach (User user in users)
                {
                    if (user.id == number.userId)
                    {
                        string infoLine = user.GetAllInfo();
                        Console.WriteLine($"{infoLine}");
                    }
                }
            }

            Console.Write("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        public void FastAddUser(string[] infoArray)
        {
            // Сигнатура массива: [fullName, number, operatorName, city, year]

            Int32 id = users.Count();
            User user = new User(id, infoArray[0]);
            users.Add(user);

            PhoneNumber phoneNumber = new PhoneNumber(id, infoArray[1], infoArray[2], infoArray[3], infoArray[4]);
            user.AddNumber(phoneNumber);
            phoneNumbers.Add(phoneNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logic logicUnit = new Logic();

            logicUnit.FastAddUser(["user1", "1000", "userOperator", "userCity", "1900"]);
            logicUnit.FastAddUser(["user2", "1025", "userOperator", "userCity1", "1901"]);

            Menu menu = new Menu(logicUnit);
            menu.Run();
        }
    }
}
