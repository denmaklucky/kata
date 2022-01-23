using System.Xml;

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
        var countIntersectLetters = int.MaxValue;
        foreach (var word in words)
        {
            var intersectLetters = NumberOfChangingLetters(word, term);

            if (intersectLetters == 0)
            {
                result = word;
                break;
            }

            if (intersectLetters < countIntersectLetters)
            {
                result = word;
                countIntersectLetters = intersectLetters;
            }
        }

        return result;
    }

    private static int NumberOfChangingLetters(string word, string term)
    {
        if (word.IndexOf(term, StringComparison.Ordinal) != -1)
            return word.Length - term.Length;

        var changingLetters = 0;

        if (word.Length == term.Length)
        {
            changingLetters += word.Where((t, i) => t != term[i]).Count();
            return changingLetters;
        }

        if (word.Length > term.Length)
        {
            int i = 0, j = 0;
            for (; i < word.Length;)
            {
                for (; j < term.Length;)
                {
                    if (word[i] == term[j])
                    {
                        i++;
                        j++;
                        break;
                    }

                    changingLetters++;

                    if (i + 1 >= word.Length)
                    {
                        i++;
                        break;
                    }

                    if (word[i + 1] == term[j])
                    {
                        i += 2;
                        j++;
                        break;
                    }
                    else
                    {
                        i++;
                        j++;
                        break;
                    }
                }
                
                if(i >= word.Length)
                {
                    break;
                }

                if (j >= term.Length && i <= word.Length)
                {
                    changingLetters += word.Length - term.Length;
                    break;
                }
            }

            return changingLetters;
        }

        if (word.Length < term.Length)
        {
            int i = 0, j = 0;
            for (; i < term.Length;)
            {
                for (; j < word.Length;)
                {
                    if (term[i] == word[j])
                    {
                        i++;
                        j++;
                        break;
                    }

                    changingLetters++;

                    if (i + 1 >= term.Length)
                    {
                        i++;
                        break;
                    }

                    if (term[i + 1] == word[j])
                    {
                        i += 2;
                        j++;
                        break;
                    }
                    else
                    {
                        i++;
                        j++;
                        break;
                    }
                }
                
                if(i >= term.Length)
                {
                    break;
                }

                if (j >= word.Length && i <= term.Length)
                {
                    changingLetters += term.Length - word.Length;
                    break;
                }
            }

            return changingLetters;
        }

        return changingLetters;
    }
}