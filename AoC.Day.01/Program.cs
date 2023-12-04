using System.Text.RegularExpressions;

Console.WriteLine("Advent of Code 2023 day 1!");

string[] inputLines = new StreamReader("../../../day1.txt").ReadToEnd().Split("\n");
var pairs = new Dictionary<string, char>
{
    { "one", '1' },
    { "two", '2' },
    { "three", '3' },
    { "four", '4' },
    { "five", '5' },
    { "six", '6' },
    { "seven", '7' },
    { "eight", '8' },
    { "nine", '9' }
};
int sum = 0;

string[] testLines = new[]
{
    "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"
};

foreach (var line in inputLines)
{
    char first, last;
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"Line is {line.Trim()}");
    Console.ForegroundColor = ConsoleColor.Blue;

    var splits = Regex.Matches(line.Trim(), @"\d+|[^0-9]+")
        .OfType<Match>()
        .Select(m => m.Value)
        .ToList();

    if (Char.IsDigit(splits[0][0]))
    {
        first = splits[0][0];
        Console.WriteLine($"first was digit: {splits[0][0]}");
    }
    else
    {
        first = AssessLettersForFirst(splits);
    }

    if (Char.IsDigit(splits[^1][^1]))
    {
        last = splits[^1][^1];
        Console.WriteLine($"last was digit: {splits[^1][^1]}");
    }
    else
    {
        last = AssessLettersForLast(splits);
    }

    if (int.TryParse($"{first}{last}", out int result))
    {
        Console.WriteLine($"Adding {first}{last} to sum");
        sum += result;
    }
    else
    {
        Console.WriteLine("WE HAVE FOUND THE PROBLEM");
    }

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"sum is now {sum}");
}

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Congratulations you have reached the end with a sum of {sum}");


//break out logic
char AssessLettersForFirst(List<string> splitsies)
{
    int getFirst = splitsies[0].Length;
    string numWordToAdd = "foo";

    foreach (var word in pairs.Keys)
    {
        if (splitsies[0].Contains(word) && splitsies[0].IndexOf(word) < getFirst)
        {
            getFirst = splitsies[0].IndexOf(word);
            numWordToAdd = word;
        }
    }

    //if first word is not a number word, must add first digit in the next index of splits
    if (numWordToAdd != "foo")
    {
        Console.WriteLine($"first was word: {pairs[numWordToAdd]}");
        return pairs[numWordToAdd];
    }

    Console.WriteLine($"first was digit: {splitsies[1][0]}");
    return splitsies[1][0];
}

char AssessLettersForLast(List<string> splitsters)
{
    int getLast = 0;
    string numWordToAdd = "bas";

    foreach (var word in pairs.Keys)
    {
        if (splitsters[^1].Contains(word) && splitsters[^1].LastIndexOf(word) >= getLast)
        {
            getLast = splitsters[^1].LastIndexOf(word);
            numWordToAdd = word;
        }
    }

    //if last word is not a number word, must add last digit in the previous index of splits
    if (numWordToAdd != "bas")
    {
        Console.WriteLine($"last was word: {pairs[numWordToAdd]}");
        return pairs[numWordToAdd];
    }

    Console.WriteLine($"last was digit: {splitsters[^2][^1]}");
    return splitsters[^2][^1];
}


//Console.WriteLine($"sum is {sum}");

// day 1 puzzle 1:

// foreach(var line in inputLines)
// {
//     var sb = new StringBuilder();
//     for (int i = 0; i < line.Length; i++)
//     {
//         if (Char.IsDigit(line[i]))
//             sb.Append(line[i]);
//     }   
//     var allDigits = sb.ToString();
//     var lineNum = $"{allDigits[0]}{allDigits[allDigits.Length - 1]}";
//     var doubleDigit = UInt64.Parse(lineNum);
//     sum += doubleDigit;
// }
//
// Console.WriteLine($"sum is {sum}");

// foreach (string line in inputLines)
// {
//     var result = SplitString(line);
//     Console.WriteLine(string.Join(", ", result));
// }
//
//
// static List<string> SplitString(string input)
// {
//     var sections = Regex.Matches(input, @"\d+|[^0-9]+")
//         .OfType<Match>()
//         .Select(m => m.Value)
//         .ToList();
//
//     return sections;
// }


// for (int i = 0; i < line.Length; i++)
// {
//     if (Char.IsDigit(line[i]))
//     {
//         orderedList.Add(line[i]);//add to ordered list
//         //or:
//         //compare the index i to index of first char in first word
//         // if (i < line.IndexOf(words[0]))//less than for first occurrence
//         // {
//         //     sb.Append(line[i]);//todo Sarah < for last
//         // }
//         
//     }
//     else
//     {
//         //todo account for outer loop being char by char, whereas this will 
//         var wordSb = new StringBuilder();
//         
//         for (int j = i; j < line.Length; j++)
//         {
//             while (!Char.IsDigit(line[j]))
//             {
//                 wordSb.Append(line[j]);
//             }
//             
//             foreach (var word in pairs.Keys)
//             {
//                 if (wordSb.ToString().Contains(word))
//                 {
//                     orderedList.Add(pairs[word]);
//                 }
//             }
//             
//             i = j;//set i to index of j which should be the end of the "word"
//         }
//     }
//         
// }   
// var allDigits = sb.ToString();
// var lineNum = $"{allDigits[0]}{allDigits[allDigits.Length - 1]}";
// var doubleDigit = UInt64.Parse(lineNum);
// sum += doubleDigit;


//test
// Console.WriteLine(SumForEachLine("two1nine") == 29);
// Console.WriteLine(SumForEachLine("eightwothree") == 83);
// Console.WriteLine(SumForEachLine("abcone2threexyz") == 13);
// Console.WriteLine(SumForEachLine("xtwone3four") == 24);
// Console.WriteLine(SumForEachLine("4nineeightseven2") == 42);
// Console.WriteLine(SumForEachLine("zoneight234") == 14);
// Console.WriteLine(SumForEachLine("7pqrstsixteen") == 76);