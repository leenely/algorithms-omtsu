// Общий код
void ArrayOutput(int[][] arr)
{
	Console.WriteLine("--- Получившийся массив ---");
	foreach (int[] row in arr) {
		foreach (int element in row) {
			Console.Write($"{element} ");
		}
		Console.WriteLine();
	}
}

int[][] ArrayGenerator(int n, int[][] array)
{
	int[][] resultArray = new int[n][];

	for (int i = 0; i < n; i++) {
		Console.WriteLine($"--- Введите количество элементов строки {i + 1}");
		int m = int.Parse(Console.ReadLine());

		resultArray[i] = new int[m];

		Console.WriteLine($"--- Введите элементы строки {i + 1} через пробел");
		string[] elements = Console.ReadLine().Split(' ');
		for (int j = 0; j < m; j++) {
			resultArray[i][j] = int.Parse(elements[j]);
		}
	}

	ArrayOutput(resultArray);
	return resultArray;
}

Console.WriteLine("--- Введите количество строк массива ---");
int n = int.Parse(Console.ReadLine());
int[][] generatedArray = ArrayGenerator(n, new int[n][]);

// Конец общего кода


// Задание 1

// Определить номера строк массива, в котором имеется элемент, значение которого больше суммы всех остальных элементов строки.

// for (int i = 0; i < n; i++)
// {
// 	bool flag = false;
// 	for (int j = 0; j < generatedArray[i].Length; j++)
// 	{
		
// 		int tempAllSum = generatedArray[i].Sum();
// 		for (int k = 0; k < generatedArray[i].Length; k++)
// 		{
// 			int curr = generatedArray[i][k];
// 			if (curr > tempAllSum - curr)
// 			{
// 				flag = true;
// 			}
// 		}
// 	}
// 	if (flag) 
// 	{ 
// 		Console.WriteLine($"Элемент, значение которого больше суммы всех остальных элементов замечен в {i + 1} строке");
// 	}
// }


// Задание 2

// Необходимо определить для каждой строки наименьшую длину подпоследовательности, состоящую из равномерно убывающих элементов. (подпоследовательность начинается с двойки)

for (int i = 0; i < n; i++)
{
	int count = 0;
	int difference = -1000000000;
	int maxCount = -1000000000;

	for (int j = 1; j < generatedArray[i].Length; j++)
	{
		Console.WriteLine($"--- {generatedArray[i].Length} ---");
		if (generatedArray[i].Length < 2) {
			Console.WriteLine("Я тут был");
			maxCount = 0;
			break;
		}

		if (generatedArray[i][j] - generatedArray[i][j - 1] != 0) {
			if (difference == -1000000000)
			{
			difference = generatedArray[i][j] - generatedArray[i][j - 1];
			count++;
			if (count > maxCount)
			{
				maxCount = count;
			}
			} else if (generatedArray[i][j] - generatedArray[i][j - 1] == difference)
			{
					count++;
					if (count > maxCount)
					{
						maxCount = count;
					}
			} else
			{
				count = 0;
			}
		}
	}
	Console.WriteLine(maxCount);
}