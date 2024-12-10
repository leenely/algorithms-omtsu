// Общий код

// void ArrayOutput(int[][] arr)
// {
// 	Console.WriteLine("--- Получившийся массив ---");
// 	for (int i = 0; i < arr.Length; i++) {
// 		for (int j = 0; j < arr[i].Length; j++) {
// 			Console.Write($"{arr[i][j]} ");
// 		}
// 		Console.WriteLine();
// 	}
// }

int[][] ArrayGenerator(int n, int[][] array)
{
	int[][] resultArray = new int[n][];

	for (int i = 0; i < n; i++) {
		Console.WriteLine($"- Введите количество элементов строки {i + 1} -");
		int m = int.Parse(Console.ReadLine());

		resultArray[i] = new int[m];

		Console.WriteLine($"- Введите элементы строки {i + 1} через пробел -");
		string[] elements = Console.ReadLine().Split(' ');
		for (int j = 0; j < m; j++) {
			resultArray[i][j] = int.Parse(elements[j]);
		}
	}

	// ArrayOutput(resultArray);
	return resultArray;
}

Console.WriteLine("--- Введите количество строк массива ---");
int n = int.Parse(Console.ReadLine());
int[][] generatedArray = ArrayGenerator(n, new int[n][]);

// Конец общего кода


// Задание 1

for (int i = 0; i < n; i++)
{
	bool flag = false;
	for (int j = 0; j < generatedArray[i].Length; j++)
	{
		
		int tempAllSum = generatedArray[i].Sum();
		for (int k = 0; k < generatedArray[i].Length; k++)
		{
			int curr = generatedArray[i][k];
			if (curr > tempAllSum - curr)
			{
				flag = true;
			}
		}
	}
	if (flag) 
	{ 
		Console.WriteLine($"- Элемент, значение которого больше суммы всех остальных элементов замечен в {i + 1} строке");
	}
}


// Задание 2

bool isMinCounterUsed = false;

int CheckMinCounter(int minCounter, int counter, bool flag)
{
	if (!flag)
	{
		minCounter = counter;
		isMinCounterUsed = true;
	}

	if (counter < minCounter && counter != 0)
	{
		minCounter = counter;
	}

	return minCounter;
}


int FindMinDecreasingSubsequence(int[] arr)
{
	if (arr.Length < 2)
	{
		return 0;
	}

	int difference = -1000000; // Берём такой флаг для первой итерации
	int counter = 2;
	int minCounter = 0;

	for (int i = 1; i < arr.Length; i++)
	{
		int tempDifference = arr[i] - arr[i - 1];

		if (difference == -1000000)
		{
			difference = tempDifference;
			continue;
		}

		if (arr[i] - arr[i - 1] > 0)
		{
			difference = tempDifference;
			minCounter = CheckMinCounter(minCounter, counter, isMinCounterUsed);
			counter = 0;
			continue;
		}

		if (tempDifference == difference)
		{
			counter++;
		}
		else
		{
			difference = tempDifference;
			minCounter = CheckMinCounter(minCounter, counter, isMinCounterUsed);
			counter = 2;
		}
	}

	minCounter = CheckMinCounter(minCounter, counter, isMinCounterUsed);
	isMinCounterUsed = false;
	return minCounter;
}

for (int i = 0; i < generatedArray.Length; i++)
{
	Console.WriteLine($"--- Наименьшие длины равномерно убывающих подпоследовательностей для каждой строки ---");
	Console.WriteLine(FindMinDecreasingSubsequence(generatedArray[i]));
}
