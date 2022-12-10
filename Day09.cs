var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day09.txt"));

// Part 1
//var head = new Point();
//var tail = head;

//var visited = new HashSet<Point>();
//foreach(var move in input)
//{
//    int dirX = 0, dirY = 0;

//    switch (move[0])
//    {
//        case 'U': dirY = 1; break;
//        case 'D': dirY = -1; break;
//        case 'L': dirX = -1; break;
//        case 'R': dirX = 1; break;
//    }

//    var steps = int.Parse(move.Substring(2));
//    for (; steps > 0; steps--)
//    {
//        head.X += dirX;
//        head.Y += dirY;

//        if (Math.Abs(head.X - tail.X) > 1)
//        {
//            tail.X += dirX;
//            tail.Y = head.Y;
//        }

//        if (Math.Abs(head.Y - tail.Y) > 1)
//        {
//            tail.Y += dirY;
//            tail.X = head.X;
//        }

//        visited.Add(tail);
//    }
//}

//Console.WriteLine(visited.Count);

// Part 2
var rope = new Point[10];

var visited = new HashSet<Point>();
foreach (var move in input)
{
    int dirX = 0, dirY = 0;

    switch (move[0])
    {
        case 'U': dirY = 1; break;
        case 'D': dirY = -1; break;
        case 'L': dirX = -1; break;
        case 'R': dirX = 1; break;
    }

    var steps = int.Parse(move.Substring(2));
    var stepsLeft = steps;
    for (; stepsLeft > 0; stepsLeft--)
    {
        rope[0].X += dirX;
        rope[0].Y += dirY;

        //DebugPrint($"{move} step {steps - stepsLeft + 1} - Head moved:");

        for (int i = 0; i < rope.Length - 1; i++)
        {
            var xDist = rope[i].X - rope[i + 1].X;
            var yDist = rope[i].Y - rope[i + 1].Y;

            if (Math.Abs(xDist) > 1 && Math.Abs(yDist) > 1)
            {
                rope[i + 1].X += Math.Sign(xDist);
                rope[i + 1].Y += Math.Sign(yDist);
            }
            else if (Math.Abs(xDist) > 1)
            {
                rope[i + 1].X += Math.Sign(xDist);
                rope[i + 1].Y = rope[i].Y;
            }
            else if (Math.Abs(yDist) > 1)
            {
                rope[i + 1].Y += Math.Sign(yDist);
                rope[i + 1].X = rope[i].X;
            }

            //DebugPrint($"{move} step {steps - stepsLeft + 1} - knot {i + 1} moved:");
        }

        visited.Add(rope[9]);
    }
}

Console.WriteLine(visited.Count);

void DebugPrint(string move)
{
    Console.Clear();
    Console.WriteLine(move);
    int minX, minY, maxX, maxY;
    minX = minY = maxX = maxY = 0;

    foreach(var point in rope)
    {
        if (point.X < minX) minX = point.X;
        if (point.X > maxX) maxX = point.X;

        if (point.Y < minY) minY = point.Y;
        if (point.Y > maxY) maxY = point.Y;
    }

    var xOffset = minX < 0 ? Math.Abs(minX) : 0;
    var yOffset = minY < 0 ? Math.Abs(minY) : 0;

    var offsetRope = rope.Select(knot => new Point { X = knot.X + xOffset, Y = knot.Y + yOffset }).ToArray();
    for (var y = maxY + yOffset; y >= 0; y--)
    {
        for (var x = 0; x <= maxX + xOffset; x++)
        {
            string charToPrint = ".";
            for (var i = offsetRope.Length - 1; i >= 0; i--)
            {
                if (offsetRope[i].X == x && offsetRope[i].Y == y)
                {
                    if (i == 9)
                        charToPrint = "T";
                    else if (i == 0)
                        charToPrint = "H";
                    else
                        charToPrint = i.ToString();
                } 
            }
            Console.Write(charToPrint);
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}

struct Point { public int X; public int Y; };