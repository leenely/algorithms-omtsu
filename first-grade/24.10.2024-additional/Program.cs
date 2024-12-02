int n = int.Parse(Console.ReadLine());
float minMilkPpL = 1000000000;
int factoryIndex = 0;

for(int i = 0; i < n; i++)
{
	string[] inputs = Console.ReadLine().Split(' ');
  float x1 = float.Parse(inputs[0]);
  float y1 = float.Parse(inputs[1]);
  float z1 = float.Parse(inputs[2]);
  float x2 = float.Parse(inputs[3]);
  float y2 = float.Parse(inputs[4]);
  float z2 = float.Parse(inputs[5]);
  float c1 = float.Parse(inputs[6]);
  float c2 = float.Parse(inputs[7]);

	float v1 = x1 * y1 * z1;
	float v2 = x2 * y2 * z2;

	float s1 = 2 * (x1*y1 + y1*z1 + x1*z1);
	float s2 = 2 * (x2*y2 + y2*z2 + x2*z2);

	float milkPpL = (s1*c2-s2*c1)/(v2*s1-s2*v1)*1000;

	if (milkPpL < minMilkPpL)
	{
		minMilkPpL = milkPpL;
		factoryIndex = i + 1;
	}
}

Console.WriteLine($"{factoryIndex}, {Math.Round(minMilkPpL, 2)}");