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
		break;
	}

	nowN = n % 10;
	n = n / 10;
	if (nowN % 2 != 0)
	{
		reversedN = reversedN * 10 + nowN;
	}
}
Console.WriteLine(reversedN);