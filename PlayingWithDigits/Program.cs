static long DigPow(int n, int p)
{
    var inputNumber = n;
    long sum = 0;
    while (inputNumber > 0)
    {
        var digit = inputNumber % 10;
        inputNumber /= 10;
        sum += digit ^ p;
        p++;
    }

    var k = sum / n;
    return k * n == sum ? k : -1;
}

var k = DigPow(89,1);
Console.WriteLine(k);