int CountCombinations(int maxN)
{
    int count = 0;
    int z = 1;

    while (true)
    {
        long power = (long)Math.Pow(2, z);
        long denominator = power - 1;

        if (denominator > maxN)
        {
            break;
        }

        long maxNForK = maxN / (int)denominator;

        count += (int)Math.Max(0, maxNForK);

        z++;
    }

    return count;
}

int maxN = int.Parse(Console.ReadLine());
int result = CountCombinations(maxN);
Console.WriteLine(result);