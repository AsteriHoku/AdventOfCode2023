// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Advent of Code 2023 day 1 puzzle 2!");

StreamReader sr = new StreamReader("../Inputs/day1.txt");
string[] inputLines = sr.ReadToEnd().Trim().Split("\n");
UInt64 sum = 0;

var pairs = new Dictionary<string, int>()
{
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four",4},
    {"five",5},
    {"six",6},
    {"seven",7},
    {"eight",8},
    {"nine",9}
};

var numWords = new String[9]
{
    "one","two","three","four","five","six","seven","eight","nine"
};
int firstNum;
int lastNum;

foreach(var line in inputLines)
{
    var sb = new StringBuilder();
    var words = new List<String>();

    var orderedList = new List<int>();

    //todo Sarah find if first digit or first word & last
    
    //check if the index of the first char of the first word is before/after the index of the first digit
    //also for end
    
    var splits = line.Trim().Split("/^\\d/");
    
    for (int i = 0; i < line.Length; i++)
    {
        if (Char.IsDigit(line[i]))
        {
            orderedList.Add(line[i]);//add to ordered list
            //or:
            //compare the index i to index of first char in first word
            // if (i < line.IndexOf(words[0]))//less than for first occurrence
            // {
            //     sb.Append(line[i]);//todo Sarah < for last
            // }
            
        }
        else
        {
            //todo account for outer loop being char by char, whereas this will 
            var wordSb = new StringBuilder();
            
            for (int j = i; j < line.Length; j++)
            {
                while (!Char.IsDigit(line[j]))
                {
                    wordSb.Append(line[j]);
                }
                
                foreach (var word in numWords)
                {
                    if (wordSb.ToString().Contains(word))
                    {
                        orderedList.Add(pairs[word]);
                    }
                }
                
                i = j;//set i to index of j which should be the end of the "word"
            }
        }
            
    }   
    var allDigits = sb.ToString();
    var lineNum = $"{allDigits[0]}{allDigits[allDigits.Length - 1]}";
    var doubleDigit = UInt64.Parse(lineNum);
    sum += doubleDigit;
}

Console.WriteLine($"sum is {sum}");