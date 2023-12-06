﻿using System.Text.RegularExpressions;

StreamReader sr = new StreamReader("../../../day2.txt");
int sum = 0;

while (sr.Peek() >= 0) {
    Solve(sr.ReadLine());
}

Console.WriteLine($"Congratulations you've reached the end sum of {sum}");

void Solve(String line) {
    var pieces = Regex.Split(line, @"[^a-zA-Z0-9]+");
    int r=0,g=0,b=0;
    
    for (int i = 3; i < pieces.Length; ++i) {
        if (pieces[i] == "red") {
            r = int.TryParse(pieces[i - 1], out int ro) && (ro > r) ? ro : r;
        }
        if (pieces[i] == "green") {
            g =int.TryParse(pieces[i - 1], out int go) && (go > g) ? go : g;
        }
        if (pieces[i] == "blue") {
            b = int.TryParse(pieces[i - 1], out int bo) && (bo > b) ? bo : b;
        }
    }
    sum += r*g*b;
}




//day 2 no1
//
// StreamReader sr = new StreamReader("../../../day2.txt");
// int sum = 0;
//
// while (sr.Peek() >= 0)
// {
//     Solve(sr.ReadLine());
// }
//
// Console.WriteLine($"Congratulations you've reached the end sum of {sum}");
//
// void Solve(String line)
// {
//     var games = line.Split(':', ';');
//     string gameId = Regex.Replace(games[0], @"\D", "");
//     int fails = 0;
//     for (int i = 1; i < games.Length; ++i)
//     {
//         if (games[i].Contains("red")) {
//             int ri = games[i].IndexOf("red");
//             if (int.Parse($"{games[i][ri - 3]}{games[i][ri - 2]}") > 12)
//                 ++fails;
//         }
//
//         if (games[i].Contains("green")) {
//             int gi = games[i].IndexOf("green");
//             if (int.Parse($"{games[i][gi - 3]}{games[i][gi - 2]}") > 13)
//                 ++fails;
//         }
//
//         if (games[i].Contains("blue")) {
//             int bi = games[i].IndexOf("blue");
//             if (int.Parse($"{games[i][bi - 3]}{games[i][bi - 2]}") > 14)
//                 ++fails;
//         }
//     }
//
//     if (fails == 0)
//         sum += int.Parse(gameId);
// }