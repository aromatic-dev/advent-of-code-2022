var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day10.txt"));

var ops = new Queue<Op>();
foreach (var instruction in input)
{
    var tokens = instruction.Split(" ");

    var op = new Op
    {
        Type = tokens[0]
    };

    if (tokens[0] == "noop")
    {
        op.Ticks = 1;
    } 
    else if (tokens[0] == "addx")
    {
        op.Ticks = 2;
        op.Arg = int.Parse(tokens[1]);
    }

    ops.Enqueue(op);
}

int cycle = 1;
int X = 1;

// Part 1
//int nextSampleCycle = 20;
//var signalStrengthSum = 0;

//for (; ; cycle++)
//{
//    if (!ops.TryPeek(out var op))
//    {
//        break;
//    }

//    if (cycle == nextSampleCycle)
//    {
//        signalStrengthSum += cycle * X;
//        Console.WriteLine($"Cycle = {cycle}, X = {X}, signal strength = {cycle * X}");

//        nextSampleCycle += 40;
//    }

//    op.Ticks--;
//    if (op.Ticks == 0)
//    {
//        if (op.Type == "addx")
//        {
//            X += op.Arg;
//        }

//        ops.Dequeue();
//    }
//}

//Console.WriteLine(signalStrengthSum);

// Part 2
for (; ; cycle++)
{
    if (!ops.TryPeek(out var op))
    {
        break;
    }

    var pixel = ".";

    var beam = (cycle - 1) % 40;
    if (beam <= X + 1 && beam >= X - 1)
        pixel = "#";

    Console.Write(pixel);

    if (cycle % 40 == 0)
    {
        Console.WriteLine();
    }

    op.Ticks--;
    if (op.Ticks == 0)
    {
        if (op.Type == "addx")
        {
            X += op.Arg;
        }

        ops.Dequeue();
    }
}

class Op
{
    public string Type { get; set; }

    public int Ticks { get; set; }

    public int Arg { get; set; }
}