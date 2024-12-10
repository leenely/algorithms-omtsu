using System;
namespace CarTask
{
    class Car
    {
        public string Brand;
        public string Year;
        public string Color;
        public string Country;

        public Car(string brand, string year, string color, string country)
        {
            this.Brand = brand;
            this.Year = year;
            this.Color = color;
            this.Country = country;
        }
    }
    class RenderMenu
    {
        private Car[] carsArray;

        public RenderMenu(int carsAmount)
        {
            carsArray = new Car[carsAmount];
        }

        private Car GetCarFromInput()
        {
            Console.Write("Введите марку, год выпуска, цвет и страну изготовления автомобиля через пробел: ");
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length != 4)
            {
                Console.WriteLine("Неправильное количество параметров. Введите 4 параметра.");
                return null;
            }

            return new Car(input[0], input[1], input[2], input[3]);
        }

        public void MainMenu()
        {
            int carsAdded = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("-- Главное меню --\n");
                Console.WriteLine($"Выбор операции:\n- Добавить автомобиль (1) (Можно добавить еще {carsArray.Length - carsAdded} машин(ы))\n- Выбор автомобиля (2)\n- Выход из программы (q)");
                Console.Write("Введите номер операции: ");
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        if (carsAdded < carsArray.Length)
                        {
                            Car newCar = GetCarFromInput();
                            if (newCar != null)
                            {
                                carsArray[carsAdded] = newCar;
                                carsAdded++;
                            }
                            else
                            {
                                Console.WriteLine("Введены некорректные данные. Нажмите любую клавишу для возврата в главное меню...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Все автомобили уже добавлены. Нажмите любую клавишу для возврата в главное меню...");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        CarSelection();
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }
        }
        private void CarSelection()
        {
            Console.Clear();

            if (carsArray == null || carsArray.Length == 0 || carsArray[0] == null)
            {
                Console.WriteLine("Список машин пуст. Для того, чтобы вернуться обратно нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("-- Выбор автомобиля --\n");
            Console.WriteLine($"Выбор операции: \n- Вывести все автомобили (1)\n- Вывести автомобили, изготовленные в определенный год (2)\n- Вывести автомобили одной марки (3)\n- Вывести автомобили одной страны производства (4)\n- Выход в меню (q)");
            Console.Write("Введите номер операции: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    foreach(Car car in carsArray)
                    {
                        if (car != null)
                        {
                            Console.WriteLine($"Марка: {car.Brand}, Год изготовления: {car.Year}, Цвет: {car.Color}, Страна производства: {car.Country}");
                        }
                    }
                    Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
                    Console.Read();
                    CarSelection();
                    break;
                case "2":
                    Console.Write("Введите год: ");
                    string year = Console.ReadLine();
                    foreach(Car car in carsArray)
                    {
                        if (car != null && car.Year == year)
                        {
                            Console.WriteLine($"Марка: {car.Brand}, Год изготовления: {car.Year}, Цвет: {car.Color}, Страна производства: {car.Country}");
                        }
                    }
                    Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
                    Console.Read();
                    CarSelection();
                    break;
                case "3":
                    Console.Write("Введите марку: ");
                    string brand = Console.ReadLine();
                    foreach(Car car in carsArray)
                    {
                        if (car != null && car.Brand == brand)
                        {
                            Console.WriteLine($"Марка: {car.Brand}, Год изготовления: {car.Year}, Цвет: {car.Color}, Страна производства: {car.Country}");
                        }
                    }
                    Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
                    Console.Read();
                    CarSelection();
                    break;
                case "4":
                    Console.Write("Введите марку: ");
                    string country = Console.ReadLine();
                    foreach(Car car in carsArray)
                    {
                        if (car != null && car.Country == country)
                        {
                            Console.WriteLine($"Марка: {car.Brand}, Год изготовления: {car.Year}, Цвет: {car.Color}, Страна производства: {car.Country}");
                        }
                    }
                    Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
                    Console.Read();
                    CarSelection();
                    break;
                case "q":
                    break;
                default:
                    CarSelection();
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество автомобилей: ");
            int n = int.Parse(Console.ReadLine());
            
            RenderMenu renderMenu = new RenderMenu(n);
            renderMenu.MainMenu();
        }
    }
}