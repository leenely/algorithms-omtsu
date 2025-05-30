﻿using System;


string[] FindPath(string[] input)
{
  string[] firstLineParts = input[0].Split(' ');
  int N = int.Parse(firstLineParts[0]);
  int M = int.Parse(firstLineParts[1]);

  int[][] grid = new int[N][];
  for (int i = 0; i < N; i++)
  {
    string[] lineParts = input[i + 1].Split(' ');
    grid[i] = new int[M];
    for (int j = 0; j < M; j++)
    {
      grid[i][j] = int.Parse(lineParts[j]);
    }
  }

  int[][] minSums = new int[N][];
  int[][] prevLine = new int[N][];

  for (int i = 0; i < N; i++)
  {
    minSums[i] = new int[M];
    prevLine[i] = new int[M];
    for (int j = 0; j < M; j++)
    {
      prevLine[i][j] = -1;
    }
  }

  for (int j = 0; j < M; j++)
  {
    minSums[0][j] = grid[0][j];
  }

  for (int i = 1; i < N; i++)
  {
    for (int j = 0; j < M; j++)
    {
      int currentMin = int.MaxValue;
      int bestPrevCol = -1;
      int[] variants = new int[3];
      int variantCount = 0;

      if (j - 1 >= 0)
      {
        variants[variantCount++] = j - 1;
      }
      variants[variantCount++] = j;
      if (j + 1 < M)
      {
        variants[variantCount++] = j + 1;
      }

      for (int k = 0; k < variantCount; k++)
      {
        int variant = variants[k];
        if (minSums[i - 1][variant] < currentMin)
        {
          currentMin = minSums[i - 1][variant];
          bestPrevCol = variant;
        }
      }

      minSums[i][j] = grid[i][j] + currentMin;
      prevLine[i][j] = bestPrevCol;
    }
  }

  int minVal = int.MaxValue;
  int endCol = 0;
  for (int j = 0; j < M; j++)
  {
    if (minSums[N - 1][j] < minVal)
    {
      minVal = minSums[N - 1][j];
      endCol = j;
    }
  }

  string[] path = new string[N];
  int currentCol = endCol;
  path[N - 1] = (currentCol + 1).ToString();

  for (int i = N - 2; i >= 0; i--)
  {
    currentCol = prevLine[i + 1][currentCol];
    path[i] = (currentCol + 1).ToString();
  }

  return path;
}

// Тесты
for (int i = 1; i <= 6; i++)
{
  string inputFilePath = Path.Combine("tests", $"input_s1_0{i}.txt");
  string outputFilePath = Path.Combine("tests", $"output_s1_0{i}.txt");
  string[] result = [];

  if (File.Exists(inputFilePath))
  {
    var inputLines = File.ReadAllLines(inputFilePath);
    result = FindPath(inputLines);
  }

  if (File.Exists(outputFilePath))
  {
    var outputLines = File.ReadAllLines(outputFilePath);
    if (outputLines.SequenceEqual(result))
    {
      Console.WriteLine($"Тест {i} успешно пройден.");
    }
    else
    {
      Console.WriteLine($"Тест {i} не пройден.");
    }
  }
}