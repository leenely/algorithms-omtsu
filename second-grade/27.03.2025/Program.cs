// Для двух переменных a и b написать лямбда выражение для вычисления суммы, разности, произведения и деления

var sum = (int a, int b) => a + b;

var substract = (int a, int b) => a - b;

var multiplication = (int a, int b) => a * b;

var divide = (int a, int b) =>
{
  if (b == 0)
  {
    throw new DivideByZeroException("Деление на ноль");
  }
  else
  {
    return a / b;
  }
};

Console.WriteLine(sum(1, 2));
Console.WriteLine(substract(2, 1));
Console.WriteLine(multiplication(2, 3));
Console.WriteLine(divide(1, 0)); // <- Ошибка деления на ноль
Console.WriteLine(divide(4, 2));


// Дан список из строковых переменных (типа string). С помощью лямбда выражения выдать только те элементы, которые начинаются на символ m

List<String> list = new List<String> { "a", "m", "bm", "mg", "mk" };

var isStartsWithM = (string w) => w.StartsWith('m');

foreach (string word in list)
{
  if (isStartsWithM(word))
  {
    Console.WriteLine(word);
  }
}

