int RomanToInt(string s)
{
    var romanNumerals = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    var arabicNumerals = s.Select(d => romanNumerals[d]).ToArray();

    var targetInt = 0;
    for (var i = arabicNumerals.Length - 1; i >= 0; i--)
    {
        if (i == arabicNumerals)
        {
        }
    }
}