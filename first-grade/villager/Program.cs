int CountCombinations(int maxN)
{
    int count = 0;

    for (int z = 1; ; z++)
    {
        long pow = (long)Math.Pow(2, z);
        long div = pow - 1;

        if (div > maxN) break; 

        long maxNForK = maxN / div;

        count += (int)Math.Max(0, maxNForK);
    }

    return count;
}

int maxN = int.Parse(Console.ReadLine());
int result = CountCombinations(maxN);
Console.WriteLine(result);