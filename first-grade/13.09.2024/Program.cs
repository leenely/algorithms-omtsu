// Задание 1

int a = Convert.ToInt32(Console.ReadLine());
int b = Convert.ToInt32(Console.ReadLine());

//(a, b) = (b, a); - Всё же работает, но нелегально

// Пусть a = 4, b = 5, тогда:
a = a + b; // a = 9
b = a - b; // b = 4
a = a - b; // a = 5

Console.WriteLine(a); // a = 4 -> a = 5
Console.WriteLine(b); // b = 5 -> b = 4


// Задание 2

int c = Convert.ToInt32(Console.ReadLine());
int d = Convert.ToInt32(Console.ReadLine());

// Пусть c = 6, d = 3, тогда:
int e = ((c + d) + Math.Abs(d - c)) / 2; // ((6+3) + |(3-6)|) / 2 = (9+3) / 2 = 6
Console.WriteLine(e);


// Задание 3

int p = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());
int l = Convert.ToInt32(Console.ReadLine());
int n = Convert.ToInt32(Console.ReadLine());

int result = 2 * n * p + (n * n + n) * l + 2 * n * m; // Общая формула для получения
Console.WriteLine(result);
