int n = int.Parse(Console.ReadLine());
float minMilkPpL = 1000000000;
int factoryIndex = 0;

void GetNumbers(string[] lineArray, out x1, out y1, out z1, out x2, out y2, out z2, out c1, out c2)
{

}

for(int i = 0; i < n; i++)
{
	string line = Console.ReadLine();
	string[] lineArray = line.Split(' ');
	
	float x1, y1, z1, x2, y2, z2, c1, c2;
	GetNumbers(lineArray);

	// float x1 = float.Parse(Console.ReadLine());
	// float y1 = float.Parse(Console.ReadLine());
	// float z1 = float.Parse(Console.ReadLine());
	// float x2 = float.Parse(Console.ReadLine());
	// float y2 = float.Parse(Console.ReadLine());
	// float z2 = float.Parse(Console.ReadLine());
	// float c1 = float.Parse(Console.ReadLine());
	// float c2 = float.Parse(Console.ReadLine());

	float v2 = x2 * y2 * z2;
	float v1 = x1 * y1 * z1;

	float s1 = 2 * (x1*y1 + y1*z1 + x1*z1);
	float s2 = 2 * (x2*y2 + y2*z2 + x2*z2);

	float milkPpL = (-c1 + (s1*c2)/s2)/(-((v1-s1)/1000) + (s1*((v2-s2)/1000))/s2);

	if (milkPpL < minMilkPpL)
	{
		minMilkPpL = milkPpL;
		factoryIndex += i + 1;
	}
}

Console.WriteLine($"{Math.Round(minMilkPpL, 2)}, {factoryIndex}");