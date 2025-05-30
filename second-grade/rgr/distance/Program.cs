﻿string Distance(string[] inputLines)
{
  var parts1 = inputLines[0].Split(' ');
  var parts2 = inputLines[1].Split(' ');

  double s1 = double.Parse(parts1[0]);
  double d1 = double.Parse(parts1[1]);
  double s2 = double.Parse(parts2[0]);
  double d2 = double.Parse(parts2[1]);
  double r = double.Parse(inputLines[2]);

  // Считаем косинус угла между двумя точками шара
  double phi1 = (s1 * Math.PI) / 180;
  double phi2 = (s2 * Math.PI) / 180;
  double deltaLambda = ((d2 - d1) * Math.PI) / 180;
  double cosTheta =
      Math.Sin(phi1) * Math.Sin(phi2) +
      Math.Cos(phi1) * Math.Cos(phi2) * Math.Cos(deltaLambda);

  double checkCos = cosTheta;
  if (cosTheta > 1) cosTheta = 1;
  if (cosTheta < -1) cosTheta = -1;

  double theta = Math.Acos(cosTheta);
  double distance = r * theta;

  return distance.ToString("F3");
}

// Тесты
for (int i = 1; i <= 19; i++)
{
  string inputFilePath = Path.Combine("tests", $"input{i}.txt");
  string outputFilePath = Path.Combine("tests", $"output{i}.txt");
  string result = "";

  if (File.Exists(inputFilePath))
  {
    var inputLines = File.ReadAllLines(inputFilePath);
    result = Distance(inputLines);
  }

  if (File.Exists(outputFilePath))
  {
    var expectedResult = File.ReadAllText(outputFilePath);

    if (expectedResult != result)
    {
      Console.WriteLine($"Тест {i} не пройден: {expectedResult}, {result}");
    }
    else
    {
      Console.WriteLine($"Тест {i} пройден");
    }
  }
}