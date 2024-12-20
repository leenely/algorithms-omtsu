long maxN = long.Parse(Console.ReadLine());
long count = 0;

for (int z = 1; ; z++)
{
    long pow = (long)Math.Pow(2, z);

    if (pow <= maxN)
    {
        long maxK = (maxN * pow) / (pow - 1);
        count += maxK; 
    }
    else
    {
        break;
    }
}

Console.WriteLine(count);