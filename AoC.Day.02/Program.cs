using System.Text.RegularExpressions;

Console.WriteLine("Hi, Mom!");
Console.WriteLine("Cannot exceed 12 red || 13 green || 14 blue\\n");
//only 12 red cubes, 13 green cubes, and 14 blue cubes

int sum = 0;


//test

String t0 = "Game 27: 8 blue, 2 red; 2 green, 8 blue, 6 red; 4 green, 2 red; 2 blue, 4 green, 7 red";
Solve(t0);
Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"t0 Game 27 sum should be 27 {sum == 27}");
Console.ResetColor();
sum = 0; //reset

String t1 = "Game 40: 1 blue, 2 red, 2 green; 2 green, 14 blue; 2 red, 6 blue; 13 blue; 2 green, 10 blue";
Solve(t1);
Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"t1 Game 40 sum should be 40 {sum == 40}");
Console.ResetColor();
sum = 0; //reset

String t2 = "Game 57: 5 green, 3 red, 2 blue; 10 green, 12 blue, 16 red; 7 blue, 13 red, 11 green";
Solve(t2);
Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"t2 Game 57 had too many red and sum should be 0 {sum == 0}");
Console.ResetColor();
sum = 0;

String t3 =
    "Game 1: 1 green, 2 blue; 15 blue, 12 red, 2 green; 4 red, 6 blue; 10 blue, 8 red; 3 red, 12 blue; 1 green, 12 red, 8 blue";
Solve(t3);
Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"t3 Game 1 had too many blue and sum should be 0 {sum == 0}");
Console.ResetColor();
sum = 0;


sum = 0; //reset after tests

//solve

StreamReader sr = new StreamReader("../../../day2.txt");

while (sr.Peek() >= 0)
{
    Solve(sr.ReadLine());
}

Console.WriteLine($"Congratulations you've reached the end sum of {sum}");

void Solve(String line)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(line);

    var games = line.Split(':', ';');
    string gameId = Regex.Replace(games[0], @"\D", "");
    int fails = 0;
    for (int i = 1; i < games.Length; ++i)
    {
        if (games[i].Contains("red"))
        {
            int ri = games[i].IndexOf("red");
            if (int.Parse($"{games[i][ri - 3]}{games[i][ri - 2]}") > 12)
            {
                ++fails;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"--->\tGame {gameId} had too many red - {fails} fails");
            }
        }

        if (games[i].Contains("green"))
        {
            int gi = games[i].IndexOf("green");
            if (int.Parse($"{games[i][gi - 3]}{games[i][gi - 2]}") > 13)
            {
                ++fails;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"--->\tGame {gameId} had too many green - {fails} fails");
            }
        }

        if (games[i].Contains("blue"))
        {
            int bi = games[i].IndexOf("blue");
            if (int.Parse($"{games[i][bi - 3]}{games[i][bi - 2]}") > 14)
            {
                ++fails;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"--->\tGame {gameId} had too many blue - {fails} fails");
            }
        }
    }

    if (fails == 0)
    {
        sum += int.Parse(gameId);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Adding {gameId} to sum - sum now {sum}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"sum did not change");
    }
}