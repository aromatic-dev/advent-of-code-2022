var input = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day06.txt"));

// Part 1
// for (var i = 3; i < input.Length; i++)
// {
//     var set = new HashSet<char>
//     {
//         input[i],
//         input[i - 1],
//         input[i - 2],
//         input[i - 3]
//     };
//     
//     if (set.Count == 4)
//     {
//         Console.WriteLine(i + 1);
//         break;
//     }
// }

// Part 2
for (var i = 13; i < input.Length; i++)
{
    var set = new HashSet<char>();
    for (int j = 0; j < 14; j++)
    {
        set.Add(input[i - j]);
    }

    if (set.Count == 14)
    {
        Console.WriteLine(i+1);
        break;
    }
}