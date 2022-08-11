
static long IpsBetween(string start, string end)
{
    uint ToUint(string ipAddress)
    {
        var bytes = ipAddress.Split('.').Select(byte.Parse).ToArray();

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);

        return BitConverter.ToUInt32(bytes);
    }
    var startIpAddressAsUnit = ToUint(start);
    var endIpAddressAsUnit = ToUint(end);

    return endIpAddressAsUnit - startIpAddressAsUnit;
}

Console.WriteLine(IpsBetween("10.0.0.0", "10.0.0.50"));
Console.WriteLine(IpsBetween("20.0.0.10", "20.0.1.0"));
Console.WriteLine(IpsBetween("0.0.0.0", "255.255.255.255"));