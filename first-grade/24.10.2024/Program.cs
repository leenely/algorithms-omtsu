int n = int.Parse(Console.ReadLine());

int[] ArrayCreation(int n) {
	int[] arr = new int[n];

	Console.WriteLine($"--- Ввод массива, состоящего из {n} чисел ---");
	for(int i = 0; i < n; i++) {
		int m = int.Parse(Console.ReadLine());
		arr[i] = m;
	}

	return arr;
}

int[] ArrayTransforming(int[] arr) {
	for (int i = 0; i < arr.Length; i++) {
		arr[i] = (int)Math.Pow(arr[i], 2);
	}
	
	return arr;
}

void ArrayPrinting(int[] arr) {
	Console.WriteLine("--- Вывод массива ---");
	for(int i = 0; i < arr.Length; i++) {
		Console.WriteLine(arr[i]);
	}
}

int[] array = ArrayTransforming(ArrayCreation(n));
ArrayPrinting(array);
