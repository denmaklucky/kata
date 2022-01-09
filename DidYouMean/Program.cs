
using DidYouMean;

var kata = new Kata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry" });
Console.WriteLine(kata.FindMostSimilar("berry"));