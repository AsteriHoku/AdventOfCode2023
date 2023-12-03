using System.Text;

var inputLines = input.Split("\n");

UInt64 sum = 0;

foreach(var line in inputLines)
{
    var sb = new StringBuilder();
    for (int i = 0; i < line.Length; i++)
    {
        if (Char.IsDigit(line[i]))
            sb.Append(line[i]);
    }   
    var allDigits = sb.ToString();
    var lineNum = $"{allDigits[0]}{allDigits[allDigits.Length - 1]}";
    var doubleDigit = UInt64.Parse(lineNum);
    sum += doubleDigit;
}

Console.WriteLine($"sum is {sum}");

