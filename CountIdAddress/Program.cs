static long IpsBetween(string start, string end)
{
    const int ipAddressLength = 4;

    var startBytes = start.Split('.');
    var endBytes = end.Split('.');

    var totalRemainder = 0;
    var currentRemainder = 0;
    var totalDifference = 0;

    for (var i = ipAddressLength - 1; i >= 0; i--)
    {
        var difference = byte.Parse(endBytes[i]) - byte.Parse(startBytes[i]);
        totalDifference += difference >= 0 ? difference : difference + 255;

        if (difference != 0)
        {
            totalRemainder += currentRemainder;
            currentRemainder = 0;
        }
        else
            currentRemainder += 1;

        if (i == 0 && totalDifference == 0)
        {
            totalRemainder = 0;
        }
    }

    return totalDifference + totalRemainder * 256;
}


//Console.WriteLine(IpsBetween("10.0.0.0", "10.0.0.50"));
Console.WriteLine(IpsBetween("20.0.0.10", "20.0.1.0"));