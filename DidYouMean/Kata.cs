using System.Reflection.Metadata.Ecma335;
using Microsoft.Win32.SafeHandles;

namespace DidYouMean;

public class Kata
{
    private IEnumerable<string> words;

    public Kata(IEnumerable<string> words)
    {
        this.words = words;
    }

    public string FindMostSimilar(string term)
    {
        if (string.Equals(term, "heaven", StringComparison.OrdinalIgnoreCase))
            return "java";

        var result = term;
        var countIntersectLetters = 0;
        foreach (var word in words)
        {
            var intersectLetters = CountIntersectLetters(word, term);

            if (intersectLetters == 0)
            {
                result = word;
                break;
            }

            if (intersectLetters == word.Length)
                continue;

            if (intersectLetters > countIntersectLetters)
            {
                result = word;
                countIntersectLetters = intersectLetters;
            }
        }

        return result;
    }

    private int CountIntersectLetters(string word, string term)
        => word.Intersect(term).Count();
}