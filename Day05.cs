using System.Linq;

var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day05.txt"));

var stacks = new Stack<char>[9];
for (var stackIndex = 0; stackIndex < stacks.Length; stackIndex++)
{
    var crateColumn = stackIndex * 4 + 1;
    var stack = stacks[stackIndex] = new Stack<char>();
    for (var crateLevel = 7; crateLevel >= 0; crateLevel--)
    {
        var crate = input[crateLevel][crateColumn];
        if (crate == ' ')
            break;
        
        stack.Push(crate);
    }
}


for (var i = 10; i < input.Length; i++)
{
    var instructions = input[i].Split(' ');
    var count = int.Parse(instructions[1]);
    var fromIndex = int.Parse(instructions[3]) - 1;
    var toIndex =  int.Parse(instructions[5]) - 1;

    // Part 1
    //while (count > 0)
    //{
    //    var crate = stacks[fromIndex].Pop();
    //    stacks[toIndex].Push(crate);
    //    count--;
    //}

    // Part 2
    var tempStack = new Stack<char>();
    while (count > 0)
    {
        var crate = stacks[fromIndex].Pop();
        tempStack.Push(crate);
        count--;
    }

    while (tempStack.TryPop(out char crate))
    {
        stacks[toIndex].Push(crate);
    }
}

foreach (var stack in stacks)
{
    Console.Write(stack.Peek());
}