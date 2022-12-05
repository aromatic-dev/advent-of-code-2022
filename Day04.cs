var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day04.txt"));

var rangeContainmentCount = 0;

var pairs = input.Split(Environment.NewLine);
foreach (var pair in pairs)
{
    var assignments = pair.Split(',');
    var range1 = assignments[0].Split('-').Select(id => int.Parse(id));
    var range2 = assignments[1].Split('-').Select(id => int.Parse(id));

    // Part 1
    //if (range1.ElementAt(0) >= range2.ElementAt(0) &&
    //    range1.ElementAt(1) <= range2.ElementAt(1) ||

    //    range1.ElementAt(0) <= range2.ElementAt(0) &&
    //    range1.ElementAt(1) >= range2.ElementAt(1))
    //    rangeContainmentCount++;

    // Part 2
    if (!(range1.ElementAt(1) < range2.ElementAt(0) ||
        range1.ElementAt(0) > range2.ElementAt(1)))
    {
        rangeContainmentCount++;
    }
}

Console.WriteLine(rangeContainmentCount);