static int DuplicateCount(string str)
{
    return str.ToLowerInvariant().GroupBy(g => g).Count(g => g.Count() > 1);
}

var temp = DuplicateCount("AAAb");
Console.WriteLine(temp);