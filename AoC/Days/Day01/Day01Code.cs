namespace AdventOfCode2023.Days.Day01;

public class Day01Code {
    string[] inputLines = new StreamReader("../../../day1.txt").ReadToEnd().Split("\n");

    Dictionary<string,char> pairs = new Dictionary<string, char>
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

// day 1 puzzle 1:
//
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
// foreach (var line in inputLines)
// {
//     List<string> splits = Regex.Matches(line.Trim(), @"\d+|[^0-9]+")
//         .OfType<Match>()
//         .Select(m => m.Value)
//         .ToList();
//
//     char first = Char.IsDigit(splits[0][0]) ? splits[0][0] : AssessLettersForFirst(splits);
//     char last = Char.IsDigit(splits[^1][^1]) ? splits[^1][^1] : AssessLettersForLast(splits);
//
//     if (int.TryParse($"{first}{last}", out int result)) {
//         sum += result;
//     } else {
//         throw new Exception();
//     }
// }
//
//
// //break out logic
// char AssessLettersForFirst(List<string> splitsies)
// {
//     int getFirst = splitsies[0].Length;
//     string numWordToAdd = "foo";
//
//     foreach (var word in pairs.Keys) {
//         if (splitsies[0].Contains(word) && splitsies[0].IndexOf(word) < getFirst) {
//             getFirst = splitsies[0].IndexOf(word);
//             numWordToAdd = word;
//         }
//     }
//
//     //if first word is not a number word, must add first digit in the next index of splits
//     return numWordToAdd != "foo" ? pairs[numWordToAdd] : splitsies[1][0];
// }
//
// char AssessLettersForLast(List<string> splitsters)
// {
//     int getLast = 0;
//     string numWordToAdd = "bas";
//
//     foreach (var word in pairs.Keys) {
//         if (splitsters[^1].Contains(word) && splitsters[^1].LastIndexOf(word) >= getLast) {
//             getLast = splitsters[^1].LastIndexOf(word);
//             numWordToAdd = word;
//         }
//     }
//
//     //if last word is not a number word, must add last digit in the previous index of splits
//     return numWordToAdd != "bas" ? pairs[numWordToAdd] : splitsters[^2][^1];
// }


// foreach (var word in pairs.Keys)
// {
//     inputLines = inputLines.Replace(word, $"{pairs[word][0]}{pairs[word]}{pairs[word][^1]}");
// }
//
// inputLines = Regex.Replace(inputLines, @"[^\d\r\n]", "");
//
// var lines = inputLines.Trim().Split("\n");
//
// foreach(var line in lines)
// {
//     Console.WriteLine(line);
//     line.Trim();
//     var doubleDigit = int.Parse($"{line[0]}{line[^1]}");
//     Console.WriteLine((doubleDigit));
//     sum += doubleDigit;
// }
//
// Console.WriteLine($"sum is {sum}");


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
}