var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day02.txt"));

var games = input.Split(Environment.NewLine);
var score = 0;
foreach (var game in games)
{
    // Part one
    //if (game[0] == 'A' && game[2] == 'X' ||
    //    game[0] == 'B' && game[2] == 'Y' ||
    //    game[0] == 'C' && game[2] == 'Z')
    //    score += 3;

    //if (game[0] == 'A' && game[2] == 'Y' ||
    //    game[0] == 'B' && game[2] == 'Z' ||
    //    game[0] == 'C' && game[2] == 'X')
    //    score += 6;

    //if (game[2] == 'X')
    //    score += 1;
    //else if (game[2] == 'Y')
    //    score += 2;
    //else
    //    score += 3;

    // Part two
    if (game[2] == 'X')
    {
        // lose
        if (game[0] == 'A')
            score += 3;
        else if (game[0] == 'B')
            score += 1;
        else
            score += 2;
    } 
    else if (game[2] == 'Y')
    {
        // draw
        score += 3;

        if (game[0] == 'A')
            score += 1;
        else if (game[0] == 'B')
            score += 2;
        else
            score += 3;
    }
    else
    {
        // win
        score += 6;

        if (game[0] == 'A')
            score += 2;
        else if (game[0] == 'B')
            score += 3;
        else
            score += 1;
    }
}

Console.WriteLine(score);