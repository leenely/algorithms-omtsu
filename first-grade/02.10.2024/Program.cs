// Задача 1
// int n = int.Parse(Console.ReadLine());

// int counter = 0,
// 		maxCounter = 0,
// 		prev = 0;

// for (int i = 0; i < n; i++) 
// {
// 	int m = int.Parse(Console.ReadLine());

// 	switch(i)
// 	{
// 		case(0):
// 			counter++;
// 			prev = m;
// 			break;
// 		default:
// 			if (m == prev)
// 			{
// 				counter++;
// 			}
// 			else
// 			{
// 				maxCounter = Math.Max(counter, maxCounter);
// 				counter = 0;
// 			}
// 			break;
// 	}
// }

// Console.WriteLine(maxCounter);



// Задача 2
// int n = int.Parse(Console.ReadLine());
// int minLength = 100000000,
//     currLength = 0;

// for (int i = 0; i < n; i++)
// {
//     int m = int.Parse(Console.ReadLine());

//     if (m % 2 == 0)
//     {
//         currLength += 1;
//     }
//     else
//     {
//         if (currLength > 0)
//         {
//             minLength = Math.Min(minLength, currLength);
//         }
//         currLength = 0;
//     }
// }

// if (currLength > 0)
// {
//     minLength = Math.Min(minLength, currLength);
// }

// int result = minLength == 100000000 ? 0 : minLength;

// Console.WriteLine(result);



// Задача 3
// int n = int.Parse(Console.ReadLine());
// int maxSum = 0,
// 		currSum = 0;

// for (int i = 0; i < n; i++) 
// {
// 	int m = int.Parse(Console.ReadLine());

// 	if (m % 2 == 0)
// 	{
// 		currSum += m;
// 	}
// 	else
// 	{
// 		if (currSum > 0)
// 		{
// 			maxSum = Math.Max(maxSum, currSum);
// 		}
// 		currSum = 0;
// 	}
// }

// if (currSum > 0)
// {
// 	maxSum = Math.Max(maxSum, currSum);
// }

// Console.WriteLine(maxSum);