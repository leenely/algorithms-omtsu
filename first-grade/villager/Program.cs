long maxN = long.Parse(Console.ReadLine());
long count = 0;

for (int z = 1; ; z++)
{
    long pow = (long)Math.Pow(2, z);
    long div = pow - 1;

    if (div <= maxN)
    {
        long temp = maxN / div;
        count += temp; 
    }
    else
    {
        break;
    }
}

Console.WriteLine(count);
