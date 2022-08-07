static long IpsBetween(string start, string end)
{
    const int ipAddressLength = 4;

    var startBytes = start.Split('.');
    var endBytes = end.Split('.');

    var totalRemainder = 0;
    var currentRamainder = 0;
    var totalDifference = 0;

    for (var i = ipAddressLength - 1; i >= 0; i--)
    {
        var difference = byte.Parse(endBytes[i]) - byte.Parse(startBytes[i]);

        if (i != 0 && difference == 0)
        {
            totalRemainder += 1;
        }

        totalDifference += difference;

        if (i == 0 && totalDifference == 0)
        {
            totalRemainder = 0;
        }
    }

    Console.WriteLine($"Total difference: {totalDifference}, remainder: {totalRemainder}");

    return totalDifference + totalRemainder * 256;
}


Console.WriteLine(IpsBetween("10.0.0.0", "10.0.0.50"));