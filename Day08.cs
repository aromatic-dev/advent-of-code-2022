var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day08.txt"));

// Part 1
//var visibleCount = 0;
// for (int y = 0; y < input.Length; y++)
// {
//     for (int x = 0; x < input[0].Length; x++)
//     {
//         var current = (int)char.GetNumericValue(input[y][x]);
//
//         var visible = true;
//         
//         // down
//         for (int yy = y + 1; yy < input.Length; yy++)
//         {
//             var other = (int)char.GetNumericValue(input[yy][x]);
//             if (other >= current)
//             {
//                 visible = false;
//                 break;
//             }
//         }
//
//         if (visible)
//         {
//             visibleCount++;
//             continue;
//         }
//         
//         visible = true;
//         
//         // up
//         for (int yy = y - 1; yy >= 0; yy--)
//         {
//             var other = (int)char.GetNumericValue(input[yy][x]);
//             if (other >= current)
//             {
//                 visible = false;
//                 break;
//             }
//         }
//
//         if (visible)
//         {
//             visibleCount++;
//             continue;
//         }
//         
//         visible = true;
//         
//         // right
//         for (int xx = x + 1; xx < input[0].Length; xx++)
//         {
//             var other = (int)char.GetNumericValue(input[y][xx]);
//             if (other >= current)
//             {
//                 visible = false;
//                 break;
//             }
//         }
//
//         if (visible)
//         {
//             visibleCount++;
//             continue;
//         }
//         
//         visible = true;
//         
//         // left
//         for (int xx = x - 1; xx >= 0; xx--)
//         {
//             var other = (int)char.GetNumericValue(input[y][xx]);
//             if (other >= current)
//             {
//                 visible = false;
//                 break;
//             }
//         }
//
//         if (visible)
//         {
//             visibleCount++;
//         }
//     }
// }
//
// Console.WriteLine(visibleCount);

// Part 2

var highestScore = 0;
for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input[0].Length; x++)
    {
        var current = (int)char.GetNumericValue(input[y][x]);

        var down = 0;
        for (int yy = y + 1; yy < input.Length; yy++)
        {
            down++;
            var other = (int)char.GetNumericValue(input[yy][x]);
            if (other >= current)
            {
                break;
            }
        }

        var up = 0;
        for (int yy = y - 1; yy >= 0; yy--)
        {
            up++;
            var other = (int)char.GetNumericValue(input[yy][x]);
            if (other >= current)
            {
                break;
            }
        }

        var right = 0;
        for (int xx = x + 1; xx < input[0].Length; xx++)
        {
            right++;
            var other = (int)char.GetNumericValue(input[y][xx]);
            if (other >= current)
            {
                break;
            }
        }

        var left = 0;
        for (int xx = x - 1; xx >= 0; xx--)
        {
            left++;
            var other = (int)char.GetNumericValue(input[y][xx]);
            if (other >= current)
            {
                break;
            }
        }

        var score = up * left * down * right;
        if (score > highestScore)
        {
            highestScore = score;
        }
    }
}

Console.WriteLine(highestScore);