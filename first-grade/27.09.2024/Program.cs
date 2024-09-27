// Задача 1
// int n = int.Parse(Console.ReadLine());

// int tempLeft = 0,
// 		tempCenter = 0,
// 	 	localMinsCounter = 0;

// for (int i = 0; i < n; i++) 
// {
// 	int m = int.Parse(Console.ReadLine());

// 	switch(i)
// 	{
// 		case(0):
// 			tempLeft = m;
// 			break;
// 		case(1):
// 			tempCenter = m;
// 			break;
// 		default:
// 			if (tempLeft < tempCenter && tempCenter > m)
// 			{
// 				localMinsCounter++;
// 			}
// 			tempLeft = tempCenter;
// 			tempCenter = m;
// 			break;
// 	}
// }

// Console.WriteLine(localMinsCounter);



// Задача 2
// int n = int.Parse(Console.ReadLine());
// int counter = 0;

// for (int i = 0; i < n; i++) 
// {
// 	int m = int.Parse(Console.ReadLine());

// 	if (Math.Abs(m) % 10 == 2)
// 	{
// 		counter++;
// 	}
// }

// Console.WriteLine(counter);



// Задача 3
// int n = int.Parse(Console.ReadLine());

// int max = 0,
// 		secondFromMax = 0;

// for (int i = 0; i < n; i++)
// {
// 	int m = int.Parse(Console.ReadLine());

// 	switch(i)
// 	{
// 		case(0):
// 			max = m;
// 			break;
// 		case(1):
// 			secondFromMax = m;
// 			goto default;
// 		default:
// 			if (max < m)
// 			{
// 					secondFromMax = max;
// 					max = m;
// 				}	
// 			else if (secondFromMax <= m && m <= max)
// 			{
// 					secondFromMax = m;
// 				};
// 			break;
// 	}
// }

// Console.WriteLine($"{secondFromMax}, {max}");



// Задача 4
// int n = int.Parse(Console.ReadLine());

// int counter = 0,
// 		maxCounter = 0;

// for (int i = 0; i < n; i++)
// {
// 	int m = int.Parse(Console.ReadLine());

// 	if (m % 2 == 0)
// 	{
// 		counter++;
// 		if (counter > maxCounter)
// 		{
// 			maxCounter = counter;
// 		}
// 		continue;
// 	}

// 	counter = 0;	
// }

// Console.WriteLine(maxCounter);