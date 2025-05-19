unsafe
{
  Console.WriteLine("Задайте размер: ");
  int size = int.Parse(Console.ReadLine());
  int* array = stackalloc int[size];

  Console.WriteLine($"Введите {size} чисел: ");
  for (int i = 0; i < size; i++)
  {
    int input = int.Parse(Console.ReadLine());
    array[i] = input;
  }

  for (int i = 0; i < size; i++)
  {
    if (isPalindrome(array[i]))
    {
      Console.WriteLine($"{array[i]} - палиндром");
    }
  }

  bool isPalindrome(int num)
  {
    string str = num.ToString();
    for (int i = 0; i < str.Length / 2; i++)
    {
      if (str[i] != str[str.Length - i - 1])
      {
        return false;
      }
    }
    return true;
  }
}
