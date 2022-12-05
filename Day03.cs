var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day03.txt"));

var totalPriority = 0;
var priorityLookup = new Dictionary<char, int>();
for (var c = 'a'; c <= 'z'; c++)
{
    priorityLookup.Add(c, c - 96);
}

for (var c = 'A'; c <= 'Z'; c++)
{
    priorityLookup.Add(c, c - 38);
}

var bag1set = new HashSet<char>();
var bag2set = new HashSet<char>();

var bags = input.Split(Environment.NewLine);
for (int i = 0; i < bags.Length; i++)
{
    var bag = bags[i];

    // Part one
    //var compartment1Items = new HashSet<char>();

    //var compartment1 = bag[..(bag.Length / 2)];
    //foreach (var item in compartment1)
    //{
    //    compartment1Items.Add(item);
    //}

    //var compartment2 = bag[(bag.Length / 2)..];
    //foreach (var item in compartment2)
    //{
    //    if (compartment1Items.Contains(item))
    //    {
    //        totalPriority += priorityLookup[item];
    //        break;
    //    }
    //}

    // Part two

    if (i % 3 == 0)
    {
        foreach (var item in bag)
        {
            bag1set.Add(item);
        }
    } 
    else if (i % 3 == 1)
    {
        foreach (var item in bag)
        {
            bag2set.Add(item);
        }
    } 
    else
    {
        foreach (var item in bag)
        {
            if (bag1set.Contains(item) && bag2set.Contains(item))
            {
                totalPriority += priorityLookup[item];
                bag1set.Clear();
                bag2set.Clear();
                break;
            }
        }
    }
}

Console.WriteLine(totalPriority);