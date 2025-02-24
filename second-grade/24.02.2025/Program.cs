string line = Console.ReadLine();
if (line == "")
{
	Console.WriteLine("Строка пуста");
	return;
}

Stack<char> stack = new Stack<char>();
foreach (char c in line)
{
	if (c == '(' || c == '[' || c == '{')
	{
		stack.Push(c);
	}
	else if (c == ')' || c == ']' || c == '}')
	{
		if (stack.Count == 0) 
		{
			Console.WriteLine("Стэк пуст");
			return;
		}

		char nowSymbol = stack.Pop();
		if ((nowSymbol == '(' && c != ')') || (nowSymbol == '[' && c != ']') || (nowSymbol == '{' && c != '}'))
		{
			Console.WriteLine("Скобки расставлены неправильно");
			return;
		}
	}
}

if (stack.Count != 0) 
{
	Console.WriteLine("Скобки расставлены неправильно");
}
else
{
	Console.WriteLine("Скобки расставлены правильно");
}