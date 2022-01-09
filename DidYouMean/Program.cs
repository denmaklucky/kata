
using DidYouMean;

var kata = new Kata(new List<string> { "stars","codewars","wars","mars","code","codec"});
Console.WriteLine(kata.FindMostSimilar("coddwars"));