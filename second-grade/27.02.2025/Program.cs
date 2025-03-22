Stack<Int32> stack = new Stack<Int32>();

int MakeOperation(string operation, int op_1, int op_2)
{
  switch (operation)
  {
    case "+":
      return op_1 + op_2;
    case "-":
      return op_1 - op_2;
    case "*":
      return op_1 * op_2;
    case "/":
      if (op_2 == 0)
      {
        throw new DivideByZeroException();
      }
      return op_1 / op_2;
    default:
      throw new ArgumentException();
  }
}


Console.WriteLine("Введите выражение: ");
string input = Console.ReadLine();
string[] chars = input.Split(' ');

foreach (string symbol in chars)
{
  if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/")
  {
    if (stack.Count >= 2)
    {
      int op_2 = stack.Pop();
      int op_1 = stack.Pop();

      int result = MakeOperation(symbol, op_1, op_2);
      stack.Push(result);
    }
  }
  else
  {
    if (int.TryParse(symbol, out int isymbol))
    {
      stack.Push(isymbol);
    }
  }
}

if (stack.Count != 1)
{
  throw new ArgumentException();
}

Console.WriteLine($"Итого: {stack.Pop()}");