while (true)
{
    int i = int.Parse(Console.ReadLine());
    bool isComplete = false;
    int reversedNumber = 0;

    if (i <= 0)
    {
        Console.WriteLine("Вы ввели неверное число");
        isComplete = true;
    }

    while (!isComplete)
    {
        if (i == 0)
        {
            isComplete = true;
            if (reversedNumber == 0)
            {
                Console.WriteLine("Вы ввели неверное число");
                break;
            }
            break;
        }

        int dig = i % 10;
        i /= 10;

        if (dig % 2 != 0)
        {
            reversedNumber = reversedNumber * 10 + dig;
        }
    }

    if (reversedNumber != 0)
    {
        Console.WriteLine(reversedNumber);
    }
}
