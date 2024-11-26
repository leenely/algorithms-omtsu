// Общий код

void ArrayOutput(int[][] arr)
{
 Console.WriteLine("--- Получившийся массив ---");
 for (int i = 0; i < arr.Length; i++) {
     for (int j = 0; j < arr[i].Length; j++) {
         Console.Write($"{arr[i][j]} ");
     }
     Console.WriteLine();
 }
}

int[][] ArrayGenerator(int n, int m, int[][] array)
{
    int[][] resultArray = new int[n][];

		for (int i = 0; i < n; i++)
		{
				Console.WriteLine($"- Вводите элементы {i + 1} строки -");
				resultArray[i] = new int[m];
				for (int j = 0; j < m; j++)
				{
						resultArray[i][j] = int.Parse(Console.ReadLine());
				}
		}

    ArrayOutput(resultArray);
    return resultArray;
}

Console.WriteLine("--- Введите количество строк массива ---");
int n = int.Parse(Console.ReadLine());
Console.WriteLine("--- Введите количество столбцов массива ---");
int m = int.Parse(Console.ReadLine());
int[][] generatedArray = ArrayGenerator(n, m, new int[n][]);

// Конец общего кода


// Задание 1

int[][] GetPairs(int[][] array)
{
	int countZeros = 0,
			countSum = 0,
			countComposition = 1;

	int[][] exchangedMatrix = new int[n][];
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			exchangedMatrix[i] = new int[3];

			if(array[j][i] == 0)
			{
				countZeros++;
			}
			else
			{
				countComposition *= array[j][i];
			}
			countSum += array[j][i];
		}

		// Console.WriteLine($"Столбец {i + 1}: {countZeros}, {countSum}, {countComposition}");
		exchangedMatrix[i][0] = countZeros;
		exchangedMatrix[i][1] = countSum;
		exchangedMatrix[i][2] = countComposition;

		countZeros = 0;
		countSum = 0;
		countComposition = 1;
	}
	return exchangedMatrix;
}

int[][] exchangedMatrix = GetPairs(generatedArray);


for (int i = 0; i < m; i++)
{
    for (int j = i + 1; j < m; j++)
    {
        bool areEqual = true;
        for (int k = 0; k < 3; k++)
        {
            if (exchangedMatrix[i][k] != exchangedMatrix[j][k])
            {
                areEqual = false;
                break;
            }
        }
        if (areEqual)
        {
            Console.WriteLine($"Найдено совпадение в столбцах {i + 1} и {j + 1}");
        }
    }
}


// Задание 2

int[][] SwapColumnsWithMaxMinElement(int[][] array)
{
    int maxElement = -1000000;
    int minElement = 1000000;
    int maxColumnIndex = 0;
    int minColumnIndex = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.WriteLine(array[i][j]);

						if (array[i][j] > maxElement)
						{
							maxElement = array[i][j];
							maxColumnIndex = j;
						}

						if (array[i][j] < minElement)
						{
							minElement = array[i][j];
							minColumnIndex = j;
						}
						
        }
    }
		Console.WriteLine($"Min: {minColumnIndex}, Max: {maxElement}");

    int[][] swappedArray = new int[array.Length][];
    for (int i = 0; i < array.Length; i++)
    {
        swappedArray[i] = new int[array[i].Length];
        for (int j = 0; j < array[i].Length; j++)
        {
            if (j == maxColumnIndex)
            {
                swappedArray[i][j] = array[i][minColumnIndex];
            }
            else if (j == minColumnIndex)
            {
                swappedArray[i][j] = array[i][maxColumnIndex];
            }
            else
            {
                swappedArray[i][j] = array[i][j];
            }
        }
    }
    return swappedArray;
}

ArrayOutput(SwapColumnsWithMaxMinElement(generatedArray));


// Задание 3

bool isArrayUniformlyDecreasing(int[] arrForUD)
{
	int count = 0;
	if (arrForUD.Length < 2) return false;

	int difference = arrForUD[1] - arrForUD[0];
	for (int i = 0; i < arrForUD.Length - 1; i++)
	{
		if (arrForUD[i + 1] - arrForUD[i] == difference && difference < 0 && difference != 0)
		{
			count++;
		}
	}
	if (count == arrForUD.Length - 1)
	{
		return true;
	}
	else
	{
		return false;
	}
}

void GetUniformlyDecreasingSequenceLine(int[][] array)
{
	for (int i = 0; i < array.Length; i++)
	{
		if (isArrayUniformlyDecreasing(array[i]))
		{
			Console.WriteLine($"Строка {i + 1} является равномерно убывающей последовательностью");
		}
	}
}

GetUniformlyDecreasingSequenceLine(generatedArray);