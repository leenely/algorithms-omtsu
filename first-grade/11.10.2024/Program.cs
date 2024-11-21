using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите последовательность чисел через пробел: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        int i = 0;
        while (i < numbers.Length)
        {
            int number = int.Parse(numbers[i]);

            if (number <= 0)
            {
                Console.WriteLine("Программа завершена. Введено недопустимое число.");
                return;
            }

            string reversed = new string(numbers[i].ToCharArray().Reverse().ToArray());

            if (reversed == numbers[i])
            {
                Console.WriteLine("Вы ввели такое же число.");
            }
            else
            {
                int reversedNumber = int.Parse(reversed);

                if (reversedNumber % 2 == 0)
                {
                    Console.WriteLine("Не было чётных элементов.");
                }
                else
                {
                    Console.WriteLine(reversed);
                }
            }

            i++;
        }
    }
}