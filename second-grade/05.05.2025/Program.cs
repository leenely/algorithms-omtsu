using System;
namespace Task;

class Product
{
    public int id;
    public string name;

    public Product(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

class Supplier
{
    public int id;
    public string name;
    public string phone;

    public Supplier(int id, string name, string phone)
    {
        this.id = id;
        this.name = name;
        this.phone = phone;
    }
}

class Transaction
{
    public int productId;
    public int supplierId;
    public string date;
    public int count;
    public int price;

    public Transaction(int productId, int supplierId, string date, int count, int price)
    {
        this.productId = productId;
        this.supplierId = supplierId;
        this.date = date;
        this.count = count;
        this.price = price;
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
                    Secondary();
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

    public void Secondary()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.Clear();

            DisplaySecondaryMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    logic.Option4();
                    break;
                case "2":
                    logic.Option5();
                    break;
                case "3":
                    logic.Option6();
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
        Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Создание товара\n(2) - Создание поставщика\n(3) - Создание движения товара\n(4) - Выбор\n(q) - Выход\n");
    }

    public void DisplaySecondaryMenu()
    {
        Console.WriteLine("-- Выбор --\n\nВыберите действие:\n(1) - Товары сгруппированные по поставщикам\n(2) - Суммарная стоимость товаров по дате поставки\n(3) - Поставщик, поставивший товаров на большую сумму\n(q) - Выход");
    }
}

public class Logic
{
    List<Product> products = new List<Product>(){
        new Product(0, "name"),
        new Product(1, "name1"),
        new Product(2, "name2")
    };
    List<Supplier> suppliers = new List<Supplier>(){
        new Supplier(0, "supplier", "1"),
        new Supplier(1, "supplier1", "2"),
    };
    List<Transaction> transactions = new List<Transaction>(){
        new Transaction(0, 0, "1", 1, 1),
        new Transaction(1, 0, "2", 1, 2),
        new Transaction(2, 1, "1", 4, 18)
    };

    public void Option1()
    {
        Console.Clear();
        Console.WriteLine("-- Создание товара --\n\n");

        Console.Write("Введите название товара: ");
        string name = Console.ReadLine();

        Product newProduct = new Product(products.Count(), name);
        products.Add(newProduct);
        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
        return;
    }

    public void Option2()
    {
        Console.Clear();
        Console.WriteLine("-- Создание поставщика --\n\n");

        Console.Write("Введите поставщика: ");
        string name = Console.ReadLine();
        Console.Write("Введите контактный номер: ");
        string phone = Console.ReadLine();

        Supplier newSupplier = new Supplier(suppliers.Count(), name, phone);
        suppliers.Add(newSupplier);
        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
        return;
    }

    public void Option3()
    {
        Console.Clear();
        Console.WriteLine("-- Создание движения товара --\n\n");

        Console.Write("Введите номер товара: ");
        int productId = int.Parse(Console.ReadLine());
        Console.Write("Введите номер поставщика: ");
        int supplierId = int.Parse(Console.ReadLine());
        Console.Write("Введите дату поступления: ");
        string date = Console.ReadLine();
        Console.Write("Введите количество: ");
        int count = int.Parse(Console.ReadLine());
        Console.Write("Введите цену за единицу товара: ");
        int price = int.Parse(Console.ReadLine());

        Transaction newTransaction = new Transaction(productId, supplierId, date, count, price);
        transactions.Add(newTransaction);
        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
        return;
    }


    public void Option4()
    {
        Console.Clear();
        Console.WriteLine("-- Группировка по поставщикам --\n");

        var query = from t in transactions
                    join p in products on t.productId equals p.id
                    join s in suppliers on t.supplierId equals s.id
                    group p by s.name into grouped
                    select new { supplier = grouped.Key, products = grouped.Select(i => i.name) };

        foreach (var q in query)
        {
            Console.WriteLine($"- Поставщик: {q.supplier}\nТовары: {string.Join(", ", q.products)}\n");
        }

        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }

    public void Option5()
    {
        Console.Clear();
        Console.WriteLine(" -- Суммарная стоимость по дням поставки --\n");

        var query = from t in transactions
                    group t by t.date into grouped
                    select new { date = grouped.Key, total = grouped.Sum(i => i.count * i.price) };

        foreach (var q in query)
        {
            Console.WriteLine($"- {q.date}: {q.total}\n");
        }

        Console.Write("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }

    public void Option6()
    {
        Console.Clear();
        Console.WriteLine(" -- Поставщик, поставивший товара на большую сумму --\n");

        var query = from t in transactions
                    join s in suppliers on t.supplierId equals s.id
                    group t by s into grouped
                    select new { supplier = grouped.Key, total = grouped.Sum(i => i.count * i.price) };

        foreach (var q in query.OrderByDescending(i => i.total))
        {
            Console.WriteLine($"- {q.supplier.name}: {q.total}\n");
            break;
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