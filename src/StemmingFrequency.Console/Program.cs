using StemmingFrequency.Core;

Console.Clear();

Console.WriteLine("Enter string to get the stem word frequency ...");
Console.WriteLine("If no input is given  default string ({0}) will be taken as input.", InputConstants.DefaultInputString);
var inputString = Console.ReadLine();
inputString = string.IsNullOrEmpty(inputString) ? InputConstants.DefaultInputString : inputString;

var getStemWordFrequency = new GetStemWordFrequency();
var wordAndFrequencyList = getStemWordFrequency.GetFrequency(inputString);

foreach (var wordAndFrequency in wordAndFrequencyList)
{
    Console.WriteLine("{0}   {1}", wordAndFrequency.word, wordAndFrequency.Frequency);
}

Console.ReadLine();