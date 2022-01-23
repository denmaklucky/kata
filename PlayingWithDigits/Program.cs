static long DigPow(int n, int p)
{
    long sum = 0;

    var inputNumber = n.ToString();
    foreach (var digit in inputNumber)
    {
        sum += (long)Math.Pow(int.Parse(digit.ToString()), p);
        p++;
    }

    var k = sum / n;
    return k * n == sum ? k : -1;
}

var k = DigPow(89, 1);
Console.WriteLine(k);