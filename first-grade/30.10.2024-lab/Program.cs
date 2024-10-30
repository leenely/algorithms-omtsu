int[] GenerateArray(int count)
{
	int[] result = new int[count];
	for (int i = 0; i < count; i++)
	{
		result[i] = int.Parse(Console.ReadLine());
	}
	return result;
}

// Задача 1
Console.WriteLine($"--- Первая задача ---");
int i = int.Parse(Console.ReadLine());



int[] ConcatArrays(int[] positive, int[] negative, int[] original, bool includesZero, int positiveCount, int negativeCount) // Мы же не знаем Array.Concat, верно?
{
	int[] result = new int[positive.Length + negative.Length + (includesZero ? 1 : 0)];
	
	for (int i = 0; i < positive.Length; i++)
	{
		result[i] = positive[i];
	}

	if (includesZero)
	{
		result[positive.Length] = 0;
	}

	for (int i = 0; i < negative.Length; i++)
	{
		result[positive.Length + (includesZero ? 1 : 0) + i] = negative[i];
	}
	return result;
}

int[] originalArray = GenerateArray(i);

int[] SortArray(int[] array)
{
	int positiveCount = 0;
	int negativeCount = 0;
	bool includesZero = false;

	foreach (int value in array)
	{
		if (value < 0)
		{
			negativeCount++;
		}
		else if (value > 0)
		{
			positiveCount++;
		}
		else
		{
			includesZero = true;
		}
	}

	int[] positiveArray = new int[positiveCount];
	int[] negativeArray = new int[negativeCount];

	int tempPositive = positiveCount;
	int tempNegative = negativeCount;

	foreach (int value in array)
	{
		if (value < 0)
		{
			negativeArray[negativeArray.Length - tempNegative] = value;
			tempNegative--;
		}

		if (value > 0)
		{
			positiveArray[positiveArray.Length - tempPositive] = value;
			tempPositive--;
		}
	}
	int[] resultArray = ConcatArrays(positiveArray, negativeArray, array, includesZero, positiveCount, negativeCount);
	return resultArray;
}

int[] resultArray = SortArray(originalArray);
Console.WriteLine($"----");
Array.ForEach(resultArray, Console.WriteLine);


// Задача 2
Console.WriteLine($"--- Вторая задача ---");
int m = int.Parse(Console.ReadLine());

int[] arrForUD = GenerateArray(m);

bool isArrayUniformlyDecreasing(int[] arrForUD)
{
	if (arrForUD.Length < 2)
	{
		return false;
	}

	int difference = arrForUD[1] - arrForUD[0];
	for (int i = 2; i < arrForUD.Length; i++)
	{
		if (arrForUD[i] - arrForUD[i - 1] != difference)
		{
			return false;
		}
	}

	return true;
}

Console.WriteLine(isArrayUniformlyDecreasing(arrForUD));



// // Задача 3
Console.WriteLine($"--- Третья задача ---");
int k = int.Parse(Console.ReadLine());

int[] arrForEven = GenerateArray(k);

bool isArrayEven(int[] arrForEven)
{
	if (arrForEven.Length < 2)
	{
		return false;
	}

	for (int i = 0; i < arrForEven.Length; i++)
	{
		if (arrForEven[i] % 2 != 0)
		{
			return false;
		}
	}
	return true;
}

Console.WriteLine(isArrayEven(arrForEven));