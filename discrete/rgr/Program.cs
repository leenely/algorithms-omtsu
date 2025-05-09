static int Dijkstra(int[][] matrix, int start, int end, int n)
{
  int[] distances = new int[n + 1];
  bool[] visitedNodes = new bool[n + 1];

  for (int i = 0; i <= n; i++)
  {
    distances[i] = int.MaxValue;
    visitedNodes[i] = false;
  }

  distances[start] = 0;

  for (int i = 1; i <= n; i++)
  {
    int nodeNow = -1;

    for (int j = 1; j <= n; j++)
    {
      if (!visitedNodes[j])
      {
        if (nodeNow == -1 || distances[j] < distances[nodeNow])
        {
          nodeNow = j;
        }
      }
    }

    if (distances[nodeNow] == int.MaxValue) break;

    visitedNodes[nodeNow] = true;

    for (int k = 1; k <= n; k++)
    {
      if (matrix[nodeNow][k] != int.MaxValue && !visitedNodes[k])
      {
        if (distances[nodeNow] + matrix[nodeNow][k] < distances[k])
        {
          distances[k] = distances[nodeNow] + matrix[nodeNow][k];
        }
      }
    }
  }

  return distances[end] == int.MaxValue ? -1 : distances[end];
}

static void FindCompany(int n, int[][] connections, int start, int end)
{
  int[][][] matrixes = new int[3][][];
  for (int i = 0; i < 3; i++)
  {
    matrixes[i] = new int[n + 1][];
    for (int j = 0; j <= n; j++)
    {
      matrixes[i][j] = new int[n + 1];
      for (int k = 0; k <= n; k++)
      {
        matrixes[i][j][k] = int.MaxValue;
      }
    }
  }

  foreach (var connection in connections)
  {
    int u = connection[0];
    int v = connection[1];
    int a1 = connection[2];
    int a2 = connection[3];
    int a3 = connection[4];

    matrixes[0][u][v] = Math.Min(matrixes[0][u][v], a1);
    matrixes[0][v][u] = Math.Min(matrixes[0][v][u], a1);

    matrixes[1][u][v] = Math.Min(matrixes[1][u][v], a2);
    matrixes[1][v][u] = Math.Min(matrixes[1][v][u], a2);

    matrixes[2][u][v] = Math.Min(matrixes[2][u][v], a3);
    matrixes[2][v][u] = Math.Min(matrixes[2][v][u], a3);
  }

  int[] costs = new int[3];
  costs[0] = Dijkstra(matrixes[0], start, end, n);
  costs[1] = Dijkstra(matrixes[1], start, end, n);
  costs[2] = Dijkstra(matrixes[2], start, end, n);

  int minCost = int.MaxValue;
  int minCompanyIndex = -1;

  for (int i = 0; i < 3; i++)
  {
    if (costs[i] != -1 && costs[i] < minCost)
    {
      minCost = costs[i];
      minCompanyIndex = i;
    }
  }

  if (minCost == int.MaxValue)
  {
    Console.WriteLine(-1);
  }
  else
  {
    Console.WriteLine($"{minCompanyIndex}: {minCost}");
  }
}

int N = 6;

int[][] connections = new int[][]
{
    new int[] {1, 2, 8, 12, 15},
    new int[] {2, 3, 10, 5, 7},
    new int[] {1, 3, 20, 8, 10},
    new int[] {3, 4, 15, 10, 12},
    new int[] {2, 4, 25, 20, 18},
    new int[] {4, 5, 5, 8, 10}
};
int startStation = 1;
int endStation = 5;

FindCompany(N, connections, startStation, endStation);


