namespace CountIdAddress;

public class IpAddressDifference
{
    
    private readonly byte _start;
    private readonly byte _end;
    private readonly byte _weight;

    public IpAddressDifference(byte start, byte end, byte weight)
    {
        _start = start;
        _end = end;
        _weight = weight;
    }

    public int GetDifference()
    {
        var difference = _end - _start;
        return difference == 0 ? _weight : difference;
    }
}

public enum MaskPosition
{
    One,
    Two,
    Three,
    Four
}