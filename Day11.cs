var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day11.txt"));

var monkeys = new List<Monkey>();

for (var i = 0; i < input.Length;)
{
    var monkey = new Monkey();
    monkeys.Add(monkey);
    monkey.Name = input[i][7..].Replace(":", "");
    monkey.Items = input[++i][17..].Split(", ").Select(x => new Item { WorryLevel = int.Parse(x) }).ToList();

    var op = input[++i][23..].Split(" ");
    if (op[0] == "*" && op[1] == "old")
        monkey.OpSquare = true;
    else if (op[0] == "*")
        monkey.OpMultiplyBy = int.Parse(op[1]);
    else
        monkey.OpAddTo = int.Parse(op[1]);

    monkey.Modulus = int.Parse(input[++i][20..]);

    monkey.TrueDest = input[++i][^1].ToString();
    monkey.FalseDest = input[++i][^1].ToString();

    i += 2;
}

for (var round = 0; round < 20; round++)
{
    foreach (var monkey in monkeys)
    {
        foreach (var item in monkey.Items)
        {
            monkey.InspectionCount++;

            if (monkey.OpSquare)
                item.WorryLevel *= item.WorryLevel;
            else
                item.WorryLevel = item.WorryLevel * monkey.OpMultiplyBy + monkey.OpAddTo;

            item.WorryLevel /= 3;

            if (item.WorryLevel % monkey.Modulus == 0)
            {
                item.ThrownTo = monkey.TrueDest;
            }
            else
            {
                item.ThrownTo = monkey.FalseDest;
            }
        }

        while (monkey.Items.FirstOrDefault(x => x.ThrownTo != null) is { } thrownItem)
        {
            var catchingMonkey = monkeys.Single(x => x.Name == thrownItem.ThrownTo);
            catchingMonkey.Items.Add(thrownItem);
            thrownItem.ThrownTo = null;
            monkey.Items.Remove(thrownItem);
        }
    }
}

var topMonkeys = monkeys.OrderByDescending(x => x.InspectionCount).Take(2).ToList();
Console.WriteLine(topMonkeys[0].InspectionCount * topMonkeys[1].InspectionCount);

class Monkey
{
    public string Name { get; set; }

    public List<Item> Items { get; set; }

    public int InspectionCount { get; set; }

    public int OpMultiplyBy { get; set; } = 1;

    public int OpAddTo { get; set; } = 0;

    public bool OpSquare { get; set; }

    public int Modulus { get; set; }

    public string TrueDest { get; set; }

    public string FalseDest { get; set; }
}

class Item
{
    public int WorryLevel { get; set; }

    public string ThrownTo { get; set; }
}