unsafe
{
    int* rate = stackalloc int[256];

    Console.Write("Введите количество строк: ");
    int n = int.Parse(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();
        foreach (char c in input)
        {
            if (c < 256)
            {
                rate[c]++;
            }
        }
    }

    Console.WriteLine("Частоты: ");
    for (int i = 0; i < 256; i++)
    {
        if (rate[i] > 0)
        {
            char ch = (char)i;
            Console.WriteLine($"{ch}: {rate[i]}");
        }
    }
}