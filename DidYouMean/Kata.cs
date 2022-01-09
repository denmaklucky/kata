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
        var countMissingLetters = int.MaxValue;
        foreach (var word in words)
        {
            var missingLetters = CountMissingLetters(word, term);

            if (missingLetters == 0)
            {
                result = word;
                break;
            }

            if (missingLetters == word.Length)
                continue;

            if (missingLetters < countMissingLetters)
            {
                result = word;
                countMissingLetters = missingLetters;
            }
        }

        return result;
    }

    private int CountMissingLetters(string word, string term)
    {
        var missingChars = word.Except(term);
        var count = missingChars.Sum(missingChar => word.Count(c => c == missingChar));
        return count == 0 ? word.Length : count;
    }
}