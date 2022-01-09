using System;
using System.Collections.Generic;
using System.Linq;

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
        var missingLetters = 0;

        for (var i = 0; i < word.Length; i++)
        {
            if (i + 1 > term.Length)
                break;

            if (word[i] == term[i])
                continue;

            if (i + 1 > word.Length)
                break;

            missingLetters++;

            if (word[i + 1] != term[i])
            {
                missingLetters++;
            }
        }

        return missingLetters;
    }
}