int n = int.Parse(Console.ReadLine());
bool isOver = false;

int reversedN = 0,
	nowN = 0;

if (n <= 0)
{
	Console.WriteLine("Вы ввели отрицательное / нулевое число");
	isOver = true;
}

while(!isOver)
{
	if (n == 0)
	{
		isOver = true;
		if (reversedN == 0)
		{
			Console.WriteLine("Вы ввели недопустимое число");
			break;
		}
		if (reversedN == n)
		{
			Console.WriteLine("Вы ввели такое же число");
			reversedN = 0;
			break;
		}
		break;
	}

	nowN = n % 10;
	n = n / 10;

	if (nowN % 2 != 0)
	{
		reversedN = reversedN * 10 + nowN;
	}
}

if (reversedN != 0) {
	Console.WriteLine(reversedN);
}
